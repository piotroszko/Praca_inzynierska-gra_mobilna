using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  private float _health = 100;
  public float health
  {
    get { return _health; }
    set
    {
      _health = value; if (_health <= 0)
      {
        float distance = Vector2.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);
        GameObject.FindWithTag("Player").GetComponent<PlayerCombatController>().KilledEnemy(distance);
        Destroy(gameObject);
      }
    }
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
