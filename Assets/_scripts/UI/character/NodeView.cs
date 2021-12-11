using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeView : MonoBehaviour
{
  public GameObject title;
  public GameObject desc;
  public void setView(string title, string desc)
  {
    this.title.GetComponent<UnityEngine.UI.Text>().text = title;
    this.desc.GetComponent<UnityEngine.UI.Text>().text = desc;
  }
  void Start()
  {
    this.title.GetComponent<UnityEngine.UI.Text>().text = "";
    this.desc.GetComponent<UnityEngine.UI.Text>().text = "";
  }
  void Update()
  {

  }
}
