using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : IItem, IItemWeapon
{
  class PossibleValues
  {
    public float minDamage = 4;
    public float maxDamage = 7;

    public float minAttackSpeed = 3;
    public float maxAttackSpeed = 5;
  }
  public Seed(float damageFactor = 0.5f, float attackSpeedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.damage = ((ps.maxDamage - ps.minDamage) * damageFactor) + ps.minDamage;
    this.attackSpeed = ((ps.maxAttackSpeed - ps.minAttackSpeed) * attackSpeedFactor) + ps.minAttackSpeed;

    List<ItemUpgrade> upgradeItem = new List<ItemUpgrade>();
    upgradeItem.Add(new ItemUpgrade(0, 20, 20));
    upgradeItem.Add(new ItemUpgrade(0, 20, 30));
    upgradeItem.Add(new ItemUpgrade(0, 20, 40));

    List<ItemUpgrade> upgradeMoney = new List<ItemUpgrade>();
    upgradeMoney.Add(new ItemUpgrade(250, 20, 20));
    upgradeMoney.Add(new ItemUpgrade(300, 20, 30));
    upgradeMoney.Add(new ItemUpgrade(350, 20, 40));
    upgradeMoney.Add(new ItemUpgrade(400, 20, 50));

    UpgradeInfo uInfo = new UpgradeInfo(upgradeItem, upgradeMoney);
    this.upgradeInfo = uInfo;
  }
  public float _damage;
  public float _attackSpeed;
  public float damage
  {
    get
    {
      return _damage;
    }
    set
    {
      this._damage = value;
    }
  }
  public float attackSpeed
  {
    get
    {
      return _attackSpeed;
    }
    set
    {
      this._attackSpeed = value;
    }
  }

  public bool stackable()
  {
    return false;
  }
  private int _itemTier = 0;
  public int itemTier
  {
    get
    {
      return _itemTier;
    }
    set
    {
      this._itemTier = value;
    }
  }
  private int _itemLevel = 1;
  public int itemLevel
  {
    get
    {
      return this._itemLevel;
    }
    set
    {
      _itemLevel = value;
    }
  }

  public int itemRarity
  {
    get
    {
      return 1;
    }
    set
    {

    }
  }
  public string itemName { get { return "Nasiono"; } }
  public string itemType { get { return "Seed"; } }
  public string secondItemType { get { return ""; } }
  public int itemIconID { get { return 21; } set { } }

  UpgradeInfo _upgradeInfo;
  public UpgradeInfo upgradeInfo
  {
    get
    {
      return _upgradeInfo;
    }
    set
    {
      _upgradeInfo = value;
    }
  }
}
