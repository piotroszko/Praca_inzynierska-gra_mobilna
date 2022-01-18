using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UpgradeInfoManager : MonoBehaviour
{
  ItemsIcons iconScript;
  IItem currentItem;
  IItem itemInUpgrade;
  public GameObject popup;
  public GameObject checkmark;
  // Start is called before the first frame update
  void Start()
  {
    findPlayerManager();
  }

  // Update is called once per frame
  void Update()
  {

  }
  public void SetUseInUpgrade(IItem itemInUpgrade)
  {
    this.itemInUpgrade = itemInUpgrade;
    this.checkmark.SetActive(true);
    GameObject.Find("UpgradeBtn1").GetComponent<Button>().interactable = true;
  }
  public void ClearUseInUpgrade()
  {
    this.itemInUpgrade = null;
    this.checkmark.SetActive(false);
    GameObject.Find("UpgradeBtn1").GetComponent<Button>().interactable = false;
  }
  public void ShowPopup()
  {
    this.popup.SetActive(true);
    if (currentItem != null)
      this.popup.GetComponent<UpgradePopup>().SetItems(GameObject.FindWithTag("PlayerManager").GetComponent<Inventory>().itemList.Where(x => x.itemName == this.currentItem.itemName && x != this.currentItem).ToList());
  }
  public void SetItemInfo(IItem item)
  {
    ClearUseInUpgrade();
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
      if (weapon.upgradeInfo.boughtTypeItem >= weapon.upgradeInfo.upgradesTypeItem.Count)
      {
        option1.transform.Find("SelectItem").GetComponent<Button>().interactable = false;
      }
      else
      {
        option1.transform.Find("SelectItem").GetComponent<Button>().interactable = true;
      }
      float dmgTmp = weapon.damage + (weapon.upgradeInfo.sumTypeItem(true) * weapon.damage);
      float spdTmp = weapon.attackSpeed + (weapon.upgradeInfo.sumTypeItem(false) * weapon.attackSpeed);
      float dmg = dmgTmp + (weapon.upgradeInfo.sumTypeMoney(true) * dmgTmp);
      float spd = spdTmp + (weapon.upgradeInfo.sumTypeMoney(false) * spdTmp);
      SetStat(option1s1, "Obrażenia:", dmg.ToString(), "Szybkość ataku:", spd.ToString());
      SetStat(option2s1, "Obrażenia:", dmg.ToString(), "Szybkość ataku:", spd.ToString());
      if (weapon.upgradeInfo.upgradesTypeItem.Count() > weapon.upgradeInfo.boughtTypeItem)
        SetStat(option1s2, "Obrażenia:", CalculateUpgrade(weapon.upgradeInfo, dmg, true, true),
        "Szybkość ataku:", CalculateUpgrade(weapon.upgradeInfo, spd, true, false));
      else
        SetStat(option1s2, "Obrażenia:", "-",
        "Szybkość ataku:", "-");

      if (weapon.upgradeInfo.upgradesTypeMoney.Count() > weapon.upgradeInfo.boughtTypeMoney)
        SetStat(option2s2, "Obrażenia:", CalculateUpgrade(weapon.upgradeInfo, dmg, false, true),
        "Szybkość ataku:", CalculateUpgrade(weapon.upgradeInfo, spd, false, false));
      else
        SetStat(option2s2, "Obrażenia:", "-",
        "Szybkość ataku:", "-");
      SetMoneyCost(weapon.upgradeInfo, option2);

    }
    else if (item is IItemArmor)
    {
      IItemArmor armor = item as IItemArmor;
      if (armor.upgradeInfo.boughtTypeItem >= armor.upgradeInfo.upgradesTypeItem.Count)
      {
        option1.transform.Find("SelectItem").GetComponent<Button>().interactable = false;
      }
      else
      {
        option1.transform.Find("SelectItem").GetComponent<Button>().interactable = true;
      }
      float defTmp = armor.defense + (armor.upgradeInfo.sumTypeItem(true) * armor.defense);
      float spdTmp = armor.movementSpeed + (armor.upgradeInfo.sumTypeItem(false) * armor.movementSpeed);
      float def = defTmp + (armor.upgradeInfo.sumTypeMoney(true) * defTmp);
      float spd = spdTmp + (armor.upgradeInfo.sumTypeMoney(false) * spdTmp);
      SetStat(option1s1, "Obrona:", def.ToString(), "Szybkość poruszania:", spd.ToString());
      SetStat(option2s1, "Obrona:", def.ToString(), "Szybkość poruszania:", spd.ToString());

      if (armor.upgradeInfo.upgradesTypeItem.Count() > armor.upgradeInfo.boughtTypeItem)
        SetStat(option1s2, "Obrona:", CalculateUpgrade(armor.upgradeInfo, def, true, true),
        "Szybkość poruszania:", CalculateUpgrade(armor.upgradeInfo, spd, true, false));
      else
        SetStat(option1s2, "Obrona:", "-",
        "Szybkość poruszania:", "-");

      if (armor.upgradeInfo.upgradesTypeMoney.Count() > armor.upgradeInfo.boughtTypeMoney)
      {
        SetStat(option2s2, "Obrona:", CalculateUpgrade(armor.upgradeInfo, def, false, true),
        "Szybkość poruszania:", CalculateUpgrade(armor.upgradeInfo, spd, false, false));
      }
      else
        SetStat(option2s2, "Obrona:", "-",
        "Szybkość poruszania:", "-");
      SetMoneyCost(armor.upgradeInfo, option2);
    }
    this.gameObject.transform.Find("ItemName").GetComponent<UnityEngine.UI.Text>().text = item.itemName;

  }
  public void UpgradeByItem()
  {
    if (this.currentItem != null && this.itemInUpgrade != null)
    {
      GameObject.FindWithTag("PlayerManager").GetComponent<Inventory>().itemList.Remove(this.itemInUpgrade);
      this.itemInUpgrade = null;
      if (this.currentItem is IItemArmor)
      {
        IItemArmor armor = this.currentItem as IItemArmor;
        armor.upgradeInfo.boughtTypeItem++;
      }
      else if (this.currentItem is IItemWeapon)
      {
        IItemWeapon weapon = this.currentItem as IItemWeapon;
        weapon.upgradeInfo.boughtTypeItem++;
      }
      this.currentItem.itemTier++;
      SetItemInfo(this.currentItem);
      GameObject.FindWithTag("PlayerManager").GetComponent<Inventory>().RefreshUpgradeInventory();
    }
  }
  public void UpgradeByMoney()
  {
    GameObject PlayerManager = GameObject.FindWithTag("PlayerManager");
    CharacterValues statsPlayManager = PlayerManager.GetComponent<CharacterValues>();

    if (this.currentItem is IItemArmor)
    {
      IItemArmor armor = this.currentItem as IItemArmor;
      if (statsPlayManager.money >=
          armor.upgradeInfo.upgradesTypeMoney[armor.upgradeInfo.boughtTypeMoney].upgradeCost)
      {
        statsPlayManager.money -= armor.upgradeInfo.upgradesTypeMoney[armor.upgradeInfo.boughtTypeMoney].upgradeCost;
        armor.upgradeInfo.boughtTypeMoney++;
      }
    }
    else if (this.currentItem is IItemWeapon)
    {
      IItemWeapon weapon = this.currentItem as IItemWeapon;
      if (statsPlayManager.money >=
          weapon.upgradeInfo.upgradesTypeMoney[weapon.upgradeInfo.boughtTypeMoney].upgradeCost)
      {
        statsPlayManager.money -= weapon.upgradeInfo.upgradesTypeMoney[weapon.upgradeInfo.boughtTypeMoney].upgradeCost;
        weapon.upgradeInfo.boughtTypeMoney++;
      }
    }
    this.currentItem.itemLevel++;
    SetItemInfo(this.currentItem);
    GameObject.FindWithTag("PlayerManager").GetComponent<Inventory>().RefreshUpgradeInventory();
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
    else
    {
      select2.transform.Find("UpgradeBtn2").GetComponent<Button>().interactable = false;
      select2.transform.Find("ValueCost").GetComponent<UnityEngine.UI.Text>().text = "";
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
