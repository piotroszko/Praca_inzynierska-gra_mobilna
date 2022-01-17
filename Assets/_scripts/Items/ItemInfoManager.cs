using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoManager : MonoBehaviour
{
  ItemsIcons iconScript;
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

  }
  private void findPlayerManager()
  {
    this.iconScript = GameObject.FindWithTag("PlayerManager").GetComponent<ItemsIcons>();
  }
}
