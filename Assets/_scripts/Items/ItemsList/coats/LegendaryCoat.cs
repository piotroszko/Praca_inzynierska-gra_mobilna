using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryCoat : IItem, IItemArmor
{
  class PossibleValues
  {

    public float minDefense = 45;
    public float maxDefense = 70;

    public float minMovementSpeed = 4;
    public float maxMovementSpeed = 5;
  }
  public LegendaryCoat(float defenseFactor = 0.5f, float movementSpeedFactor = 0.5f)
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
      return 3;
    }
    set
    {

    }
  }
  public string itemName { get { return "Legendarny kubrak"; } }
  public string itemType { get { return "Coat"; } }
  public string secondItemType { get { return ""; } }
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
