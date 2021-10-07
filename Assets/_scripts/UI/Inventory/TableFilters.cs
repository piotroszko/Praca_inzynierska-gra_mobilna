using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFilters : MonoBehaviour
{
    private int amount = 0;
    private int amountState {
        get { return amount;}
        set {
            amount = value;
            if(value == 0) {
                this.gameObject.transform.Find("Amount").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
            } else if(value == 1) {
               this.gameObject.transform.Find("Amount").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp(); 
            }
            else if(value == 2) {
               this.gameObject.transform.Find("Amount").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown(); 
            }
        }
    }
    private int mod = 0;
    private int modState {
        get { return mod;}
        set {
            mod = value;
            if(value == 0) {
                this.gameObject.transform.Find("Modified").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
            } else if(value == 1) {
               this.gameObject.transform.Find("Modified").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp(); 
            }
            else if(value == 2) {
               this.gameObject.transform.Find("Modified").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown(); 
            }
        }
    }
    private int name = 0;
    private int nameState {
        get { return name;}
        set {
            name = value;
            if(value == 0) {
                this.gameObject.transform.Find("ItemName").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
            } else if(value == 1) {
               this.gameObject.transform.Find("ItemName").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp(); 
            }
            else if(value == 2) {
               this.gameObject.transform.Find("ItemName").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown(); 
            }
        }
    }
    private int type = 0;
    private int typeState{
        get { return type;}
        set {
            type = value;
            if(value == 0) {
                this.gameObject.transform.Find("ItemType").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
            } else if(value == 1) {
               this.gameObject.transform.Find("ItemType").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp(); 
            }
            else if(value == 2) {
               this.gameObject.transform.Find("ItemType").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown(); 
            }
        }
    }
    private int level = 0;
    private int levelState {
        get { return level;}
        set {
            level = value;
            if(value == 0) {
                this.gameObject.transform.Find("ItemLevel").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
            } else if(value == 1) {
               this.gameObject.transform.Find("ItemLevel").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp(); 
            }
            else if(value == 2) {
               this.gameObject.transform.Find("ItemLevel").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown(); 
            }
        }
    }
    private int tier = 0;
    private int tierState {
        get { return tier;}
        set {
            tier = value;
            if(value == 0) {
                this.gameObject.transform.Find("ItemTier").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDefault();
            } else if(value == 1) {
               this.gameObject.transform.Find("ItemTier").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp(); 
            }
            else if(value == 2) {
               this.gameObject.transform.Find("ItemTier").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setDown(); 
            }
        }
    }
    //this.gameObject.transform.Find("Amount").transform.Find("FilterIndicator").GetComponent<FilterIndicator>().setUp();
    public void ChangeFilter (string filterName) {
        if(filterName == "amount") {
            if(this.amountState == 0 || this.amountState == 2) {
                this.amountState = 1;
                this.modState = 0;
                this.nameState = 0;
                this.typeState = 0;
                this.levelState = 0;
                this.tierState = 0;
            } else {
                this.amountState = 2;
                this.modState = 0;
                this.nameState = 0;
                this.typeState = 0;
                this.levelState = 0;
                this.tierState = 0;
            }
        } else if (filterName == "mod") {
            if(this.modState == 0 || this.modState == 2) {
                this.amountState = 0;
                this.modState = 1;
                this.nameState = 0;
                this.typeState = 0;
                this.levelState = 0;
                this.tierState = 0;
            } else {
                this.amountState = 0;
                this.modState = 2;
                this.nameState = 0;
                this.typeState = 0;
                this.levelState = 0;
                this.tierState = 0;
            }
        } else if (filterName == "name") {
            if(this.nameState == 0 || this.nameState == 2) {
                this.amountState = 0;
                this.modState = 0;
                this.nameState = 1;
                this.typeState = 0;
                this.levelState = 0;
                this.tierState = 0;
            } else {
                this.amountState = 0;
                this.modState = 0;
                this.nameState = 2;
                this.typeState = 0;
                this.levelState = 0;
                this.tierState = 0;
            }
        } else if (filterName == "type") {
            if(this.typeState == 0 || this.typeState == 2) {
                this.amountState = 0;
                this.modState = 0;
                this.nameState = 0;
                this.typeState = 1;
                this.levelState = 0;
                this.tierState = 0;
            } else {
                this.amountState = 0;
                this.modState = 0;
                this.nameState = 0;
                this.typeState = 2;
                this.levelState = 0;
                this.tierState = 0;
            }
        } else if (filterName == "level") {
            if(this.levelState == 0 || this.levelState == 2) {
                this.amountState = 0;
                this.modState = 0;
                this.nameState = 0;
                this.typeState = 0;
                this.levelState = 1;
                this.tierState = 0;
            } else {
                this.amountState = 0;
                this.modState = 0;
                this.nameState = 0;
                this.typeState = 0;
                this.levelState = 2;
                this.tierState = 0;
            }
        } else if (filterName == "tier") {
           if(this.tierState == 0 || this.tierState == 2) {
                this.amountState = 0;
                this.modState = 0;
                this.nameState = 0;
                this.typeState = 0;
                this.levelState = 0;
                this.tierState = 1;
            } else {
                this.amountState = 0;
                this.modState = 0;
                this.nameState = 0;
                this.typeState = 0;
                this.levelState = 0;
                this.tierState = 2;
            } 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
