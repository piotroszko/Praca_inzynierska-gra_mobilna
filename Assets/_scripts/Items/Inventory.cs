using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  public List<IItem> itemList = new List<IItem>();
  bool smthChanged = true;
  public GameObject itemPrefab;

  public GameObject itemInfo;

  private int index = 0;
  public int nextItemIndex
  {
    get { index++; return index; }
  }
  public GameObject inventoryPanel;
  void Awake()
  {
    DontDestroyOnLoad(this.gameObject);
  }
  // Start is called before the first frame update
  void Start()
  {
    this.itemList.Add(new BasicCollar(nextItemIndex));

  }
  void OnEnable()
  {

  }
  // Update is called once per frame
  void Update()
  {
    if (this.smthChanged)
      this.RefreshInventory();
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
        /*
        GO.transform.Find("Amount").GetComponent<UnityEngine.UI.Text>().text = "*";
        GO.transform.Find("ItemName").GetComponent<UnityEngine.UI.Text>().text = item.itemName;
        //GO.transform.Find("Modified").GetComponent<UnityEngine.UI.Text>()
        GO.transform.Find("ItemType").GetComponent<UnityEngine.UI.Text>().text = item.itemType;
        GO.transform.Find("ItemTier").GetComponent<UnityEngine.UI.Text>().text = "T" + item.itemTier.ToString();
        GO.transform.Find("ItemLevel").GetComponent<UnityEngine.UI.Text>().text = item.itemLevel.ToString();*/
        GO.transform.SetParent(this.inventoryPanel.transform);
      }
      this.smthChanged = false;
    }
  }
}
