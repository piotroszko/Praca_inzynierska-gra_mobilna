using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  public bool isRanged = false;

  public float basicHealth = 100f;
  private float maxHealth = 1f;
  private float _health = 1f;

  [SerializeField] GameObject projectilePrefab;
  [SerializeField] Sprite projectileSprite;
  [SerializeField] public int basicDamage = 18;
  public int damage = 1;
  public float health
  {
    get { return _health; }
    set
    {
      _health = value; if (_health <= 0)
      {
        float distance = Vector2.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);
        GameObject.FindWithTag("Player").GetComponent<PlayerCombatController>().KilledEnemy(distance, maxHealth);
        Destroy(gameObject);
      }
    }
  }
  public void Attack() 
  {
    if(isRanged) 
    {
      GameObject projectile = Instantiate(projectilePrefab, GetComponent<Rigidbody2D>().transform.position, transform.rotation , transform);
      projectile.GetComponent<EnemyProjectileManager>().Setup(projectileSprite, 10f);
    } else {
      GameObject.FindWithTag("Player").GetComponent<PlayerCombatController>().DamagePlayer(this.damage);
    }
  }
  // Start is called before the first frame update
  void Start()
  {
  }

  void OnEnable(){
    int replay = GameObject.FindWithTag("PlayerManager").GetComponent<CharacterValues>().replayTimes;
    maxHealth = basicHealth + ( basicHealth/2 * replay);
    _health = maxHealth;
    damage = basicDamage + (10 * replay);
  }
  // Update is called once per frame
  void Update()
  {

  }
}
