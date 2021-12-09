using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  private GameObject PlayerManager;
  public GameObject levelText;
  void correctLevel()
  {
    findPlayerManager();
    CharacterValues statsPlayManager = this.PlayerManager.GetComponent<CharacterValues>();
    this.levelText.GetComponent<UnityEngine.UI.Text>().text = (statsPlayManager.level).ToString();
  }
  void OnEnable()
  {
    correctLevel();
  }
  void Start()
  {
    findPlayerManager();
  }
  private void findPlayerManager()
  {
    this.PlayerManager = GameObject.FindWithTag("PlayerManager");
  }
  void Update()
  {

  }
}
