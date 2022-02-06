using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public GameObject slider;
    private float min = 0f;
    private float max = 1.3f;
    public void SetHealth(float percent)
    {   

        if(1f >= percent && percent > 0f){
            slider.transform.localScale = new Vector3(percent * max, slider.transform.localScale.y, slider.transform.localScale.z);
        }
    }
    void Start(){
        SetHealth(1f);
    }

}