using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class TreeViewManager : MonoBehaviour
{
  private treeUpgrades statsPlayManager;
  [Header("Points GameObject")]
  public GameObject pointsValue;

  [Header("Rows GameObject")]
  public GameObject firstRow;
  public GameObject secondRow;
  public GameObject thirdRow;
  public GameObject fourthRow;
  public GameObject fifthRow;

  [Header("Node sprites setup")]
  public Sprite nodeAvaiable;
  public Sprite nodeNotAvaiable;
  public Sprite nodeTaken;


  void updateNodes()
  {
    List<GameObject> rows = new List<GameObject>();
    rows.Add(firstRow);
    rows.Add(secondRow);
    rows.Add(thirdRow);
    rows.Add(fourthRow);
    rows.Add(fifthRow);
    /*
    //Cos tu trzeba poprawic bo zle znajduje odpowiednie nody
    for (int i = 1; i < 6; i++)
    {
      List<GameObject> nodesInRow = new List<GameObject>();
      for (int j = 0; j < rows[i].transform.childCount; j++)
      {
        if (rows[i].transform.GetChild(j).gameObject.tag == "TreeNode")
          nodesInRow.Add(rows[i].transform.GetChild(j).gameObject);
      }

      foreach (treeUpgrades.TreeNode n in this.statsPlayManager.nodes)
      {
        if (n.row == i)
        {
        
        if (statsPlayManager.nodesOwned.Exists(y => y == n.ID))
        {
          Debug.Log(statsPlayManager.nodesOwned);
          Debug.Log(n.ID);
          nodesInRow.First(f => f.name == n.pos.ToString()).GetComponent<Image>().sprite = this.nodeTaken;
        }
        else if (n.requiredNodesIds.Length == 0 || isListContainesOtherList(statsPlayManager.nodesOwned, n.requiredNodesIds))
        {
          nodesInRow.First(f => f.name == n.pos.ToString()).GetComponent<Image>().sprite = this.nodeAvaiable;
        }
        else
        {
          nodesInRow.First(f => f.name == n.pos.ToString()).GetComponent<Image>().sprite = this.nodeNotAvaiable;
        }
        }
      }
    }
    */

  }
  bool isListContainesOtherList(List<int> list, int[] containes)
  {
    foreach (int c in containes)
    {
      if (!(list.Exists(m => m == c)))
      {
        return false;
      }
    }
    return true;
  }
  void updatePoints()
  {
    this.pointsValue.GetComponent<UnityEngine.UI.Text>().text = this.statsPlayManager.getAmountOfPointsOwned().ToString();
  }
  void OnEnable()
  {
    findPlayerManager();
    updatePoints();
    updateNodes();
  }

  void Start()
  {
    findPlayerManager();
  }
  private void findPlayerManager()
  {
    GameObject PlayerManager = GameObject.FindWithTag("PlayerManager");
    this.statsPlayManager = PlayerManager.GetComponent<treeUpgrades>();
  }
}
