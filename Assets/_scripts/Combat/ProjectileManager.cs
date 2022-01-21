using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
  float speed;
  float damage;
  bool right = false;
  public void Setup(Sprite projectileSprite = null, float speed = 20f, float damage = 18f)
  {
    this.speed = speed;
    this.damage = damage;
    if (projectileSprite)
      gameObject.GetComponent<SpriteRenderer>().sprite = projectileSprite;
  }
  void Start()
  {
    Object.Destroy(gameObject, 0.8f);
    if (transform.localRotation.eulerAngles.z == 90)
      this.right = true;

  }

  void Update()
  {
    if (right)
      transform.Translate((-transform.right * speed * Time.deltaTime));
    else
      transform.Translate((transform.right * speed * Time.deltaTime));
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      other.gameObject.GetComponent<EnemyManager>().health -= this.damage;
      Destroy(gameObject);
    }
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Ground")
    {
      Destroy(gameObject);
    }

  }
}
