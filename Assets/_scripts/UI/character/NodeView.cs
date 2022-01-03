using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeView : MonoBehaviour
{
  public TreeViewManager treeView;
  public GameObject title;
  public GameObject desc;
  public GameObject button;
  [HideInInspector]
  public int nodeID = 0;
  [HideInInspector]
  public bool isAvailableToUnlock = false;
  public void setView(string title, string desc, int ID, bool isAvailable)
  {
    this.title.GetComponent<UnityEngine.UI.Text>().text = title;
    this.desc.GetComponent<UnityEngine.UI.Text>().text = desc;
    this.nodeID = ID;
    this.isAvailableToUnlock = isAvailable;
    checkButton();
  }
  void checkButton()
  {
    if (isAvailableToUnlock == false || nodeID == 0)
    {
      this.button.SetActive(false);
    }
    else if (isAvailableToUnlock == true)
    {
      this.button.SetActive(true);
    }
  }
  void unlockNode()
  {
    if (isAvailableToUnlock == true)
    {
      this.treeView.unlockNode(this.nodeID);
      this.isAvailableToUnlock = false;
      checkButton();
    }
  }
  void OnEnable()
  {
    checkButton();
  }
  void Start()
  {
    this.title.GetComponent<UnityEngine.UI.Text>().text = "";
    this.desc.GetComponent<UnityEngine.UI.Text>().text = "";
    this.button.GetComponent<Button>().onClick.AddListener(unlockNode);
  }
  void Update()
  {

  }
}