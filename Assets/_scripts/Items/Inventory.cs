using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    this.itemList.Add(new BasicCollar());
    this.itemList.Add(new Collar());
    this.itemList.Add(new LegendaryCollar());
    this.itemList.Add(new BasicSeed());
    this.itemList.Add(new RareCoat());

    this.itemList.Add(new BasicCollar());

  }
  void Update()
  {
    if (this.smthChanged)
    {
      this.RefreshInventory();
      this.RefreshUpgradeInventory();
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
