using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyAi : MonoBehaviour
{
  // modifiers to speed, distances to obsticles and rigidbody
  public float speed;
  public float distance, wallDistance;

  public Rigidbody2D rb;

  //enemy start moving left
  private bool movingLeft = true;

  //Layer and checking for raycasts (empty objects)
  [SerializeField] Transform wallCheck;
  [SerializeField] Transform groundCheck;
  [SerializeField] Transform playerCheck;

  //player Transform
  public Transform player;
  //distance that enemy will chase our player
  [SerializeField] float agroRange;
  [SerializeField] float attackSpeed;
  float lastAttackDate;
  private Animator anim;
  

  RaycastHit2D hit, wallHit;

  private GameObject test;
  private void Start()
  {
    
  }

  private void Update()
  {
    //Patroling
    if(test == null)
    test = GameObject.FindGameObjectWithTag("Player");
    if(test != null)
    player = test.transform;
    anim = GetComponent<Animator>();

    hit = Physics2D.Raycast(groundCheck.position, Vector2.down, distance, LayerMask.GetMask("Ground"));
    wallHit = Physics2D.Raycast(wallCheck.position, Vector2.left, wallDistance, LayerMask.GetMask("Ground"));

    if (!hit.collider || wallHit.collider)
    {
      if (movingLeft)
      {
        transform.eulerAngles = new Vector3(0, -180, 0);
        movingLeft = false;
      }
      else
      {
        transform.eulerAngles = new Vector3(0, 0, 0);
        movingLeft = true;
      }

    }

    if (CanSeePlayer(agroRange))
      AttackPlayer();

  }

  //here script for attack
  private void AttackPlayer()
  {
    //Debug.Log("DoingAttack");
    if((Time.time - lastAttackDate > attackSpeed)) {
      lastAttackDate = Time.time;
      anim.Play("warrior");
      GetComponent<EnemyManager>().Attack();
      
      
    }
  }

  private void FixedUpdate()
  {
    Moving();
  }

  private void Moving()
  {
    if (movingLeft)
    {
      rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    else
    {
      rb.velocity = new Vector2(speed, rb.velocity.y);
    }
  }

  private void ChasePlayer()
  {
    if (transform.position.x < player.position.x)
    {
      movingLeft = false;
      transform.eulerAngles = new Vector3(0, -180, 0);
    }
    else
    {
      transform.eulerAngles = new Vector3(0, 0, 0);
      movingLeft = true;
    }
  }


  //for attacking
  bool CanSeePlayer(float distance)
  {

    //cast in good
    float castDistance = distance;

    if (!movingLeft)
      castDistance = -castDistance;

    //Debbuging you line to see how long and if it works
    bool temp = false;
    Vector2 endPos = playerCheck.position + Vector3.left * castDistance;

    RaycastHit2D hit2D = Physics2D.Linecast(playerCheck.position, endPos, LayerMask.GetMask("SomeAction"));


    if (hit2D.collider)
    {
      if (hit2D.collider.gameObject.CompareTag("Player"))
      {
        Debug.DrawLine(playerCheck.position, hit2D.point, Color.yellow);
        temp = true;
      }
      else
        temp = false;

    }
    else
    {
      Debug.DrawLine(playerCheck.position, endPos, Color.blue);
    }

    return temp;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !CanSeePlayer(agroRange))
    {
      if (transform.position.x < player.position.x)
      {
        StartCoroutine(myDelay());
        
      }

      else if(!CanSeePlayer(agroRange))
      {
        StartCoroutine(myDelay2());
        
        
      }
    }

  }

  IEnumerator myDelay()
  {
    yield return new WaitForSeconds(.5f);
    transform.eulerAngles = new Vector3(0, -180, 0);
    movingLeft = false;
    
  }
  
  IEnumerator myDelay2()
  {
    yield return new WaitForSeconds(.5f);
    transform.eulerAngles = new Vector3(0, 0, 0);
    movingLeft = true;
    
  }
  
}