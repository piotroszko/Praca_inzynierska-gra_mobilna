using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
  bool stackable();
  int itemTier { get; set; }
  int itemLevel { get; set; }
  int itemRarity { get; set; }
  int itemIconID { get; set; }

  string itemName { get; }
  string itemType { get; }
  string secondItemType { get; }
}
public interface IItemWeapon
{
  float damage { get; set; }
  float attackSpeed { get; set; }
  UpgradeInfo upgradeInfo { get; set; }
}
public interface IItemArmor
{
  float defense { get; set; }
  float movementSpeed { get; set; }
  UpgradeInfo upgradeInfo { get; set; }
}
public class UpgradeInfo
{
  public List<ItemUpgrade> upgradesTypeItem;
  public List<ItemUpgrade> upgradesTypeMoney;
  public int boughtTypeItem = 0; //wskazuje idex upgradu ktory jest teraz do kupienia (poprzednie kupione)
  public int boughtTypeMoney = 0; //wskazuje idex upgradu ktory jest teraz do kupienia (poprzednie kupione)


  public UpgradeInfo()
  {
    this.upgradesTypeItem = new List<ItemUpgrade>();
    this.upgradesTypeMoney = new List<ItemUpgrade>();
  }
  public UpgradeInfo(List<ItemUpgrade> _upgradesTypeItem, List<ItemUpgrade> _upgradesTypeMoney)
  {
    this.upgradesTypeItem = _upgradesTypeItem;
    this.upgradesTypeMoney = _upgradesTypeMoney;
  }
  public float sumTypeItem(bool forStat1)
  {
    float sum = 0f;
    if (forStat1)
    {
      for (int i = 0; i < this.boughtTypeItem; i++)
      {
        sum = sum + upgradesTypeItem[i].upgradeToStat1 / 100f;
      }
    }
    else
    {
      for (int i = 0; i < this.boughtTypeItem; i++)
      {
        sum = sum + upgradesTypeItem[i].upgradeToStat2 / 100f;
      }
    }

    return sum;
  }
  public float sumTypeMoney(bool forStat1)
  {
    float sum = 0f;
    if (forStat1)
    {
      for (int i = 0; i < this.boughtTypeMoney; i++)
      {
        sum = sum + upgradesTypeMoney[i].upgradeToStat1 / 100f;
      }
    }
    else
    {
      for (int i = 0; i < this.boughtTypeMoney; i++)
      {
        sum = sum + upgradesTypeMoney[i].upgradeToStat2 / 100f;
      }
    }
    return sum;
  }

  public override string ToString()
  {
    return "Index b item: " + this.boughtTypeItem.ToString() + " , Index b money:" + boughtTypeMoney.ToString();
  }
}
public class ItemUpgrade
{
  public int upgradeCost = 0; //amount of money for upgrade (stay 0 if items)
  public int upgradeToStat1 = 0;
  public int upgradeToStat2 = 0;

  public ItemUpgrade(int upgradeCost, int upgradeToStat1, int upgradeToStat2)
  {
    this.upgradeCost = upgradeCost;
    this.upgradeToStat1 = upgradeToStat1;
    this.upgradeToStat2 = upgradeToStat2;
  }
}