using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoManager : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  public void SetItemInfo(IItem item)
  {
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
      default:
        type = "";
        break;
    }
    string dmgSpd = "";
    if (item is IItemCollar)
    {
      IItemCollar collar = item as IItemCollar;
      dmgSpd = "Obrażenia: " + collar.damage.ToString() + System.Environment.NewLine + "Szybkość ataku: " + collar.speed.ToString() + System.Environment.NewLine + System.Environment.NewLine;
    }
    this.gameObject.transform.Find("ItemTitle").GetComponent<UnityEngine.UI.Text>().text = item.itemName;
    this.gameObject.transform.Find("ItemTags").GetComponent<UnityEngine.UI.Text>().text = type + " - " + rarity + " - " + item.secondItemType;
    this.gameObject.transform.Find("ItemDesc").GetComponent<UnityEngine.UI.Text>().text = dmgSpd + item.itemDesc;
  }
}
