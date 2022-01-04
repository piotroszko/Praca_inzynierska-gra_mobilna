using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemsIcons : MonoBehaviour
{
  [Serializable]
  public class ItemIcon
  {
    public int itemID;
    public Sprite itemIcon;

  }
  [SerializeField] public Sprite defaultIcon;
  [SerializeField] public List<ItemIcon> itemsIcons = new List<ItemIcon>();

}
