using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]

    public float speed = 3f;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public Animator animator;
    bool left = false;
    public Transform attackPointRight;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    bool attacking = false;
    

    void MovePlayer(Vector3 input) {
        if(input.x < 0)
        {
            animator.Play("WalkLeft");
        }
        else if(input.x > 0)
        {
            animator.Play("WalkRight");
        }
        rb2d.transform.position += input;
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update () {
        bool moving = false;
        if (Input.GetButton("Right")) {
            StopAllCoroutines();
             MovePlayer(Vector3.right * speed * Time.deltaTime);
             moving = true;
             left = false;
             attacking = false;
        }
        if(Input.GetButton("Left")) {
            StopAllCoroutines();
            MovePlayer(Vector3.left * speed * Time.deltaTime);
            moving = true;
            left = true; 
            attacking = false;
        }
        if(Input.GetButton("Up")) {
            MovePlayer(Vector3.up * speed * Time.deltaTime);
            moving = true;
        }
        if(Input.GetButton("Down")) {
            MovePlayer(Vector3.down * speed * Time.deltaTime);
            moving = true;
        }
        if(Input.GetButton("Attack")) {
            if(left == true && attacking == false)
            {
                StartCoroutine(AttackLeft());
            }
            else if(attacking == false)
                StartCoroutine(AttackRight());
        }
        else if(!moving && !attacking) {
            if(!left)
                animator.Play("IdleKnight");
            else
                animator.Play("IdleKnightLeft");
        }
     }

    IEnumerator AttackRight() {
        attacking = true;
        animator.Play("KnightAttack");
        yield return new WaitForSeconds(0.5f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Blob>().TakeDamage(attackDamage);
        }
        animator.Play("IdleKnight");
        yield return new WaitForSeconds(2);
        attacking = false;
    }

    IEnumerator AttackLeft() {
        attacking = true;
        animator.Play("KnightAttackLeft");
        yield return new WaitForSeconds(0.5f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Blob>().TakeDamage(attackDamage);
        }
        animator.Play("IdleKnightLeft");
        yield return new WaitForSeconds(2);
        attacking = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPointRight == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
    }
    // public void OnMove(InputValue value)
    // {
    //     moveInput = value.Get<Vector2>();
    // }
}
