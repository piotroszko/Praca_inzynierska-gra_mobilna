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

  private int index = 0;
  public int nextItemIndex
  {
    get { index++; return index; }
  }
  public GameObject inventoryPanel;
  public GameObject inventoryUpgradePanel;
  void Awake()
  {
    DontDestroyOnLoad(this.gameObject);
  }
  void Start()
  {
    this.itemList.Add(new BasicCollar(nextItemIndex));

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
