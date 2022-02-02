using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBossProjectile : MonoBehaviour
{
  float speed;
  int damage;
  bool right = false;
  public void Setup(int damage = 18)
  {
    this.damage = damage;
  }
  void Start()
  {
    Object.Destroy(gameObject, 5f);

  }

  void Update()
  {
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Spikes")
    {
      Destroy(gameObject);
    }
    if(other.gameObject.tag == "Player") {
      if(other.gameObject.GetComponent<PlayerCombatController>() != null)
        other.gameObject.GetComponent<PlayerCombatController>().DamagePlayer(this.damage);
      Destroy(gameObject);
    }

  }
}
