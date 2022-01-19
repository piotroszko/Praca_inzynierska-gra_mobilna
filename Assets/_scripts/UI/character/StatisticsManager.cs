using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
  public GameObject PlayerManager;
  public GameObject GOkills;
  public GameObject GOexp;
  public GameObject GOjumps;
  public GameObject GOdistance;
  public GameObject GOitems;
  public GameObject GOgold;
  public GameObject GOupgrades;
  public void correctValues()
  {
    findPlayerManager();
    StatisticsValues statsPlayManager = this.PlayerManager.GetComponent<StatisticsValues>();
    this.GOkills.GetComponent<UnityEngine.UI.Text>().text = this.numbersToThousands(statsPlayManager.statsKills);
    this.GOexp.GetComponent<UnityEngine.UI.Text>().text = this.numbersToThousands(statsPlayManager.statsExperience);
    this.GOjumps.GetComponent<UnityEngine.UI.Text>().text = this.numbersToThousands(statsPlayManager.statsJumps);
    this.GOdistance.GetComponent<UnityEngine.UI.Text>().text = this.numbersToThousands(statsPlayManager.statsDistance);
    this.GOitems.GetComponent<UnityEngine.UI.Text>().text = this.numbersToThousands(statsPlayManager.statsItems);
    this.GOgold.GetComponent<UnityEngine.UI.Text>().text = this.numbersToThousands(statsPlayManager.statsGold);
    this.GOupgrades.GetComponent<UnityEngine.UI.Text>().text = this.numbersToThousands(statsPlayManager.statsUpgrades);
  }
  void OnEnable()
  {
    correctValues();
  }
  private string numbersToThousands(int value)
  {
    if (value > 1000)
    {
      return (value / 1000f).ToString("0.0") + " tyś";
    }
    else
    {
      return value.ToString();
    }
  }
  private void findPlayerManager()
  {
    this.PlayerManager = GameObject.FindWithTag("PlayerManager");
  }
  void Start()
  {
    findPlayerManager();
  }
  void Update()
  {

  }
}
