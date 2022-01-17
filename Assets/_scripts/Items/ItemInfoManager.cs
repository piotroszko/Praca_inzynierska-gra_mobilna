using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoManager : MonoBehaviour
{
  ItemsIcons iconScript;
  IItem cItem;
  // Start is called before the first frame update
  void Start()
  {
    findPlayerManager();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public void SetItemInfo(IItem item)
  {
    this.cItem = item;
    if (this.iconScript.itemsIcons.Exists(x => x.itemID == item.itemIconID))
    {
      this.gameObject.transform.Find("ItemImage").GetComponent<Image>().sprite =
      this.iconScript.itemsIcons.Find(x => x.itemID == item.itemIconID).itemIcon;
    }
    else
    {
      this.gameObject.transform.Find("ItemImage").GetComponent<Image>().sprite =
      this.iconScript.defaultIcon;
    }
    string rarity = "";
    switch (item.itemRarity)
    {
      case 0:
        rarity = "Podstawowy";
        break;
      case 1:
        rarity = "Normalny";
        break;
      case 2:
        rarity = "Rzadki";
        break;
      case 3:
        rarity = "Legendarny";
        break;
      default:
        rarity = "Normalny";
        break;
    }
    string type = "";
    switch (item.itemType)
    {
      case "Collar":
        type = "Obroża";
        break;
      case "Seed":
        type = "Nasiono";
        break;
      case "Coat":
        type = "Kubraczek";
        break;
      default:
        type = "";
        break;
    }
    string statDesc = "";
    if (item is IItemWeapon)
    {
      Debug.Log("Broń");
      IItemWeapon weapon = item as IItemWeapon;
      statDesc = "Obrażenia: " + weapon.damage.ToString() + System.Environment.NewLine + "Szybkość ataku: " + weapon.attackSpeed.ToString() + System.Environment.NewLine + System.Environment.NewLine;
    }
    if (item is IItemArmor)
    {
      IItemArmor armor = item as IItemArmor;
      statDesc = "Obrona: " + armor.defense.ToString() + System.Environment.NewLine + "Szybkość poruszania " + armor.movementSpeed.ToString() + System.Environment.NewLine + System.Environment.NewLine;
    }
    this.gameObject.transform.Find("ItemTitle").GetComponent<UnityEngine.UI.Text>().text = item.itemName;
    this.gameObject.transform.Find("ItemTags").GetComponent<UnityEngine.UI.Text>().text = type + " - " + rarity + " - " + item.secondItemType;
    this.gameObject.transform.Find("ItemDesc").GetComponent<UnityEngine.UI.Text>().text = statDesc;
    this.gameObject.transform.Find("ButtonEquipe").gameObject.SetActive(true);
    this.gameObject.transform.Find("ButtonSell").gameObject.SetActive(true);
    this.gameObject.transform.Find("SellText").gameObject.SetActive(true);
    this.gameObject.transform.Find("SellValue").GetComponent<UnityEngine.UI.Text>().text = GetItemSellValue(item).ToString();
  }
  int GetItemSellValue(IItem item)
  {
    return (item.itemRarity * 1000) + ((item.itemTier * 100) + 100) + ((item.itemLevel * 20) + 100);
  }
  public void ClearInfo()
  {
    this.gameObject.transform.Find("ItemImage").GetComponent<Image>().sprite =
      this.iconScript.defaultIcon;
    this.gameObject.transform.Find("ItemTitle").GetComponent<UnityEngine.UI.Text>().text = "";
    this.gameObject.transform.Find("ItemTags").GetComponent<UnityEngine.UI.Text>().text = "";
    this.gameObject.transform.Find("ItemDesc").GetComponent<UnityEngine.UI.Text>().text = "";
    this.gameObject.transform.Find("SellValue").GetComponent<UnityEngine.UI.Text>().text = "";
    this.gameObject.transform.Find("ButtonEquipe").gameObject.SetActive(false);
    this.gameObject.transform.Find("ButtonSell").gameObject.SetActive(false);
    this.gameObject.transform.Find("SellText").gameObject.SetActive(false);
    this.cItem = null;
  }
  public void SellItem()
  {
    GameObject pm = GameObject.FindWithTag("PlayerManager");
    int itemValue = GetItemSellValue(this.cItem);
    pm.GetComponent<Inventory>().itemList.Remove(this.cItem);
    ClearInfo();
    pm.GetComponent<CharacterValues>().money += itemValue;
    pm.GetComponent<Inventory>().RefreshInventory();
  }
  private void findPlayerManager()
  {
    this.iconScript = GameObject.FindWithTag("PlayerManager").GetComponent<ItemsIcons>();
  }
}
