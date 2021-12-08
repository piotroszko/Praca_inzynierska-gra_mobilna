using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIconManager : MonoBehaviour
{
  public GameObject menuCanvas;
  public GameObject inventoryView;
  public GameObject iventoryUpgrade;
  public GameObject InGameMenuCanvas;

  public GameObject characterView;
  public GameObject treeView;
  public GameObject settingsView;
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
      this.disableView();
      this.inventoryView.SetActive(true);
    }
    else if (selectedView == "upgrade")
    {
      this.disableView();
      this.iventoryUpgrade.SetActive(true);
    }
    else if (selectedView == "character")
    {
      this.disableView();
      this.characterView.SetActive(true);
    }
    else if (selectedView == "tree")
    {
      this.disableView();
      this.treeView.SetActive(true);
    }
    else if (selectedView == "settings")
    {
      this.disableView();
      this.settingsView.SetActive(true);
    }
  }
  void disableView()
  {
    if (this.iventoryUpgrade) this.iventoryUpgrade.SetActive(false);
    if (this.inventoryView) this.inventoryView.SetActive(false);
    if (this.characterView) this.characterView.SetActive(false);
    if (this.treeView) this.treeView.SetActive(false);
    if (this.settingsView) this.settingsView.SetActive(false);
  }
  // Update is called once per frame
  void Update()
  {

  }
}
