using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    private AudioSource audioSource;
    public AudioClip swordSwing;
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    public void Playbang()
    {
        audioSource.clip = swordSwing;
        audioSource.Play();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Playbang();
        if(currentHealth >= 0)
        {
            
            animator.SetTrigger("hit");
        }
        

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    
    void Die()
    {

        Debug.Log("DIe");
        animator.SetFloat("death", 0f);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
    }
    
    
    void Update()
    {
        
    }
}
