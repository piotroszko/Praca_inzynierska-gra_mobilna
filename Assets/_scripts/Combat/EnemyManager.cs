using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  public float maxHealth = 100f;
  private float _health = 1f;
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
  // Start is called before the first frame update
  void Start()
  {
    _health = maxHealth;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
