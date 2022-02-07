using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileManager : MonoBehaviour
{
  float speed;
  int damage;
  bool right = false;
  float timeStart;
  public void Setup(Sprite projectileSprite = null, float speed = 20f, int damage = 18)
  {
    this.speed = speed;
    this.damage = damage;

    if (projectileSprite)
      gameObject.GetComponent<SpriteRenderer>().sprite = projectileSprite;
  }
  void Start()
  {
    timeStart = Time.time;
    Object.Destroy(gameObject, 3f);
  }

  void Update()
  {
    transform.Translate(-(speed * Time.deltaTime), 0, 0);
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      other.gameObject.GetComponent<PlayerCombatController>().DamagePlayer(this.damage);
      Destroy(gameObject);
    } else if ( other.gameObject.tag == "Enemy" && Time.time - timeStart > 0.2f) {
      Destroy(gameObject);
    }
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Ground")
    {
      Destroy(gameObject);
    }else if ( other.gameObject.tag == "Enemy"&& Time.time - timeStart > 0.2f) {
      Destroy(gameObject);
    }

  }
}
