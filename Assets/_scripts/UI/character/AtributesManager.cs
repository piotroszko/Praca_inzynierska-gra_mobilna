using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributesManager : MonoBehaviour
{
  private CharacterValues statsPlayManager;
  public GameObject GOpoints;

  public GameObject GOhealth;
  public GameObject GOdef;
  public GameObject GOspeed;
  public GameObject GOstr;

  public List<GameObject> buttons = new List<GameObject>();

  public void addAttrPoint(string attr)
  {
    if (attr == "health")
    {
      this.statsPlayManager.addPointHealth();
    }
    else if (attr == "def")
    {
      this.statsPlayManager.addPointDef();
    }
    else if (attr == "speed")
    {
      this.statsPlayManager.addPointSpeed();
    }
    else if (attr == "str")
    {
      this.statsPlayManager.addPointStr();
    }
    updateAttValues();
    checkAddAvaiable();
  }
  void OnEnable()
  {
    findPlayerManager();
    checkAddAvaiable();
    updateAttValues();
  }
  void updateAttValues()
  {
    this.GOhealth.GetComponent<UnityEngine.UI.Text>().text = "(" + (statsPlayManager.pointsHealth).ToString() + ")";
    this.GOdef.GetComponent<UnityEngine.UI.Text>().text = "(" + (statsPlayManager.pointsDefense).ToString() + ")";
    this.GOspeed.GetComponent<UnityEngine.UI.Text>().text = "(" + (statsPlayManager.pointsSpeed).ToString() + ")";
    this.GOstr.GetComponent<UnityEngine.UI.Text>().text = "(" + (statsPlayManager.pointsStrength).ToString() + ")";
  }
  void checkAddAvaiable()
  {
    int points = this.statsPlayManager.aviablePoints;
    if (points > 0)
    {
      changeButtonsAvaiability(true);
    }
    else
    {
      changeButtonsAvaiability(false);
    }
    this.GOpoints.GetComponent<UnityEngine.UI.Text>().text = points.ToString();
  }
  void changeButtonsAvaiability(bool state)
  {
    if (state)
    {
      foreach (GameObject o in this.buttons)
      {
        o.SetActive(true);
      }
    }
    else
    {
      foreach (GameObject o in this.buttons)
      {
        o.SetActive(false);
      }
    }
  }
  void Start()
  {
    findPlayerManager();
  }

  void Update()
  {

  }
  private void findPlayerManager()
  {
    GameObject PlayerManager = GameObject.FindWithTag("PlayerManager");
    this.statsPlayManager = PlayerManager.GetComponent<CharacterValues>();
  }
}
