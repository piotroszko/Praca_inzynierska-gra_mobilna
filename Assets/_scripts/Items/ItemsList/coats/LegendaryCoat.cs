using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryCoat : IItem, IItemArmor
{
  class PossibleValues
  {
    public float minDefense = 9;
    public float maxDefense = 15;

    public float minMovementSpeed = 5;
    public float maxMovementSpeed = 10;
  }
  public LegendaryCoat(float defenseFactor = 0.5f, float movementSpeedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.defense = ((ps.maxDefense - ps.minDefense) * defenseFactor) + ps.minDefense;
    this.movementSpeed = ((ps.maxMovementSpeed - ps.minMovementSpeed) * movementSpeedFactor) + ps.minMovementSpeed;

    List<ItemUpgrade> upgradeItem = new List<ItemUpgrade>();
    upgradeItem.Add(new ItemUpgrade(0, 20, 20));

    List<ItemUpgrade> upgradeMoney = new List<ItemUpgrade>();
    upgradeMoney.Add(new ItemUpgrade(10, 20, 20));

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
  public string itemName { get { return "Legendarny kubrak"; } }
  public string itemType { get { return "Coat"; } }
  public string secondItemType { get { return ""; } }
  public string itemDesc { get { return "Zapewnia niestandardowe statystyki"; } }
  public int itemIconID { get { return 13; } set { } }

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
