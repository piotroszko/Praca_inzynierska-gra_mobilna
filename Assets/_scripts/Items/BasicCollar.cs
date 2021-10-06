using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollar : IItem
{
    public bool stackable () {
        return true;
    }
    public int itemTier { 
        get{ 
            return 0;
        } 
        set{} 
    }
    public int itemLevel { 
        get{
            return 1;
        } 
        set{

        } 
    }
    public string itemRarity {
        get{ 
            return "Rare";
        } 
        set{

        }
    }
    public string itemName {get{ return "Basic Collar";}}
    public string itemType {get{return "Collar";}}
    public string secondItemType {get{return "";}}
    public string itemDesc {get{return "Najbardziej podstawowa obroża";}}
}
