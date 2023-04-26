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
    public Transform attackPointLeft;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    bool attacking = false;
    public float maxHealth = 1000;
    public float currentHealth;
    public bool isDead = false;
    public bool hasTreasure = false;
    public HealthBar healthBar;
    private bool playingAttackAnimation = false;
    

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
        currentHealth = maxHealth;
    }

    void Update () {
        bool moving = false;
        if(!playingAttackAnimation) {
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
        }
        if(!moving && !attacking) {
            if(!left)
                animator.Play("IdleKnight");
            else
                animator.Play("IdleKnightLeft");
        }
     }

    IEnumerator AttackRight() {
        attacking = true;
        playingAttackAnimation = true;
        animator.Play("KnightAttack");
        yield return new WaitForSeconds(0.5f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.tag == "Blob")
                enemy.GetComponent<Blob>().TakeDamage(attackDamage);
            else if(enemy.tag == "Spawner")
                enemy.GetComponent<Spawner>().TakeDamage(attackDamage);
        }
        playingAttackAnimation = false;
        animator.Play("IdleKnight");
        //yield return new WaitForSeconds(2);
        attacking = false;
    }

    IEnumerator AttackLeft() {
        attacking = true;
        playingAttackAnimation = true;
        animator.Play("KnightAttackLeft");
        yield return new WaitForSeconds(0.5f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.tag == "Blob")
                enemy.GetComponent<Blob>().TakeDamage(attackDamage);
            else if(enemy.tag == "Spawner")
                enemy.GetComponent<Spawner>().TakeDamage(attackDamage);
        }
        playingAttackAnimation = false;
        animator.Play("IdleKnightLeft");
        //yield return new WaitForSeconds(2);
        attacking = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPointRight == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
        if(attackPointLeft == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("DAMAGE");
        currentHealth -= damage;
        healthBar.UpdateHealthBar();
        //transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        if(currentHealth <= 0)
        {
            StartCoroutine("EndGame");
        }
    }

    IEnumerator EndGame()
    {
        Debug.Log("Player died!");
        //Add death animation
        yield return new WaitForSeconds(1f);
        isDead = true;
    }

    void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.CompareTag("SacredItem"))
        {
            Debug.Log("RAN");
            Destroy(other.gameObject);
            hasTreasure = true;
        }
     }
    // public void OnMove(InputValue value)
    // {
    //     moveInput = value.Get<Vector2>();
    // }
}
