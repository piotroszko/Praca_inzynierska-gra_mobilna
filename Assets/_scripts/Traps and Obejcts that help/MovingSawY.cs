using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSawY : MonoBehaviour
{

    [SerializeField]  float distance;
    [SerializeField]  float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        leftEdge = transform.position.y - distance;
        rightEdge = transform.position.y + distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.y > leftEdge)
            {
                transform.position = new Vector3(transform.position.x,transform.position.y - speed * Time.deltaTime ,
                    transform.position.z);
            }
            else movingLeft = false;
        }
        else
        {
            if (transform.position.y < rightEdge)
            {
                transform.position = new Vector3(transform.position.x,transform.position.y + speed * Time.deltaTime ,
                    transform.position.z);

            }
            else movingLeft = true;
            
        }
    }
}