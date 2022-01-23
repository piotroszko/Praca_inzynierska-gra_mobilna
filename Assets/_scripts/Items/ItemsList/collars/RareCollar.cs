using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareCollar : IItem, IItemArmor
{
  class PossibleValues
  {
    public float minDefense = 7;
    public float maxDefense = 10;

    public float minMovementSpeed = 7;
    public float maxMovementSpeed = 10;
  }
  public RareCollar(float defenseFactor = 0.5f, float movementSpeedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.defense = ((ps.maxDefense - ps.minDefense) * defenseFactor) + ps.minDefense;
    this.movementSpeed = ((ps.maxMovementSpeed - ps.minMovementSpeed) * movementSpeedFactor) + ps.minMovementSpeed;

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
  public float _defense;
  public float _movementSpeed;
  public float defense
  {
    get
    {
      return _defense;
    }
    set
    {
      this._defense = value;
    }
  }
  public float movementSpeed
  {
    get
    {
      return _movementSpeed;
    }
    set
    {
      this._movementSpeed = value;
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
  public string itemName { get { return "Rzadka obroża"; } }
  public string itemType { get { return "Collar"; } }
  public string secondItemType { get { return ""; } }
  public int itemIconID { get { return 2; } set { } }

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
