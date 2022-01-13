using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryChestnut : IItem, IItemWeapon
{
  class PossibleValues
  {
    public float minDamage = 9;
    public float maxDamage = 15;

    public float minAttackSpeed = 5;
    public float maxAttackSpeed = 10;
  }
  public LegendaryChestnut(float damageFactor = 0.5f, float attackSpeedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.damage = ((ps.maxDamage - ps.minDamage) * damageFactor) + ps.minDamage;
    this.attackSpeed = ((ps.maxAttackSpeed - ps.minAttackSpeed) * attackSpeedFactor) + ps.minAttackSpeed;

    List<ItemUpgrade> upgradeItem = new List<ItemUpgrade>();
    upgradeItem.Add(new ItemUpgrade(0, 20, 20));

    List<ItemUpgrade> upgradeMoney = new List<ItemUpgrade>();
    upgradeMoney.Add(new ItemUpgrade(10, 20, 20));

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
  public int itemTier
  {
    get
    {
      return 0;
    }
    set { }
  }
  public int itemLevel
  {
    get
    {
      return 1;
    }
    set
    {
      itemLevel = value;
    }
  }
  private int index = 3;
  public int itemIndex
  {
    get
    {
      return index;
    }
    set
    {
      index = value;
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
  public string itemName { get { return "Legendarny żolądź"; } }
  public string itemType { get { return "Chestnut"; } }
  public string secondItemType { get { return ""; } }
  public string itemDesc { get { return "Zapewnia niestandardowe statystyki"; } }
  public int itemIconID { get { return 33; } set { } }

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
