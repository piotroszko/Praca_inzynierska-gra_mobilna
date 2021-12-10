using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class treeUpgrades : MonoBehaviour
{
  [Serializable]
  private class TreeNode
  {
    public int ID;
    public int row;
    public int pos;
    public string nodeName;
    public string desc;
  }
  [SerializeField] private TreeNode[] nodes;
  public List<int> nodesOwned = new List<int>();

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}