using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collar : IItem, IItemCollar
{
  class PossibleValues
  {
    public float minDamage = 5;
    public float maxDamage = 5;

    public float minSpeed = 2;
    public float maxSpeed = 2;
  }
  public Collar(float damageFactor = 0.5f, float speedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this.damage = ((ps.maxDamage - ps.minDamage) * damageFactor) + ps.minDamage;
    this.speed = ((ps.maxSpeed - ps.minSpeed) * speedFactor) + ps.minSpeed;

    List<ItemUpgrade> upgradeItem = new List<ItemUpgrade>();
    upgradeItem.Add(new ItemUpgrade(0, 20, 20));

    List<ItemUpgrade> upgradeMoney = new List<ItemUpgrade>();
    upgradeItem.Add(new ItemUpgrade(10, 20, 20));

    UpgradeInfo uInfo = new UpgradeInfo(upgradeItem, upgradeMoney);
  }
  public float _damage;
  public float _speed;
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
  public float speed
  {
    get
    {
      return _speed;
    }
    set
    {
      this._speed = value;
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
  private int index = 1;
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
      return 1;
    }
    set
    {

    }
  }
  public string itemName { get { return "Obroża"; } }
  public string itemType { get { return "Collar"; } }
  public string secondItemType { get { return ""; } }
  public string itemDesc { get { return "Zapewnia najbardziej podstawowe statstyki"; } }
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
