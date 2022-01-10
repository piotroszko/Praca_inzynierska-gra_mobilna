using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSlot : MonoBehaviour
{
  protected IItem myItemObject;
  protected GameObject itemInfoGameObject;

  private bool sble;
  public bool stackable
  {
    get { return sble; }
    set
    {
      sble = value;
    }
  }
  private int index;
  public int itemIndex
  {
    get { return index; }
    set
    {
      index = value;
    }
  }

  private int tier;
  public int itemTier
  {
    get { return tier; }
    set
    {
      tier = value;
      this.gameObject.transform.Find("ItemTier").GetComponent<UnityEngine.UI.Text>().text = "T" + value.ToString();
    }
  }

  private int level;
  public int itemLevel
  {
    get { return level; }
    set
    {
      level = value;
      this.gameObject.transform.Find("ItemLevel").GetComponent<UnityEngine.UI.Text>().text = value.ToString();
    }
  }

  private string rarity;
  public string itemRarity
  {
    get { return rarity; }
    set
    {
      rarity = value;
    }
  }

  private string nameSlot;
  public string itemName
  {
    get { return nameSlot; }
    set
    {
      nameSlot = value;
      this.gameObject.transform.Find("ItemName").GetComponent<UnityEngine.UI.Text>().text = value;
    }
  }

  private string type;
  public string itemType
  {
    get { return type; }
    set
    {
      type = value;
      this.gameObject.transform.Find("ItemType").GetComponent<UnityEngine.UI.Text>().text = value;
    }
  }

  private string secondType;
  public string secondItemType
  {
    get { return secondType; }
    set
    {
      secondType = value;
    }
  }

  private string desc;
  public string itemDesc
  {
    get { return desc; }
    set
    {
      desc = value;
    }
  }
  public void setItemFromIItem(IItem item)
  {
    this.myItemObject = item;
    this.stackable = item.stackable();
    this.itemTier = item.itemTier;
    this.itemLevel = item.itemLevel;
    switch (item.itemRarity)
    {
      case 0:
        this.itemRarity = "Podstawowy";
        break;
      case 1:
        this.itemRarity = "Normalny";
        break;
      case 2:
        this.itemRarity = "Rzadki";
        break;
      case 3:
        this.itemRarity = "Legendarny";
        break;
      default:
        this.itemRarity = "Normalny";
        break;
    }
    this.itemName = item.itemName;
    this.itemType = item.itemType;
    this.secondItemType = item.secondItemType;
    this.itemDesc = item.itemDesc;
  }
  public void ItemClick()
  {
    this.itemInfoGameObject.GetComponent<UpgradeInfoManager>().SetItemInfo(this.myItemObject);

  }
  // Start is called before the first frame update
  void Start()
  {
    this.itemInfoGameObject = GameObject.FindWithTag("UpgradeInfo");
  }
  // Update is called once per frame
  void Update()
  {

  }
}
