using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
  public GameObject projectilePrefab;
  public Sprite projectileSprite;

  public float speed = 1;
  float lastThrowDate;
  void Start()
  {
    lastThrowDate = Time.time;
  }

  void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      if ((Time.time - lastThrowDate > speed / 2))
      {
        lastThrowDate = Time.time;
        if ((transform.localRotation.eulerAngles.y == 180))
        {
          GameObject projectile = Instantiate(projectilePrefab, GetComponent<Rigidbody2D>().transform.position, Quaternion.Euler(0, 0, -90), transform);
          projectile.GetComponent<ProjectileManager>().Setup(projectileSprite);
          projectile.transform.parent = null;
        }
        else
        {
          GameObject projectile = Instantiate(projectilePrefab, GetComponent<Rigidbody2D>().transform.position, Quaternion.Euler(0, 0, 90), transform);
          projectile.GetComponent<ProjectileManager>().Setup(projectileSprite);
          projectile.transform.parent = null;
        }
      }
    }
  }
}
