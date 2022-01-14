using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePopup : MonoBehaviour
{
  public GameObject itemsPanel;
  public GameObject closeButton;
  public GameObject itemUpgradePrefab;
  public void SetItems(List<IItem> itemsToSet)
  {
    GameObject[] invItems = GameObject.FindGameObjectsWithTag("UpgradePopupItem");
    foreach (GameObject item in invItems)
    {
      GameObject.Destroy(item);
    }
    foreach (IItem item in itemsToSet)
    {
      GameObject GO = Instantiate(this.itemUpgradePrefab);
      GO.transform.GetComponent<UpgradeSlot>().setItemFromIItem(item);
      GO.transform.SetParent(this.itemsPanel.transform);
    }
  }
  public void SelectToUse(IItem selectedItem)
  {
    GameObject.FindWithTag("UpgradeInfo").GetComponent<UpgradeInfoManager>().SetUseInUpgrade(selectedItem);
    this.gameObject.SetActive(false);
  }
  public void ClosePopup()
  {
    this.gameObject.SetActive(false);
  }
  void Start()
  {

  }

  void Update()
  {

  }
}
