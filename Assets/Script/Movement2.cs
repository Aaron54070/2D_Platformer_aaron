using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float moveSpeed;
    private bool facingRight = true;
    private float moveDirection;
    public float jumpForce;
    float xInput, yInput;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    SpriteRenderer sp;

    private void Awake() 
        {
            rb = GetComponent<Rigidbody2D>();
            sp = GetComponent<SpriteRenderer>();
        }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            
        }
    }
    void PMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);

        PMove();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
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
    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
}
