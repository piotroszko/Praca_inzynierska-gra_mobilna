using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareCoat : IItem, IItemArmor
{
  class PossibleValues
  {
    public float minDefense = 25;
    public float maxDefense = 45;

    public float minMovementSpeed = 3;
    public float maxMovementSpeed = 3;
  }
  public RareCoat(float defenseFactor = 0.5f, float movementSpeedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.defense = ((ps.maxDefense - ps.minDefense) * defenseFactor) + ps.minDefense;
    this.movementSpeed = ((ps.maxMovementSpeed - ps.minMovementSpeed) * movementSpeedFactor) + ps.minMovementSpeed;

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
  public string itemName { get { return "Rzadki kubrak"; } }
  public string itemType { get { return "Coat"; } }
  public string secondItemType { get { return ""; } }
  public int itemIconID { get { return 12; } set { } }

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
