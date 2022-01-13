using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfoManager : MonoBehaviour
{
  ItemsIcons iconScript;
  IItem currentItem;
  public GameObject popup;
  // Start is called before the first frame update
  void Start()
  {
    findPlayerManager();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public void ShowPopup()
  {
    this.popup.SetActive(true);
  }
  public void SetItemInfo(IItem item)
  {
    this.currentItem = item;
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
      case "Seed":
        type = "Nasiono";
        break;
      case "Coat":
        type = "Kubrak";
        break;
      case "Chestnut":
        type = "Żolądź";
        break;
      default:
        type = "";
        break;
    }
    GameObject option1 = this.gameObject.transform.Find("Select1").gameObject;
    GameObject option1s1 = option1.transform.Find("Stats1").gameObject;
    GameObject option1s2 = option1.transform.Find("Stats2").gameObject;

    GameObject option2 = this.gameObject.transform.Find("Select2").gameObject;
    GameObject option2s1 = option2.transform.Find("Stats1").gameObject;
    GameObject option2s2 = option2.transform.Find("Stats2").gameObject;

    if (item is IItemWeapon)
    {
      IItemWeapon weapon = item as IItemWeapon;
      SetStat(option1s1, "Obrażenia:", weapon.damage.ToString(), "Szybkość ataku:", weapon.attackSpeed.ToString());
      SetStat(option2s1, "Obrażenia:", weapon.damage.ToString(), "Szybkość ataku:", weapon.attackSpeed.ToString());
      SetStat(option1s2, "Obrażenia:", CalculateUpgrade(weapon.upgradeInfo, weapon.damage, true, true),
      "Szybkość ataku:", CalculateUpgrade(weapon.upgradeInfo, weapon.attackSpeed, true, false));

      SetStat(option2s2, "Obrażenia:", CalculateUpgrade(weapon.upgradeInfo, weapon.damage, false, true),
      "Szybkość ataku:", CalculateUpgrade(weapon.upgradeInfo, weapon.attackSpeed, false, false));
      SetMoneyCost(weapon.upgradeInfo, option2);

    }
    else if (item is IItemArmor)
    {
      IItemArmor armor = item as IItemArmor;
      SetStat(option1s1, "Obrona:", armor.defense.ToString(), "Szybkość poruszania:", armor.movementSpeed.ToString());
      SetStat(option2s1, "Obrona:", armor.defense.ToString(), "Szybkość poruszania:", armor.movementSpeed.ToString());
      SetStat(option1s2, "Obrona:", CalculateUpgrade(armor.upgradeInfo, armor.defense, true, true),
      "Szybkość poruszania:", CalculateUpgrade(armor.upgradeInfo, armor.movementSpeed, true, false));

      SetStat(option2s2, "Obrona:", CalculateUpgrade(armor.upgradeInfo, armor.defense, false, true),
      "Szybkość poruszania:", CalculateUpgrade(armor.upgradeInfo, armor.movementSpeed, false, false));
      SetMoneyCost(armor.upgradeInfo, option2);
    }
    this.gameObject.transform.Find("ItemName").GetComponent<UnityEngine.UI.Text>().text = item.itemName;

  }
  void SetMoneyCost(UpgradeInfo upInfo, GameObject select2)
  {
    if (upInfo.boughtTypeMoney < upInfo.upgradesTypeMoney.Count)
    {
      select2.transform.Find("ValueCost").GetComponent<UnityEngine.UI.Text>().text = upInfo.upgradesTypeMoney[upInfo.boughtTypeMoney].upgradeCost.ToString();
      GameObject PlayerManager = GameObject.FindWithTag("PlayerManager");
      CharacterValues statsPlayManager = PlayerManager.GetComponent<CharacterValues>();
      if (statsPlayManager.money >= upInfo.upgradesTypeMoney[upInfo.boughtTypeMoney].upgradeCost)
      {
        select2.transform.Find("UpgradeBtn2").GetComponent<Button>().interactable = true;
      }
      else
      {
        select2.transform.Find("UpgradeBtn2").GetComponent<Button>().interactable = false;
      }
    }

  }
  string CalculateUpgrade(UpgradeInfo upInfo, float currentV, bool itemUpgrade, bool firstStat)
  {
    int upgradeValue;
    if (itemUpgrade)
    {
      if (firstStat)
      {
        upgradeValue = upInfo.upgradesTypeItem[upInfo.boughtTypeItem].upgradeToStat1;

      }
      else
      {
        upgradeValue = upInfo.upgradesTypeItem[upInfo.boughtTypeItem].upgradeToStat2;
      }
    }
    else
    {
      if (firstStat)
      {
        upgradeValue = upInfo.upgradesTypeMoney[upInfo.boughtTypeMoney].upgradeToStat1;
      }
      else
      {

        upgradeValue = upInfo.upgradesTypeMoney[upInfo.boughtTypeMoney].upgradeToStat2;
      }
    }
    float percentage = (float)upgradeValue / 100f;
    float addedValue = currentV * percentage;
    return (currentV + addedValue).ToString();
  }
  void SetStat(GameObject selectGameObject, string stat1, string value1, string stat2, string value2)
  {
    selectGameObject.transform.Find("Stat1").GetComponent<UnityEngine.UI.Text>().text = stat1;
    selectGameObject.transform.Find("Value1").GetComponent<UnityEngine.UI.Text>().text = value1;
    selectGameObject.transform.Find("Stat2").GetComponent<UnityEngine.UI.Text>().text = stat2;
    selectGameObject.transform.Find("Value2").GetComponent<UnityEngine.UI.Text>().text = value2;
  }
  private void findPlayerManager()
  {
    this.iconScript = GameObject.FindWithTag("PlayerManager").GetComponent<ItemsIcons>();
  }
}
