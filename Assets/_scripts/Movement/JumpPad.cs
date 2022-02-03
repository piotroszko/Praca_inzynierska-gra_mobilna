using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    private GameObject player;
    private float gravityValue = -9.81f;
    [SerializeField] float forceForJumpPad = 1.0f;
    private Animator anim;
    private float timeAllowNextCollision = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        
        if (hit.gameObject.tag == "Player" && Time.time > timeAllowNextCollision)
        {
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * gravityValue * forceForJumpPad * -0.75f, ForceMode2D.Impulse);
            timeAllowNextCollision = Time.time + .1f;
            player.GetComponent<Animator>().Play("Jump");
        }
    }
    
}
