using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBossManager : MonoBehaviour
{
    public float basicHealth = 4000f;
    [HideInInspector]
    public float healthMax = 1000f;
    [HideInInspector]
    public float health = 1000f;
    public int basicDamage = 20;
    private int damage = 1;
    public GameObject bossObject;
    public GameObject leftEdgePoint;
    public GameObject rightEdgePoint;


    private float timeToAttack = 0f;

    public float speed1 = 0.5f;
    private float journeyLength;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float startTime;
    private Animator anim;
    bool prepare = false;
    bool attack = false;
    bool animAttack = false;
    bool isOnLeftSide = false;
    public GameObject currentDesination;


    bool berserkMode = false; //jesli gracz jest na ziemi
    bool shotingMode = true; // jesli boss ma ponizej 1/3 hp
    bool setupShotingMode = false;
    float shotingModeAttackSpeed = 3f;

    private GameObject player;
    public GameObject bossProjectile;
    public GameObject projectilePoint;

    public AudioSource swingAudio;
    public AudioSource movingAudio;
    public AudioSource orbAudio;
    void Start()
    {
        this.anim = bossObject.GetComponent<Animator>();
    }
    void OnEnable(){
        int replay = GameObject.FindWithTag("PlayerManager").GetComponent<CharacterValues>().replayTimes;
        damage = basicDamage + ( 10 * replay);

        healthMax = basicHealth + (800 * replay);
        health = healthMax;

        player = GameObject.FindWithTag("Player");
        GameObject.Find("DamageBack").GetComponent<BossDamageZone>().damage = (int) (damage * 0.7);
        GameObject.Find("DamageFront").GetComponent<BossDamageZone>().damage = damage;
    }
    public void BossHit(float damage){
        health -= damage;
        if(health < 0) {
            float distance = Vector2.Distance(bossObject.transform.position, GameObject.FindWithTag("Player").transform.position);
            GameObject.FindWithTag("Player").GetComponent<PlayerCombatController>().KilledEnemy(distance, healthMax);
            Destroy(bossObject);
        }
    }
    void Update()
    {
        if(!berserkMode && !shotingMode && bossObject != null){
            AttackPlatform();
            if(Time.time - timeToAttack > 8f && !isOnLeftSide) {
                if(healthMax/3 > health) {
                    shotingMode = true;
                }else {
                    ResetAtack();
                    bossObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    currentDesination = leftEdgePoint;
                    timeToAttack = Time.time;
                    isOnLeftSide = true;
                }
            }
            if(Time.time - timeToAttack > 8f && isOnLeftSide) {
                if(healthMax/3 > health) {
                    shotingMode = true;
                }else {
                    ResetAtack();
                    bossObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    currentDesination = rightEdgePoint;
                    timeToAttack = Time.time;
                    isOnLeftSide = false;
                }
            }
        } else if (berserkMode && !shotingMode && bossObject != null) {
            AttackPlatform();
            if(Time.time - timeToAttack > 4.7f && !isOnLeftSide) {
                ResetAtack();
                bossObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                currentDesination = leftEdgePoint;
                timeToAttack = Time.time;
                isOnLeftSide = true;
            }
            if(Time.time - timeToAttack > 4.7f && isOnLeftSide) {
                ResetAtack();
                bossObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
                currentDesination = rightEdgePoint;
                timeToAttack = Time.time;
                isOnLeftSide = false;
            }
        } else if (shotingMode && bossObject != null) {
            if(!isOnLeftSide && !setupShotingMode) {
                bossObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                setupShotingMode = true;
                timeToAttack = Time.time;
            }else if (!setupShotingMode){
                bossObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
                setupShotingMode = true;
                timeToAttack = Time.time;
            }
            if(Time.time - timeToAttack > shotingModeAttackSpeed) {
                timeToAttack = Time.time;
                orbAudio.Play();
                anim.Play("Attack");
                GameObject projectile = Instantiate(bossProjectile, projectilePoint.transform.position, projectilePoint.transform.rotation);
                projectile.GetComponent<SwordBossProjectile>().Setup(damage);
                projectile.GetComponent<Rigidbody2D>().velocity = (player.transform.position - projectile.transform.position).normalized * 10f;
            }
        }
    }
    void AttackPlatform() {
        if(currentDesination != null){
            if(Time.time - timeToAttack > 1.0f && prepare == false) {
                anim.Play("Prepare");
                prepare = true;
            } else if (Time.time - timeToAttack > 2f && attack == false) {
                attack = true;
                MoveTo(currentDesination);
            } else if(Time.time - timeToAttack > 2f) {
                MoveOnUpdate();
            }
            if (Time.time - timeToAttack > 2.9f && animAttack == false) {
                animAttack = true;
                swingAudio.Play();
                anim.Play("Attack");
            }
        }
    }
    void ResetAtack() {
        prepare = false;
        attack = false;
        animAttack = false;
    }
    void AttackLoop() {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            berserkMode = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            berserkMode = false;
        }
    }
    void MoveTo(GameObject destination) 
    {
        movingAudio.Play();
        endPosition = destination.transform.position;
        startTime = Time.time;
        startPosition = bossObject.transform.position;
        journeyLength = Vector2.Distance(bossObject.transform.position, endPosition);
    }
    void MoveOnUpdate() {
        float distCovered = (Time.time - startTime) * speed1;
        float fracJourney = distCovered / journeyLength;
        bossObject.transform.position = Vector2.Lerp(startPosition, endPosition, fracJourney);
    }

}
