using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<IItem> itemList = new List<IItem>();
    bool smthChanged = true;
    public GameObject itemPrefab;
    public GameObject inventoryPanel;
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.itemList.Add(new BasicCollar());
    }

    // Update is called once per frame
    void Update()
    {
        if(smthChanged) {
            GameObject[] invItems = GameObject.FindGameObjectsWithTag("InventoryItem");   
            foreach(GameObject item in invItems)  
            {
                GameObject.Destroy(item);
            }
            foreach(IItem item in itemList) {
                GameObject GO = Instantiate(itemPrefab);
                GO.transform.Find("Amount").GetComponent<UnityEngine.UI.Text>().text = "*";
                GO.transform.Find("ItemName").GetComponent<UnityEngine.UI.Text>().text = item.itemName;
                //GO.transform.Find("Modified").GetComponent<UnityEngine.UI.Text>()
                GO.transform.Find("ItemType").GetComponent<UnityEngine.UI.Text>().text = item.itemType;
                GO.transform.Find("ItemTier").GetComponent<UnityEngine.UI.Text>().text = "T" + item.itemTier.ToString();
                GO.transform.Find("ItemLevel").GetComponent<UnityEngine.UI.Text>().text = item.itemLevel.ToString();
                GO.transform.parent = this.inventoryPanel.transform;
            }
            smthChanged = false;
        }
    }
}
