using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterValues : MonoBehaviour
{
  public int level = 1;
  public int experience = 0;

  public int pointsHealth = 0;
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
