using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterValues : MonoBehaviour
{
  public int replayTimes = 1;
  public int level = 1;
  private float _experience = 0;
  public float  experience { 
    get {return _experience;}
    set { 
      _experience = value;
    if(_experience > level * 400) {
      _experience = 0;
      level ++;
      aviablePoints += 3;
    }
    }
  }

  public bool additionalMoney = false;

  public int _money = 100;
  public int money
  {
    get { return _money; }
    set
    {
      int addMoney = 0;
      if ((value - _money) > 0){
        gameObject.GetComponent<StatisticsValues>().statsGold += value - _money;
        if(additionalMoney)
          addMoney = (value - _money) / 2;
      }
      _money = value + addMoney;
      
      GameObject text = GameObject.FindWithTag("MoneyValueText");
      if (text.activeSelf)
        text.GetComponent<UnityEngine.UI.Text>().text = _money.ToString();

    }
  }

  private int _pointsHealth = 0;
  public int pointsHealth { get {
    return _pointsHealth;
    } 
  set {
    _pointsHealth = value;
    GameObject.FindWithTag("Player").GetComponent<Health>().additionalHealth = _pointsHealth;
  } }
  public int pointsDefense = 0;
  public int pointsSpeed = 0;
  public int pointsStrength = 0;

  public int aviablePoints = 5;
  public void addPointHealth()
  {
    this.pointsHealth++;
    this.aviablePoints--;
  }
  public void addPointDef()
  {
    this.pointsDefense++;
    this.aviablePoints--;
  }
  public void addPointSpeed()
  {
    this.pointsSpeed++;
    this.aviablePoints--;
  }
  public void addPointStr()
  {
    this.pointsStrength++;
    this.aviablePoints--;
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
