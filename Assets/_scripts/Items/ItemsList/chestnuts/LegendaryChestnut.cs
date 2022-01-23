using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryChestnut : IItem, IItemWeapon
{
  class PossibleValues
  {
    public float minDamage = 15;
    public float maxDamage = 35;

    public float minAttackSpeed = 4;
    public float maxAttackSpeed = 5;
  }
  public LegendaryChestnut(float damageFactor = 0.5f, float attackSpeedFactor = 0.5f)
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
    upgradeItem.Add(new ItemUpgrade(0, 70, 20));
    upgradeItem.Add(new ItemUpgrade(0, 80, 20));
    upgradeItem.Add(new ItemUpgrade(0, 90, 30));
    upgradeItem.Add(new ItemUpgrade(0, 100, 30));
    upgradeItem.Add(new ItemUpgrade(0, 100, 40));

    List<ItemUpgrade> upgradeMoney = new List<ItemUpgrade>();
    upgradeMoney.Add(new ItemUpgrade(3000, 20, 20));
    upgradeMoney.Add(new ItemUpgrade(3400, 30, 20));
    upgradeMoney.Add(new ItemUpgrade(3800, 40, 30));
    upgradeMoney.Add(new ItemUpgrade(4200, 50, 30));
    upgradeMoney.Add(new ItemUpgrade(4600, 60, 30));
    upgradeMoney.Add(new ItemUpgrade(5000, 70, 40));
    upgradeMoney.Add(new ItemUpgrade(6000, 20, 20));
    upgradeMoney.Add(new ItemUpgrade(7000, 30, 20));
    upgradeMoney.Add(new ItemUpgrade(8000, 40, 30));
    upgradeMoney.Add(new ItemUpgrade(9000, 50, 30));
    upgradeMoney.Add(new ItemUpgrade(10000, 60, 40));
    upgradeMoney.Add(new ItemUpgrade(12000, 70, 50));

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
  public string itemName { get { return "Legendarny żolądź"; } }
  public string itemType { get { return "Chestnut"; } }
  public string secondItemType { get { return ""; } }
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
