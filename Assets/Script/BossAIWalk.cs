using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAIWalk : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator;
    private bool facingRight = true;
    bool flip = true;
    bool flip1 = false;
    
    void movedirection()
    {
        
    }
    void Start()
    {
        
        //moveDirection = (transform.right*Time.deltaTime*moveSpeed).x;
    }

    void Update()
    {

        if(flip)
        {
            
            transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
            animator.SetBool("Run", true);
        }
        if(flip1)
        {
            
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
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
