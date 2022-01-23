using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendarySeed : IItem, IItemWeapon
{
  class PossibleValues
  {
    public float minDamage = 8;
    public float maxDamage = 15;

    public float minAttackSpeed = 6;
    public float maxAttackSpeed = 10;
  }
  public LegendarySeed(float damageFactor = 0.5f, float attackSpeedFactor = 0.5f)
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
    upgradeItem.Add(new ItemUpgrade(0, 20, 70));
    upgradeItem.Add(new ItemUpgrade(0, 20, 80));
    upgradeItem.Add(new ItemUpgrade(0, 30, 90));
    upgradeItem.Add(new ItemUpgrade(0, 30, 100));
    upgradeItem.Add(new ItemUpgrade(0, 40, 100));

    List<ItemUpgrade> upgradeMoney = new List<ItemUpgrade>();
    upgradeMoney.Add(new ItemUpgrade(3000, 20, 20));
    upgradeMoney.Add(new ItemUpgrade(3400, 20, 30));
    upgradeMoney.Add(new ItemUpgrade(3800, 30, 40));
    upgradeMoney.Add(new ItemUpgrade(4200, 30, 50));
    upgradeMoney.Add(new ItemUpgrade(4600, 30, 60));
    upgradeMoney.Add(new ItemUpgrade(5000, 40, 70));
    upgradeMoney.Add(new ItemUpgrade(6000, 20, 20));
    upgradeMoney.Add(new ItemUpgrade(7000, 20, 30));
    upgradeMoney.Add(new ItemUpgrade(8000, 30, 40));
    upgradeMoney.Add(new ItemUpgrade(9000, 30, 50));
    upgradeMoney.Add(new ItemUpgrade(10000, 30, 60));
    upgradeMoney.Add(new ItemUpgrade(12000, 40, 70));

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
      return 3;
    }
    set
    {

    }
  }
  public string itemName { get { return "Legendarne nasiono"; } }
  public string itemType { get { return "Seed"; } }
  public string secondItemType { get { return ""; } }
  public int itemIconID { get { return 23; } set { } }

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
