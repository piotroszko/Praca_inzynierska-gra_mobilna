using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collar : IItem, IItemArmor
{
  class PossibleValues
  {
    public float minDefense = 5;
    public float maxDefense = 7;

    public float minMovementSpeed = 4;
    public float maxMovementSpeed = 7;
  }
  public Collar(float defenseFactor = 0.5f, float movementSpeedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.defense = ((ps.maxDefense - ps.minDefense) * defenseFactor) + ps.minDefense;
    this.movementSpeed = ((ps.maxMovementSpeed - ps.minMovementSpeed) * movementSpeedFactor) + ps.minMovementSpeed;

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
      return 1;
    }
    set
    {

    }
  }
  public string itemName { get { return "Obroża"; } }
  public string itemType { get { return "Collar"; } }
  public string secondItemType { get { return ""; } }
  public int itemIconID { get { return 1; } set { } }

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
