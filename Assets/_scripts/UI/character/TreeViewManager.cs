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

  [Header("Node sprites setup")]
  public Sprite nodeAvaiable;
  public Sprite nodeNotAvaiable;
  public Sprite nodeTaken;

  [Header("Tree GameObject")]
  public GameObject tree;

  public List<GameObject> allNodes = new List<GameObject>();
  void updatePoints()
  {
    int points = this.statsPlayManager.getAmountOfPointsOwned();
    if (points >= 0)
      this.pointsValue.GetComponent<UnityEngine.UI.Text>().text = this.statsPlayManager.getAmountOfPointsOwned().ToString();
    else
      this.pointsValue.GetComponent<UnityEngine.UI.Text>().text = "0";
  }
  public void unlockNode(int id)
  {
    statsPlayManager.nodesOwned.Add(id);
    updatePoints();
    updateTree();
  }
  void OnEnable()
  {
    findPlayerManager();
    updatePoints();
    getAllNodes();
    updateTree();
  }
  void updateTree()
  {
    int points = this.statsPlayManager.getAmountOfPointsOwned();
    foreach (GameObject node in this.allNodes)
    {
      if (this.statsPlayManager.nodesOwned.Exists(y => y == node.GetComponent<TreeNode>().ID))
      {
        node.GetComponent<Image>().sprite = nodeTaken;
        node.GetComponent<TreeNode>().isUnlockable = false;
      }
      else if (node.GetComponent<TreeNode>().requiredNodesIds.Length == 0 || isListContainesOtherList(this.statsPlayManager.nodesOwned, node.GetComponent<TreeNode>().requiredNodesIds))
      {
        node.GetComponent<Image>().sprite = nodeAvaiable;
        if (points > 0)
          node.GetComponent<TreeNode>().isUnlockable = true;
        else
          node.GetComponent<TreeNode>().isUnlockable = false;
      }
      else
      {
        node.GetComponent<Image>().sprite = nodeNotAvaiable;
        node.GetComponent<TreeNode>().isUnlockable = false;
      }
    }
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
  void getAllNodes()
  {
    this.allNodes.Clear();

    List<GameObject> list = new List<GameObject>();
    for (int i = 0; i < this.tree.transform.childCount; i++)
    {
      list.Add(this.tree.transform.GetChild(i).gameObject);
    }

    foreach (GameObject o in list)
    {
      for (int i = 0; i < o.transform.childCount; i++)
      {
        if (o.transform.GetChild(i).gameObject.tag == "TreeNode")
        {
          this.allNodes.Add(o.transform.GetChild(i).gameObject);
        }
      }
    }
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
