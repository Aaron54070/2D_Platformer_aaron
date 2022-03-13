using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(currentHealth >= 0)
        {
            currentHealth -= damage;
            animator.SetTrigger("Hit");
        }
        

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    
    void Die()
    {

        Debug.Log("DIe");
        animator.SetBool("Dead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<BossAttack>().enabled = false;
        GetComponent<BossAIWalk>().enabled = false;
        this.enabled = false;
    }
    
    
    void Update()
    {
        
    }
}
