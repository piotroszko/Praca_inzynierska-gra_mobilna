using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipeManager : MonoBehaviour
{
  Image imageWeapon;
  Image imageCollar;
  Image imageCoat;

  IItem weapon;
  IItem collar;
  IItem coat;
  public void ShowItem(string slot)
  {
    switch (slot)
    {
      case "weapon":
        if(this.weapon != null)
        GameObject.FindWithTag("ItemInfo").GetComponent<ItemInfoManager>().SetItemInfo(this.weapon);
        break;
      case "coat":
        if(this.coat != null)
        GameObject.FindWithTag("ItemInfo").GetComponent<ItemInfoManager>().SetItemInfo(this.coat);
        break;
      case "collar":
        if(this.collar != null)
        GameObject.FindWithTag("ItemInfo").GetComponent<ItemInfoManager>().SetItemInfo(this.collar);
        break;
    }
  }
  public void Equipe(IItem item)
  {
    if (item is IItemWeapon)
    {
      IItemWeapon weapon = (IItemWeapon)item;
      if (this.weapon == weapon)
        this.weapon = null;
      else
        this.weapon = item;
    }
    else if (item is IItemArmor)
    {
      IItemArmor armor = item as IItemArmor;
      if (item.itemType == "Collar")
      {
        if (this.collar == armor)
          this.collar = null;
        else
          this.collar = item;
      }
      else if (item.itemType == "Coat")
      {
        if (this.coat == armor)
          this.coat = null;
        else
          this.coat = item;
      }
    }
  }
  public void Refresh()
  {
    ItemsIcons icons = GameObject.FindWithTag("PlayerManager").GetComponent<ItemsIcons>();

    if (this.weapon != null)
    {
      this.imageWeapon.sprite = icons.itemsIcons.Find(x => x.itemID == this.weapon.itemIconID).itemIcon;
    }
    else
    {
      this.imageWeapon.sprite = null;
    }
    if (this.collar != null)
    {
      this.imageCollar.sprite = icons.itemsIcons.Find(x => x.itemID == this.collar.itemIconID).itemIcon;
    }
    else
    {
      this.imageCollar.sprite = null;
    }
    if (this.coat != null)
    {
      this.imageCoat.sprite = icons.itemsIcons.Find(x => x.itemID == this.coat.itemIconID).itemIcon;
    }
    else
    {
      this.imageCoat.sprite = null;
    }
  }
  public void ClearWeapon()
  {
    this.weapon = null;
    this.imageWeapon.sprite = null;
  }
  public void ClearCollar()
  {
    this.collar = null;
    this.imageCollar.sprite = null;
  }
  public void ClearCoat()
  {
    this.coat = null;
    this.imageCoat.sprite = null;
  }
  void OnEnable()
  {
    this.imageWeapon = gameObject.transform.Find("WeaponManager/Weapon").GetComponent<Image>();
    this.imageCollar = gameObject.transform.Find("CollarManager/Collar").GetComponent<Image>();
    this.imageCoat = gameObject.transform.Find("CoatManager/Coat").GetComponent<Image>();
    Refresh();
  }
  void Update()
  {

  }
}
