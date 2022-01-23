using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareChestnut : IItem, IItemWeapon
{
  class PossibleValues
  {
    public float minDamage = 10;
    public float maxDamage = 15;

    public float minAttackSpeed = 3;
    public float maxAttackSpeed = 4;
  }
  public RareChestnut(float damageFactor = 0.5f, float attackSpeedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.damage = ((ps.maxDamage - ps.minDamage) * damageFactor) + ps.minDamage;
    this.attackSpeed = ((ps.maxAttackSpeed - ps.minAttackSpeed) * attackSpeedFactor) + ps.minAttackSpeed;

    List<ItemUpgrade> upgradeItem = new List<ItemUpgrade>();
    upgradeItem.Add(new ItemUpgrade(0, 20, 20));
    upgradeItem.Add(new ItemUpgrade(0, 30, 20));
    upgradeItem.Add(new ItemUpgrade(0, 40, 30));
    upgradeItem.Add(new ItemUpgrade(0, 50, 30));
    upgradeItem.Add(new ItemUpgrade(0, 60, 40));

    List<ItemUpgrade> upgradeMoney = new List<ItemUpgrade>();
    upgradeMoney.Add(new ItemUpgrade(1000, 20, 20));
    upgradeMoney.Add(new ItemUpgrade(1200, 30, 20));
    upgradeMoney.Add(new ItemUpgrade(1400, 40, 30));
    upgradeMoney.Add(new ItemUpgrade(1600, 50, 30));
    upgradeMoney.Add(new ItemUpgrade(1800, 60, 30));
    upgradeMoney.Add(new ItemUpgrade(2000, 70, 40));

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
  public string itemName { get { return "Rzadki żolądź"; } }
  public string itemType { get { return "Chestnut"; } }
  public string secondItemType { get { return ""; } }
  public int itemIconID { get { return 32; } set { } }

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
