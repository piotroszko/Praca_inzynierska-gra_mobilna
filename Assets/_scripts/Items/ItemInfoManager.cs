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
    public void SetItemInfo (IItem item) { 
        this.gameObject.transform.Find("ItemTitle").GetComponent<UnityEngine.UI.Text>().text = item.itemName;
        this.gameObject.transform.Find("ItemTags").GetComponent<UnityEngine.UI.Text>().text = item.itemType + " - " + item.itemRarity + " - " + item.secondItemType;
        this.gameObject.transform.Find("ItemDesc").GetComponent<UnityEngine.UI.Text>().text = item.itemDesc;
    }
}
