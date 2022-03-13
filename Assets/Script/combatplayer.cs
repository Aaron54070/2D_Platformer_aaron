using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatplayer : MonoBehaviour
{
    public Animator animator;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 50;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    private AudioSource audioSource;
    public AudioClip swordSwing;

    void Start()
    {
        
    }
    
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySwordSwing()
    {
        audioSource.clip = swordSwing;
        audioSource.Play();
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
    
            if (Input.GetKeyDown("x"))
            {
                Attack();
                PlaySwordSwing();
                //soundmanger.PlaySound("swing");
                //playing = GameObject.FindGameObjectWithTag("EFX").GetComponent<Playing>();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}

    

