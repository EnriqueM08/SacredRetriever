using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blub : MonoBehaviour
{
    public int maxHealth = 50;
    int currentHealth;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayers;
    public int attackDamage = 20;
    bool canAttack = true;

    void Start()
    {
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
        Debug.Log("RAN");
        currentHealth -= damage;
        //transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        if(currentHealth <= 0)
        {
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        Debug.Log("Enemy died!");
        animator.Play("BlobDeath");
        currentHealth = 20;
        yield return new WaitForSeconds(.1f);
        canAttack = true;
    }

    public void Attack() {
        //attacking = true;
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, PlayerLayers);
        foreach(Collider2D player in hitPlayer)
        {
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

    public GameObject spawn() {
        return GameObject.Instantiate(gameObject.transform.parent.gameObject);
    }
}
