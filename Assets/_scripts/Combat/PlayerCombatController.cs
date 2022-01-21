using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
  public GameObject projectilePrefab;
  public Sprite projectileSprite;

  public float speed = 1;
  float lastThrowDate;

  private GameObject pm;
  void Start()
  {
    lastThrowDate = Time.time;
    this.pm = GameObject.FindWithTag("PlayerManager").gameObject;
  }
  public void DamagePlayer(int value)
  {
    float damage = value;
    if (pm.GetComponent<treeUpgrades>().nodesOwned.Exists(x => x == 2))
      damage = value * 0.8f;
    damage = (100f / (100f + pm.GetComponent<CharacterValues>().pointsDefense)) * damage;
    Inventory inv = pm.GetComponent<Inventory>();
    float def1 = 0f;
    if (inv.equippedCollar != null)
    {
      float defTmp1 = inv.equippedCollar.defense + (inv.equippedCollar.upgradeInfo.sumTypeItem(true) * inv.equippedCollar.defense);
      def1 = defTmp1 + (inv.equippedCollar.upgradeInfo.sumTypeMoney(true) * defTmp1);
    }
    float def2 = 0f;
    if (inv.equippedCoat != null)
    {
      float defTmp2 = inv.equippedCoat.defense + (inv.equippedCoat.upgradeInfo.sumTypeItem(true) * inv.equippedCoat.defense);
      def2 = defTmp2 + (inv.equippedCoat.upgradeInfo.sumTypeMoney(true) * defTmp2);
    }
    damage = (100f / (100f + def1 + def2)) * damage;

    gameObject.GetComponent<Health>().Damage(damage);
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
