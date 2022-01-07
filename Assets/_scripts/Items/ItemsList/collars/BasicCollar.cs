using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollar : IItem, IItemCollar
{
  class PossibleValues
  {
    public float minDamage = 3;
    public float maxDamage = 3;

    public float minSpeed = 1;
    public float maxSpeed = 1;
  }
  public BasicCollar(float damageFactor = 0.5f, float speedFactor = 0.5f)
  {
    PossibleValues ps = new PossibleValues();
    this._damage = ((ps.maxDamage - ps.minDamage) * damageFactor) + ps.minDamage;
    this._speed = ((ps.maxSpeed - ps.minSpeed) * speedFactor) + ps.minSpeed;

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
  private int index = 0;
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
      return 0;
    }
    set
    {

    }
  }
  public string itemName { get { return "Podstawowa obroża"; } }
  public string itemType { get { return "Collar"; } }
  public string secondItemType { get { return ""; } }
  public string itemDesc { get { return "Najbardziej podstawowa obroża"; } }
  public int itemIconID { get { return 0; } set { } }
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
