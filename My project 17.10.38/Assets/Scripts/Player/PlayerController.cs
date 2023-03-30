using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpHeight;
    float velX, velY;
    Rigidbody2D rigidBodyPlayer;
    public Transform groundCheck;
    public bool isGrounded;
    public float groundCheckRadius, horizontalMovement;
    public LayerMask whatIsGrounded;
    FloatingJoystick joystick;
    Animator animPlayer;
    public bool facingRight = true;

    public static PlayerController instance;

   

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        //joystick = FindObjectOfType<FloatingJoystick>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //camera.transform.position = transform.position;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGrounded);
       
        if(isGrounded)
        {
            animPlayer.SetBool("Jump", false);
        }
        else
        {
            animPlayer.SetBool("Jump", true);
        }

        Attack();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        FlipCharacter(horizontalMovement);
        Jump();
    }

    public void PlayerMovement()
    {
        velX = Input.GetAxisRaw("Horizontal");


        velY = rigidBodyPlayer.velocity.y;

        //velX = joystick.Horizontal;

        rigidBodyPlayer.velocity = new Vector2(velX * speed, velY);

        if(rigidBodyPlayer.velocity.x != 0)
        {
            animPlayer.SetBool("Move", true);
        }

        else
        {
            animPlayer.SetBool("Move", false);
        }
       
    }

    private void FlipCharacter(float horizontal)
    {

        //if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        //{
        //    facingRight = !facingRight;
        //    Vector3 theScale = transform.localScale;
        //    theScale.x *= -1;
        //    transform.localScale = theScale;
        //}

        if (velX > 0 )
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (velX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump()
    {
        if(Input.GetButton("Jump") && isGrounded)
        {
            rigidBodyPlayer.velocity = new Vector2(rigidBodyPlayer.velocity.x, jumpHeight);
        }
    }

    public void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            animPlayer.SetBool("Attack", true);
        }
        else
        {
            animPlayer.SetBool("Attack", false);
        }
    }

}
