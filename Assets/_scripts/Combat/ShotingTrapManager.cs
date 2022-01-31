using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingTrapManager : MonoBehaviour
{

  [SerializeField] GameObject projectilePrefab;
  [SerializeField] Sprite projectileSprite;
  [SerializeField] int damage = 18;
  float lastAttackDate;
  float attackSpeed = 2f;

  public void Attack() 
  {
    GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation *  Quaternion.Euler(0, 0, 0), transform);
    projectile.GetComponent<EnemyProjectileManager>().Setup(projectileSprite, 10f);
  }
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    if((Time.time - lastAttackDate > attackSpeed)) {
        lastAttackDate = Time.time;
        Attack();
    }
  }
}
