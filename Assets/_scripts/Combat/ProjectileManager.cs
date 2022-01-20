using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
  float speed;
  bool right = false;
  public void Setup(Sprite projectileSprite = null, float speed = 20)
  {
    this.speed = speed;
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
}
