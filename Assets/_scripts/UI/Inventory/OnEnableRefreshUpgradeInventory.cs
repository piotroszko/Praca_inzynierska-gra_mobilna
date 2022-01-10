using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableRefreshUpgradeInventory : MonoBehaviour
{
  void OnEnable()
  {
    this.findPlayerManager();
    this.inventoryScript.RefreshUpgradeInventory();
  }
  Inventory inventoryScript;
  private void findPlayerManager()
  {
    this.inventoryScript = GameObject.FindWithTag("PlayerManager").GetComponent<Inventory>();
  }
}
