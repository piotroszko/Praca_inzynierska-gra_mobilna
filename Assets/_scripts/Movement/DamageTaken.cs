using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    private Vector2 playerSpeed;
    [SerializeField] float force = 1.0f;
    private float gravityValue = -9.81f;
    private Rigidbody2D rb;

    public Health health;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Spikes")
        {
            health.Damage(5);
            rb.AddForce(Vector2.up * gravityValue * force * -0.75f, ForceMode2D.Impulse);
        }
            
    }
}
