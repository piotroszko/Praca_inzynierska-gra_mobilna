using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class treeUpgrades : MonoBehaviour
{
  [Serializable]
  public class TreeNode
  {
    public int ID;
    public int row;
    public int pos;
    public string nodeName;
    public string desc;
    public int[] requiredNodesIds;
  }
  [SerializeField] public TreeNode[] nodes;
  public List<int> nodesOwned = new List<int>();
  public int getAmountOfPointsOwned()
  {
    return this.gameObject.GetComponent<CharacterValues>().level - nodesOwned.Count;
  }

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}