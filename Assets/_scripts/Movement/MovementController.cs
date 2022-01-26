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

    public bool betterJump = false;
    public bool betterMovement = false;

    private Inventory inv;
    private CharacterValues chValues;

    //for ground checking
    public Transform groundCheckObject;
    public bool isOnGround = true;
    const float groundCheckRadius = 0.2f;
    public bool doubleJump;
    private int jumpValue = 0;
    public bool climbing;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        stats = GameObject.FindWithTag("PlayerManager").GetComponent<StatisticsValues>();
        chValues = GameObject.FindWithTag("PlayerManager").GetComponent<CharacterValues>();
        inv = GameObject.FindWithTag("PlayerManager").GetComponent<Inventory>();
    }
    float CalculatMovementSpeed() {
        IItemArmor eqCollar = inv.equippedCollar;
        IItemArmor eqCoat = inv.equippedCoat;
        float movement = 0f;
        float spd1 = 0f;
        if (eqCollar != null)
        {
        float spdTmp1 = eqCollar.movementSpeed + (eqCollar.upgradeInfo.sumTypeItem(false) * eqCollar.movementSpeed);
        spd1 = spdTmp1 + (eqCollar.upgradeInfo.sumTypeMoney(false) * spdTmp1);
        }
        float spd2 = 0f;
        if (eqCoat != null)
        {
        float spdTmp2 = eqCoat.movementSpeed + (eqCoat.upgradeInfo.sumTypeItem(false) * eqCoat.movementSpeed);
        spd2 = spdTmp2 + (eqCoat.upgradeInfo.sumTypeMoney(false) * spdTmp2);
        }
        movement += spd1 + spd2;
        
        if(this.betterMovement)
            movement += speed * 0.2f;
        movement += chValues.pointsSpeed / 10f;
        return movement;
    }

    private void FixedUpdate()
    {
        //Giving velocity + dont need y
        rb.velocity = new Vector2(move.x * (speed + CalculatMovementSpeed() ) * Time.deltaTime, rb.velocity.y);
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
                anim.Play("Jump");
                if (doubleJump) jumpValue = 1;
            }
            else if (jumpValue == 1)
            {
                this.stats.statsJumps++;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jumpValue = 0;
                gameObject.GetComponent<PlayerCombatController>().amountOfJumpsFromLastKill++;
                anim.Play("Jump");
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
            anim.SetBool("jump", false);
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