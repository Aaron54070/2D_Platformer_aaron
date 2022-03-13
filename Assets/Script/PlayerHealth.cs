using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int Respawn;
    public int maxHealth = 100;
    int currentHealth;
    public healthbar healthbar;
    private AudioSource audioSource;
    public AudioClip swordSwing;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    public void Playdead()
    {
        audioSource.clip = swordSwing;
        audioSource.Play();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if(currentHealth >= 0)
        {
            Debug.Log("player hit");
            animator.SetTrigger("Hit");
        }
        

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    
    void Die()
    {
        Playdead();
        Debug.Log("PLAYER DIed");
        //animator.SetBool("death", true);
        animator.SetTrigger("death");
        //Thread.Sleep(5000);
        this.enabled = false;
        GetComponent<Movement>().enabled =  false;
        GetComponent<combatplayer>().enabled =  false;


    }
    
    
    void Update()
    {
        
    }
}
