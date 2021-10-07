using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
  bool stackable ();
  int itemTier { get; set; }
  int itemLevel { get; set; }
  string itemRarity {get; set;}
  int itemIndex {get; set;}

  string itemName {get;}
  string itemType {get;}
  string secondItemType {get;}
  string itemDesc {get;}
}
