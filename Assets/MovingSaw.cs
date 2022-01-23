using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{

    [SerializeField]  float distance;
    [SerializeField]  float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        leftEdge = transform.position.x - distance;
        rightEdge = transform.position.x + distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y,
                    transform.position.z);
            }
            else movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y,
                    transform.position.z);

            }
            else movingLeft = true;
            
        }
    }
}
