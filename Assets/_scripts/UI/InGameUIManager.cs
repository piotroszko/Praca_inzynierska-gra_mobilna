using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
  public GameObject InGameMenuCanvas;
  public GameObject MenuCanvas;
  // Start is called before the first frame update
  void Start()
  {

  }
  public void OpenMenu()
  {
    this.InGameMenuCanvas.SetActive(false);
    this.MenuCanvas.SetActive(true);

  }

  // Update is called once per frame
  void Update()
  {

  }
}
