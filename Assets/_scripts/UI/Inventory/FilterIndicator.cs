using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterIndicator : MonoBehaviour
{
    public Sprite defaultIndicator;
    public Sprite indicatorUp;
    public Sprite indicatorDown;

    public void setDefault () {
        this.gameObject.GetComponent<Image>().sprite = this.defaultIndicator;
    }
    public void setUp() {
        this.gameObject.GetComponent<Image>().sprite = this.indicatorUp;
    }
    public void setDown () {
        this.gameObject.GetComponent<Image>().sprite = this.indicatorDown;
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
