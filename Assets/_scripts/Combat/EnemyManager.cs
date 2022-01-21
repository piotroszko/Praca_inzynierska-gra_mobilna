using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  private int _health = 100;
  public int health
  {
    get { return _health; }
    set
    {
      _health = value; if (_health <= 0)
      {
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
