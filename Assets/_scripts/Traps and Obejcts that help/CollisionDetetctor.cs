using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetetctor : MonoBehaviour
{
    private Vector2 playerSpeed;
    [SerializeField] float force = 1.0f;
    private float gravityValue = -9.81f;
    private Rigidbody2D rb;
    [SerializeField] float forceForJumpPad = 1.0f;
    private float timeAllowNextCollision = 0f;
    public Health health;
    private int currentSceneIndex;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth <= 0)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Spikes" && Time.time > timeAllowNextCollision)
        {
            health.Damage(50);
            rb.AddForce(Vector2.up * gravityValue * force * -0.75f, ForceMode2D.Impulse);
            timeAllowNextCollision = Time.time + .1f;
        }
        if (hit.gameObject.tag == "JumpPad" && Time.time > timeAllowNextCollision)
        {
            rb.AddForce(Vector2.up * gravityValue * forceForJumpPad * -0.75f, ForceMode2D.Impulse);
            timeAllowNextCollision = Time.time + .1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BelowSpawner")
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
        
        
    }
    
    
    
}