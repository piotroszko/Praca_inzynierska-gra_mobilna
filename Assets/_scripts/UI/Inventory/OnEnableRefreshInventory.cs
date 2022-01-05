using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableRefreshInventory : MonoBehaviour
{
  void OnEnable()
  {
    this.findPlayerManager();
    this.inventoryScript.RefreshInventory();
  }
  Inventory inventoryScript;
  private void findPlayerManager()
  {
    this.inventoryScript = GameObject.FindWithTag("PlayerManager").GetComponent<Inventory>();
  }
}
