using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    float speed;
    Rigidbody2D rigidBody;
    Animator anim;
    public bool isWalker;
    public bool isStatic;
    public bool walksRight;
    public bool isPatrol;
    public float timeToWait;
    public bool shouldWaiting;
    public bool isWaiting;

    public Transform wallCheck, pitCheck, groundCheck;
    public bool wallDetected, pitDetected, isGrounded;
    public float detectedRadious;
    public LayerMask whatIsGround;

    public Transform pointA;
    public Transform pointB;

    public bool goToA;
    public bool goToB;


    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speed;
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print(rigidBody);
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectedRadious, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectedRadious, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectedRadious, whatIsGround);

        if ((pitDetected || wallDetected) && isGrounded)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        //if (isStatic)
        //{
        //    anim.SetBool("Idle", true);
        //}
        //rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

        if (isWalker)
        {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!walksRight)
            {
                rigidBody.velocity = new Vector2(-speed * Time.deltaTime, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(speed * Time.deltaTime, rigidBody.velocity.y);
            }
        }
        if (isStatic)
        {
            anim.SetBool("Idle", true);
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            if (goToA)
            {
                if(!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rigidBody.velocity = new Vector2(-speed * Time.deltaTime, rigidBody.velocity.y);
                }
                

                if (Vector2.Distance(transform.position, pointA.position) < 0.2f)
                {
                    if (shouldWaiting)
                    {
                        StartCoroutine(Waiting());
                    }
                    Flip();
                    goToA = false;
                    goToB = true;
                }
            }
            if (goToB)
            {

                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rigidBody.velocity = new Vector2(speed * Time.deltaTime, rigidBody.velocity.y);
                }

                if (Vector2.Distance(transform.position, pointB.position) < 0.2f)
                {
                    if (shouldWaiting)
                    {
                        StartCoroutine(Waiting());
                    }
                    Flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }

    public void Flip()
    {
        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1, 1);
    }

    IEnumerator Waiting()
    {
        anim.SetBool("Idle", true);
        isWaiting = true;
        Flip();
        yield return new WaitForSeconds(timeToWait);
        isWaiting = false;
        anim.SetBool("Idle", false);
        Flip();
    }
}
