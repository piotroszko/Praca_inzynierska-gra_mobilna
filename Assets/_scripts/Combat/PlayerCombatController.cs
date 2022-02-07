using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombatController : MonoBehaviour
{
  public GameObject projectilePrefab;
  public Sprite projectileSprite;

  public float speed = 1f;
  float lastThrowDate;

  private Inventory inv;
  private treeUpgrades tree;
  private CharacterValues characterValues;

  public float amountOfJumpsFromLastKill;
  void Start()
  {
    lastThrowDate = Time.time;
    GameObject pm = GameObject.FindWithTag("PlayerManager").gameObject;
    this.inv = pm.GetComponent<Inventory>();
    this.tree = pm.GetComponent<treeUpgrades>();
    this.characterValues = pm.GetComponent<CharacterValues>();
  }
  public void KilledEnemy(float distanceFromKill, float maxHealth) 
  {
    Health hp = GetComponent<Health>();
    if(hp.currentHealth + 10 <= hp.maxHealth) {
      hp.currentHealth += 10;
    }
    float jumpFactor = 0f;
    if(amountOfJumpsFromLastKill < 2)
     jumpFactor = 0f;
    if((amountOfJumpsFromLastKill > 2) && (amountOfJumpsFromLastKill < 10))
     jumpFactor = 0.5f;
    if((amountOfJumpsFromLastKill > 10))
     jumpFactor = 1.0f;
    float distanceFactor = 1.0f;
    if(distanceFromKill < 10f)
      distanceFactor = 0f + ((1.0f - 0f) / (10f - 0f)) * (distanceFromKill - 0f);
    this.inv.AddItemFromDrop(jumpFactor, distanceFactor);
    this.amountOfJumpsFromLastKill = 0;
    this.characterValues.experience += maxHealth;
  }
  public void DamagePlayer(int value)
  {
    float damage = value;
    if (this.tree.nodesOwned.Exists(x => x == 2))
      damage = value * 0.8f;
    damage = (100f / (100f + this.characterValues.pointsDefense)) * damage;
    float def1 = 0f;
    if (this.inv.equippedCollar != null)
    {
      float defTmp1 = this.inv.equippedCollar.defense + (this.inv.equippedCollar.upgradeInfo.sumTypeItem(true) * this.inv.equippedCollar.defense);
      def1 = defTmp1 + (this.inv.equippedCollar.upgradeInfo.sumTypeMoney(true) * defTmp1);
    }
    float def2 = 0f;
    if (this.inv.equippedCoat != null)
    {
      float defTmp2 = this.inv.equippedCoat.defense + (this.inv.equippedCoat.upgradeInfo.sumTypeItem(true) * this.inv.equippedCoat.defense);
      def2 = defTmp2 + (this.inv.equippedCoat.upgradeInfo.sumTypeMoney(true) * defTmp2);
    }
    damage = (100f / (100f + def1 + def2)) * damage;

    gameObject.GetComponent<Health>().Damage(damage);
  }
  public float CalculateAttackSpeed()
  {
    float invSpeed = this.speed;
    if (this.tree.nodesOwned.Exists(x => x == 4))
      invSpeed = this.speed * 0.8f;
    invSpeed = (50f / (50f + this.characterValues.pointsSpeed)) * invSpeed;
    float spd = 0;
    if (this.inv.equippedWeapon != null)
    {
      float spdTmp = this.inv.equippedWeapon.attackSpeed + (this.inv.equippedWeapon.upgradeInfo.sumTypeItem(false) * this.inv.equippedWeapon.attackSpeed);
      spd = spdTmp + (this.inv.equippedWeapon.upgradeInfo.sumTypeMoney(false) * spdTmp);
    }
    invSpeed = (5f / (5f + spd)) * invSpeed;
    return invSpeed;
  }
  public float CalculateDamage()
  {
    float damage = 18f;
    if (this.tree.nodesOwned.Exists(x => x == 1))
      damage = damage * 1.2f;
    damage = ((50f + this.characterValues.pointsStrength) / 50f) * damage;
    float dmg = 0f;
    if (this.inv.equippedWeapon != null)
    {
      float dmgTmp = this.inv.equippedWeapon.damage + (this.inv.equippedWeapon.upgradeInfo.sumTypeItem(true) * this.inv.equippedWeapon.damage);
      dmg = dmgTmp + (this.inv.equippedWeapon.upgradeInfo.sumTypeMoney(true) * dmgTmp);
    }
    damage = ((100f + dmg) / 100f) * damage;
    return damage;
  }
  void Update()
  {
    // if (Input.GetButtonDown("Fire1"))
    // {
    //   this.Shot();
    // }
  }
  public void Shot() {
    if ((Time.time - lastThrowDate > CalculateAttackSpeed() / 2))
      {
        lastThrowDate = Time.time;

        if ((transform.localRotation.eulerAngles.y == 180))
        {
          GameObject projectile = Instantiate(projectilePrefab, GetComponent<Rigidbody2D>().transform.position, Quaternion.Euler(0, 0, -90), transform);
          projectile.GetComponent<ProjectileManager>().Setup(projectileSprite, 20f, CalculateDamage());
          projectile.transform.parent = null;
        }
        else
        {
          GameObject projectile = Instantiate(projectilePrefab, GetComponent<Rigidbody2D>().transform.position, Quaternion.Euler(0, 0, 90), transform);
          projectile.GetComponent<ProjectileManager>().Setup(projectileSprite, 20f, CalculateDamage());
          projectile.transform.parent = null;
        }
      }
  }
}
