using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using System;

public class MovementController : MonoBehaviour
{
    [SerializeField] float speed = 200;
    [SerializeField] float jumpPower = 200;
    private Vector2 move;
    private Rigidbody2D rb;
    private Animator anim;

    private StatisticsValues stats;

    //for ground checking
    public Transform groundCheckObject;
    public bool isOnGround = true;
    const float groundCheckRadius = 0.2f;
    public bool doubleJump;
    private int jumpValue = 0;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        stats = GameObject.FindWithTag("PlayerManager").GetComponent<StatisticsValues>();
    }

    private void FixedUpdate()
    {
        //Giving velocity + dont need y
        rb.velocity = new Vector2(move.x * speed * Time.deltaTime, rb.velocity.y);
        GroundCheck();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting inputs
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Flip();
        Jump();
        RunningAnimation();
        RecordDistance();
    }

    //Jumping
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isOnGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                this.stats.statsJumps++;
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                gameObject.GetComponent<PlayerCombatController>().amountOfJumpsFromLastKill++;
                if (doubleJump) jumpValue = 1;
            }
            else if (jumpValue == 1)
            {
                this.stats.statsJumps++;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jumpValue = 0;
                gameObject.GetComponent<PlayerCombatController>().amountOfJumpsFromLastKill++;
            }
        }
    }

    //Method for flipping
    void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void GroundCheck()
    {
        isOnGround = false;
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll(groundCheckObject.position, groundCheckRadius, LayerMask.GetMask("Ground"));

        if (colliders.Length > 0)
        {
            isOnGround = true;
        }
    }

    void RunningAnimation()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
        }
    }

    private Vector2 previousLoc;
    private float totalDistance;

    void RecordDistance()
    {
        float distance = Vector2.Distance(transform.position, previousLoc);
        previousLoc = transform.position;
        if (distance > 0.001f)
        {
            totalDistance += distance;
        }

        if (totalDistance > 4f)
        {
            stats.statsDistance += Convert.ToInt32(totalDistance / 4f);
            totalDistance = 0;
        }
    }
}