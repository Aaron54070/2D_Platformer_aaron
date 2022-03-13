using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Camera cam;
    public float jumpForce;
    public Transform ceillingCheak;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;
    public Animator animator;
    Vector2 movement;
    float movemnter = 0f;
   
    private void Awake() 
        {
            rb = GetComponent<Rigidbody2D>();
        }

    private void Start()
    {
        jumpCount = maxJumpCount;
    } 
    
    void Update() 
        {
            movemnter = Input.GetAxisRaw("Horizontal") * moveSpeed;
            processInputs();
            Animate();
            animator.SetFloat("moveSpeed", Mathf.Abs(movemnter));

        }
    void FixedUpdate()
    {
        Move();
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
            jumpCount = maxJumpCount;
        }
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jumpCount--;
        }
        isJumping = false;
    }
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void processInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
        
}
