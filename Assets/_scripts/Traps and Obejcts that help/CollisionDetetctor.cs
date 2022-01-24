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

    //prevent multipleCollisions at once
    private float timeAllowNextCollision = 0f;

    //get health
    public Health health;

    private int currentSceneIndex;

    //damage half for tree upgrades
    public bool halfDamage;
    private const int halfDamageNumber = 2;
    
    //for spawning
    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameController = GameObject.FindWithTag("GC").GetComponent<GameController>();
        transform.position = gameController.checkpoint;
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Spikes" && Time.time > timeAllowNextCollision)
        {
            TakeDamage();
            rb.AddForce(Vector2.up * gravityValue * force * -0.75f, ForceMode2D.Impulse);
            timeAllowNextCollision = Time.time + .1f;
        }

        if (hit.gameObject.tag == "Saw" && Time.time > timeAllowNextCollision)
        {
            TakeDamage();
            timeAllowNextCollision = Time.time + .1f;
        }

        if (hit.gameObject.tag == "JumpPad" && Time.time > timeAllowNextCollision)
        {
            rb.AddForce(Vector2.up * gravityValue * forceForJumpPad * -0.75f, ForceMode2D.Impulse);
            timeAllowNextCollision = Time.time + .1f;
        }
    }

    public void TakeDamage()
    {
        if (halfDamage)
            health.Damage(50 / halfDamageNumber);
        else
        {
            health.Damage(50);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BelowSpawner")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}