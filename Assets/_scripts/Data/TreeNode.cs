using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeNode : MonoBehaviour
{
  private NodeView nodeView;
  public int ID;
  public string nodeName = "";
  public string description = "";
  public int[] requiredNodesIds;
  [HideInInspector]
  public bool isUnlockable = false;
  void Start()
  {
    this.nodeView = GameObject.FindWithTag("NodeView").GetComponent<NodeView>();
    this.gameObject.GetComponent<Button>().onClick.AddListener(OnNodeClick);
  }

  void OnNodeClick()
  {
    this.nodeView.setView(this.nodeName, this.description, this.ID, this.isUnlockable);
  }
  void Update()
  {

  }
}
