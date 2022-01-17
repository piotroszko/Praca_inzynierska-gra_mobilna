using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TableFilters : MonoBehaviour
{
  private int nameFilter = 0;
  protected Inventory invComp;

  private int nameState
  {
    get { return nameFilter; }
    set
    {
      nameFilter = value;
      if (value == 0)
      {
        this.gameObject.transform.Find("ItemName").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
      }
      else if (value == 1)
      {
        this.gameObject.transform.Find("ItemName").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp();
        this.invComp.itemList.OrderBy(x => x.itemName);
        this.invComp.RefreshInventory();
      }
      else if (value == 2)
      {
        this.gameObject.transform.Find("ItemName").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown();
        this.invComp.itemList.OrderByDescending(x => x.itemName);
        this.invComp.RefreshInventory();
      }
    }
  }
  private int type = 0;
  private int typeState
  {
    get { return type; }
    set
    {
      type = value;
      if (value == 0)
      {
        this.gameObject.transform.Find("ItemType").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
      }
      else if (value == 1)
      {
        this.gameObject.transform.Find("ItemType").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp();
        this.invComp.itemList.OrderBy(x => x.itemType);
        this.invComp.RefreshInventory();
      }
      else if (value == 2)
      {
        this.gameObject.transform.Find("ItemType").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown();
        this.invComp.itemList.OrderByDescending(x => x.itemType);
        this.invComp.RefreshInventory();
      }
    }
  }
  private int level = 0;
  private int levelState
  {
    get { return level; }
    set
    {
      level = value;
      if (value == 0)
      {
        this.gameObject.transform.Find("ItemLevel").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
      }
      else if (value == 1)
      {
        this.gameObject.transform.Find("ItemLevel").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp();
        this.invComp.itemList.OrderBy(x => x.itemLevel);
        this.invComp.RefreshInventory();
      }
      else if (value == 2)
      {
        this.gameObject.transform.Find("ItemLevel").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown();
        this.invComp.itemList.OrderByDescending(x => x.itemLevel);
        this.invComp.RefreshInventory();
      }
    }
  }
  private int tier = 0;
  private int tierState
  {
    get { return tier; }
    set
    {
      tier = value;
      if (value == 0)
      {
        this.gameObject.transform.Find("ItemTier").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
      }
      else if (value == 1)
      {
        this.gameObject.transform.Find("ItemTier").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp();
        this.invComp.itemList.OrderBy(x => x.itemTier);
        this.invComp.RefreshInventory();
      }
      else if (value == 2)
      {
        this.gameObject.transform.Find("ItemTier").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown();
        this.invComp.itemList.OrderByDescending(x => x.itemTier);
        this.invComp.RefreshInventory();
      }
    }
  }
  //this.gameObject.transform.Find("Amount").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp();
  public void ChangeFilter(string filterName)
  {
    if (filterName == "name")
    {
      if (this.nameState == 0 || this.nameState == 2)
      {
        this.nameState = 1;
        this.typeState = 0;
        this.levelState = 0;
        this.tierState = 0;
      }
      else
      {
        this.nameState = 2;
        this.typeState = 0;
        this.levelState = 0;
        this.tierState = 0;
      }
    }
    else if (filterName == "type")
    {
      if (this.typeState == 0 || this.typeState == 2)
      {
        this.nameState = 0;
        this.typeState = 1;
        this.levelState = 0;
        this.tierState = 0;
      }
      else
      {
        this.nameState = 0;
        this.typeState = 2;
        this.levelState = 0;
        this.tierState = 0;
      }
    }
    else if (filterName == "level")
    {
      if (this.levelState == 0 || this.levelState == 2)
      {
        this.nameState = 0;
        this.typeState = 0;
        this.levelState = 1;
        this.tierState = 0;
      }
      else
      {
        this.nameState = 0;
        this.typeState = 0;
        this.levelState = 2;
        this.tierState = 0;
      }
    }
    else if (filterName == "tier")
    {
      if (this.tierState == 0 || this.tierState == 2)
      {
        this.nameState = 0;
        this.typeState = 0;
        this.levelState = 0;
        this.tierState = 1;
      }
      else
      {
        this.nameState = 0;
        this.typeState = 0;
        this.levelState = 0;
        this.tierState = 2;
      }
    }
  }
  // Start is called before the first frame update
  void Start()
  {
    this.invComp = GameObject.FindWithTag("PlayerManager").GetComponent<Inventory>();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
