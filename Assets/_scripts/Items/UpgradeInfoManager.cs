using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfoManager : MonoBehaviour
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
      this.gameObject.transform.Find("ItemIcon").GetComponent<Image>().sprite =
      this.iconScript.itemsIcons.Find(x => x.itemID == item.itemIconID).itemIcon;
    }
    else
    {
      this.gameObject.transform.Find("ItemIcon").GetComponent<Image>().sprite =
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
    this.gameObject.transform.Find("ItemName").GetComponent<UnityEngine.UI.Text>().text = item.itemName;

  }
  private void findPlayerManager()
  {
    this.iconScript = GameObject.FindWithTag("PlayerManager").GetComponent<ItemsIcons>();
  }
}
