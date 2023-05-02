using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Blob : MonoBehaviour
{
    public int maxHealth = 20;
    int currentHealth;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayers;
    public int attackDamage = 20;
    bool canAttack = true;
    public PoolManager poolManager;
    private bool dead = false;
    public AudioSource attack;
    

    void Start()
    {
        switch (PlayerPrefs.GetInt("difficulty"))
        {
                case 0:
                case 1:
                    maxHealth = 20;
                    break;
                case 2:
                case 3:
                    maxHealth = 40;
                    break;
        }
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(canAttack)
        {
            Attack();
            StartCoroutine("AttackCoolDown");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        if(currentHealth <= 0)
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        dead = true;
        animator.Play("BlobDeath");
        currentHealth = 40;
        yield return new WaitForSeconds(.1f);
        canAttack = true;
        this.GetComponentInParent<AIPath>().canMove = true;
        poolManager.DespawnEnemy(this.transform.parent.gameObject);
        dead = false;
    }

    public void Attack() {
        //attacking = true;
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayers);
        foreach(Collider2D player in hitPlayer)
        {
            attack.Play();
            player.GetComponent<Character>().TakeDamage(attackDamage);
        }
        //attacking = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator AttackCoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(2);
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") {
            this.GetComponentInParent<AIPath>().canMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!dead)
        {
            if(other.gameObject.tag == "Player") {
                this.GetComponentInParent<AIPath>().canMove = true;
            }
        }
    }
}

