using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingPlatform : MonoBehaviour
{
    public float objectSpeed = 2f;
    public float distance = 6.6f;
    private bool isRunningRight = true;
    private bool isRunningLeft = false;
    private float leftPosition;
    private float rightPostion;
    
    
    void Start()
    {
        rightPostion = transform.position.x + distance;
        leftPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        if (isRunningRight)
        {
            Vector3 move = transform.right * objectSpeed * Time.deltaTime;
            transform.Translate(move);

        }
        else if(isRunningLeft)
        {
            Vector3 move = transform.right * -objectSpeed * Time.deltaTime;
            transform.Translate(move);
            
        }
        
    }

    private void Update()
    {
        if (transform.position.x >= rightPostion)
        {
            isRunningLeft = true;
            isRunningRight = false;
        }
        else if (transform.position.x <= leftPosition)
        {
            isRunningRight = true;
            isRunningLeft = false;
   
                
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = transform;
        }
        
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }

    

}