using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;

public class FlowerBossManager : MonoBehaviour
{
    private int damage = 1;
    public int basicDamage = 20;
    [SerializeField] List<float> attackYValues = new List<float>();
    public GameObject flowerHead;
    public GameObject projectilePrefab;
    public Sprite projectileSprite;
    public GameObject shotPoint;
    public float timeForSection = 6.0F;

    public float attackSpeed = 1.9F;
    public bool isMoving = false;
    float headMoveSpeed = 2.0F;

    private float startTime;
    private float sectionStartTime;
    private float journeyLength;
    private Vector2 startPosition;
    private float lastShotTime;
    private Animator anim;
    public ParticleSystem particles;
    int indexToMoveTo = 0;

    public AudioSource movingSound;
    public AudioSource attackSound;

    // Start is called before the first frame update
    void Start()
    {
        attackYValues.Sort();
        this.anim = flowerHead.GetComponent<Animator>();
    }
    void OnEnable() {
        int replay = GameObject.FindWithTag("PlayerManager").GetComponent<CharacterValues>().replayTimes;
        damage = basicDamage + ( 10 * replay );

        flowerHead.transform.position = new Vector2(flowerHead.transform.position.x, attackYValues[1]);
        startTime = Time.time;
        lastShotTime = Time.time;

        startPosition = flowerHead.transform.position;
        journeyLength = Vector2.Distance(flowerHead.transform.position, new Vector2(flowerHead.transform.position.x, attackYValues[0]));
    }
    // Update is called once per frame
    void Update()
    {
        ChangeSection();
        this.MoveToIndex();
        if((flowerHead.transform.position.y + 0.1f > attackYValues[indexToMoveTo]) && (flowerHead.transform.position.y - 0.1f < attackYValues[indexToMoveTo])) {
            isMoving = false;
            if(this.particles.isPlaying) {
                this.particles.Stop();
                movingSound.Stop();
            }
        } else {
            isMoving = true;
            if(this.particles.isStopped) {
                this.particles.Play();
                movingSound.Play();
            }
        }
        Shot();
    }
    void ChangeSection() {
        if(Time.time - sectionStartTime > timeForSection) {
            startTime = Time.time;
            sectionStartTime = Time.time;
            startPosition = flowerHead.transform.position;
            ChangePostionIndex();
            journeyLength = Vector2.Distance(flowerHead.transform.position, new Vector2(flowerHead.transform.position.x, attackYValues[indexToMoveTo]));
        }
    }
    void ChangePostionIndex () {
        Random rnd = new Random();
        if(attackYValues.Count > indexToMoveTo + 1 && indexToMoveTo - 1 >= 0) {
            int random = rnd.Next(1, 3);
            if(random == 1) {
                indexToMoveTo++;
            } else {
                indexToMoveTo--;
            }
        } else if (attackYValues.Count > indexToMoveTo + 1 && indexToMoveTo - 1 < 0) {
            indexToMoveTo++;
        } else if (attackYValues.Count == indexToMoveTo + 1 && indexToMoveTo - 1 >= 0)
        {
            indexToMoveTo--;
        }
    }
    void Shot(){
        if(Time.time - lastShotTime > attackSpeed && !isMoving) {
            attackSound.Play();
            this.anim.Play("Attack");
            lastShotTime = Time.time;
            Invoke("ShotProjectile", 0.15F);
        }
    }
    void ShotProjectile() {
        GameObject projectile = Instantiate(projectilePrefab, shotPoint.transform.position, shotPoint.transform.rotation);
        projectile.GetComponent<EnemyProjectileManager>().Setup(projectileSprite, 10f, damage);
    }
    void MoveToIndex() {
        float distCovered = (Time.time - startTime) * headMoveSpeed;

        float fracJourney = distCovered / journeyLength;

        flowerHead.transform.position = Vector3.Lerp(startPosition, new Vector2(flowerHead.transform.position.x, attackYValues[indexToMoveTo]), fracJourney);
    }
}
