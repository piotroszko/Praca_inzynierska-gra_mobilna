using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableRefreshMoney : MonoBehaviour
{
  void OnEnable()
  {
    this.findPlayerManager();
    this.gameObject.GetComponent<UnityEngine.UI.Text>().text = this.values.money.ToString();
  }
  CharacterValues values;
  private void findPlayerManager()
  {
    this.values = GameObject.FindWithTag("PlayerManager").GetComponent<CharacterValues>();
  }
}
