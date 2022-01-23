using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareSeed : IItem, IItemWeapon
{
  class PossibleValues
  {
    public float minDamage = 5;
    public float maxDamage = 8;

    public float minAttackSpeed = 4;
    public float maxAttackSpeed = 6;
  }
  public RareSeed(float damageFactor = 0.5f, float attackSpeedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.damage = ((ps.maxDamage - ps.minDamage) * damageFactor) + ps.minDamage;
    this.attackSpeed = ((ps.maxAttackSpeed - ps.minAttackSpeed) * attackSpeedFactor) + ps.minAttackSpeed;

    List<ItemUpgrade> upgradeItem = new List<ItemUpgrade>();
    upgradeItem.Add(new ItemUpgrade(0, 20, 20));
    upgradeItem.Add(new ItemUpgrade(0, 20, 30));
    upgradeItem.Add(new ItemUpgrade(0, 30, 40));
    upgradeItem.Add(new ItemUpgrade(0, 30, 50));
    upgradeItem.Add(new ItemUpgrade(0, 40, 60));

    List<ItemUpgrade> upgradeMoney = new List<ItemUpgrade>();
    upgradeMoney.Add(new ItemUpgrade(1000, 20, 20));
    upgradeMoney.Add(new ItemUpgrade(1200, 20, 30));
    upgradeMoney.Add(new ItemUpgrade(1400, 30, 40));
    upgradeMoney.Add(new ItemUpgrade(1600, 30, 50));
    upgradeMoney.Add(new ItemUpgrade(1800, 30, 60));
    upgradeMoney.Add(new ItemUpgrade(2000, 40, 70));

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
      return 2;
    }
    set
    {

    }
  }
  public string itemName { get { return "Rzadkie nasiono"; } }
  public string itemType { get { return "Seed"; } }
  public string secondItemType { get { return ""; } }
  public int itemIconID { get { return 22; } set { } }

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
