using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIconManager : MonoBehaviour
{
  public GameObject menuCanvas;
  public GameObject inventoryView;
  public GameObject iventoryUpgrade;
  public GameObject InGameMenuCanvas;
  // Start is called before the first frame update
  void Start()
  {

  }
  public void ChangeView(string selectedView)
  {
    if (selectedView == "back")
    {
      this.menuCanvas.SetActive(false);
      this.InGameMenuCanvas.SetActive(true);
    }
    else if (selectedView == "inventory")
    {
      this.iventoryUpgrade.SetActive(false);
      this.inventoryView.SetActive(true);
    }
    else if (selectedView == "upgrade")
    {
      this.iventoryUpgrade.SetActive(true);
      this.inventoryView.SetActive(false);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
