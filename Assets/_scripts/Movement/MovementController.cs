using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float speed = 200;
    [SerializeField] float jumpPower = 200;
    private Vector2 move;
    private Rigidbody2D rb;
    bool isOnGround = true;
    private float timeAllowNextJump = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Giving velocity + dont need y
        rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Getting inputs
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        Flip();
        Jump();
        
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {    //blocking infinitive jumping
            isOnGround = true;
        }
    }
    
    //Jumping
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround == true && Time.time > timeAllowNextJump)
        {
            isOnGround = false;
            Debug.Log(isOnGround);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            timeAllowNextJump = Time.time + 1f;  
            
        }
    }

    //Method for flipping
    void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 )
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
