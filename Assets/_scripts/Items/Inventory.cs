using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
using System;

public class Inventory : MonoBehaviour
{
  public List<IItem> itemList = new List<IItem>();
  bool smthChanged = true;
  public GameObject itemPrefab;
  public GameObject itemUpgradePrefab;

  public GameObject itemInfo;

  public GameObject inventoryPanel;
  public GameObject inventoryUpgradePanel;

  public IItemArmor equippedCollar;
  public IItemArmor equippedCoat;
  public IItemWeapon equippedWeapon;

  public bool betterSpeedValues = false;
  public bool betterDmgDefValues = false;
  void Awake()
  {
    DontDestroyOnLoad(this.gameObject);
  }
  public void Equipe(IItem item)
  {
    if (item is IItemWeapon)
    {
      IItemWeapon weapon = (IItemWeapon)item;
      if (this.equippedWeapon == weapon)
        this.equippedWeapon = null;
      else
        this.equippedWeapon = weapon;
    }
    else if (item is IItemArmor)
    {
      IItemArmor armor = item as IItemArmor;
      if (item.itemType == "Collar")
      {
        if (this.equippedCollar == armor)
          this.equippedCollar = null;
        else
          this.equippedCollar = armor;
      }
      else if (item.itemType == "Coat")
      {
        if (this.equippedCoat == armor)
          this.equippedCoat = null;
        else
          this.equippedCoat = armor;
      }
    }
  }
  public void DeleteItem(IItem item)
  {
    EquipeManager eq = GameObject.FindWithTag("Equiped").GetComponent<EquipeManager>();
    if (item == this.equippedCoat)
    {
      this.equippedCoat = null;
      eq.ClearCoat();
    }
    else if (item == this.equippedCollar)
    {
      this.equippedCollar = null;
      eq.ClearCollar();
    }
    else if (item == this.equippedCoat)
    {
      this.equippedCoat = null;
      eq.ClearCoat();
    }
    this.itemList.Remove(item);
  }
  void Start()
  {

  }
  void Update()
  {
    if (this.smthChanged)
    {
      this.RefreshInventory();
      this.RefreshUpgradeInventory();
    }
  }
  public void AddItem(IItem item)
  {
    this.itemList.Add(item);
    gameObject.GetComponent<StatisticsValues>().statsItems++;
  }
  public void AddItemFromDrop(float jFactor, float dFactor)
  {
    float jumpFactor = (float)Math.Round(jFactor, 2);
    if(this.betterDmgDefValues == true && jumpFactor < 0.5f)
      jumpFactor = jumpFactor * 2f;
    else if (this.betterDmgDefValues == true && jumpFactor >= 0.5f)
      jumpFactor = 1.0f;

    float distanceFactor = (float)Math.Round(dFactor, 2);
    if(this.betterSpeedValues == true && distanceFactor < 0.5f)
      distanceFactor = distanceFactor * 2f;
    else if (this.betterSpeedValues == true && distanceFactor >= 0.5f)
      distanceFactor = 1.0f;
    Random rnd = new Random();
    if(rnd.Next(1, 100) > 70) 
    {
      int itemRarity = rnd.Next(1, 100);
      if(itemRarity < 50) 
      {
        int itemType = rnd.Next(1, 100);  
        if((itemRarity >= 1) && (itemRarity < 25)) {
          this.itemList.Add(new BasicCollar(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;

        } else if ((itemRarity >= 25) && (itemRarity < 50)) {
          this.itemList.Add(new BasicCoat(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;

        } else if ( (itemRarity >= 50) && (itemRarity < 75)) {
          this.itemList.Add(new BasicChestnut(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;

        } else if ( (itemRarity >= 75) && (itemRarity < 100)) {
          this.itemList.Add(new BasicSeed(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        }
      } else if( (itemRarity >= 50) && (itemRarity < 75)) {
        int itemType = rnd.Next(1, 100);  
        if( (itemRarity >= 1) && (itemRarity < 25)) {
          this.itemList.Add(new Collar(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 25) && (itemRarity < 50)) {
          this.itemList.Add(new Coat(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 50) && (itemRarity < 75)) {
          this.itemList.Add(new Chestnut(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 75) && (itemRarity < 100)) {
          this.itemList.Add(new Seed(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        }
      } else if ((itemRarity >= 75) && (itemRarity < 90)) {
        int itemType = rnd.Next(1, 100);  
        if( (itemRarity >= 1) && (itemRarity < 25)) {
          this.itemList.Add(new RareCollar(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 25) && (itemRarity < 50)) {
          this.itemList.Add(new RareCoat(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 50) && (itemRarity < 75)) {
          this.itemList.Add(new RareChestnut(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 75) && (itemRarity < 100)) {
          this.itemList.Add(new RareSeed(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        }
      }else if ((itemRarity >= 90) && (itemRarity < 100)) {
        int itemType = rnd.Next(1, 100);  
        if( (itemRarity >= 1) && (itemRarity < 25)) {
          this.itemList.Add(new LegendaryCollar(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 25) && (itemRarity < 50)) {
          this.itemList.Add(new LegendaryCoat(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 50) && (itemRarity < 75)) {
          this.itemList.Add(new LegendaryChestnut(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        } else if ( (itemRarity >= 75) && (itemRarity < 100)) {
          this.itemList.Add(new LegendarySeed(jumpFactor, distanceFactor));
          gameObject.GetComponent<StatisticsValues>().statsItems++;
        }
      }
    }
  }
  public void RefreshInventory()
  {
    if (this.inventoryPanel.activeSelf)
    {
      GameObject[] invItems = GameObject.FindGameObjectsWithTag("InventoryItem");
      foreach (GameObject item in invItems)
      {
        GameObject.Destroy(item);
      }
      foreach (IItem item in itemList)
      {
        GameObject GO = Instantiate(itemPrefab);
        GO.transform.GetComponent<InventorySlot>().setItemFromIItem(item);
        GO.transform.SetParent(this.inventoryPanel.transform);
      }
      this.smthChanged = false;
    }
  }
  public void RefreshUpgradeInventory()
  {
    if (this.inventoryUpgradePanel.activeSelf)
    {
      GameObject[] invItems = GameObject.FindGameObjectsWithTag("UpgradeItem");
      foreach (GameObject item in invItems)
      {
        GameObject.Destroy(item);
      }
      foreach (IItem item in itemList)
      {
        GameObject GO = Instantiate(this.itemUpgradePrefab);
        GO.transform.GetComponent<UpgradeSlot>().setItemFromIItem(item);
        GO.transform.SetParent(this.inventoryUpgradePanel.transform);
      }
      this.smthChanged = false;
    }
  }
}
