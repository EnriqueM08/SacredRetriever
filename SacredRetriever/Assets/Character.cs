using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [Header("Movement")]

    public float speed = 3f;
    public PlayerInput playerActions;
    private Vector2 movement;
    private Rigidbody2D rb2d;
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
    public LevelHandler levelHandler;
    private bool attackPressed = false;
    bool walking = false;
    public bool inFire = false;
    public bool recovered = false;
    public bool firstAttack = false;
    public AudioSource walkSound;
    public AudioSource attackSound;
    public AudioSource hurtSound;
    public AudioSource regenHealth;
    public AudioSource pickupItem;
    public AudioSource music;
    public bool playingDeath = false;


    private void OnMovement (InputValue value) {
        movement = value.Get<Vector2>();
        walking = true;
    }

    private void OnAttack() {
        if(!playingAttackAnimation)
            attackPressed = true;
        if(!firstAttack)
            firstAttack = true;
    }

    private void OnPauseGame() {
        levelHandler.PauseGame();
    }

    void MovePlayer() {
        if(movement.x < 0)
        {
            animator.Play("WalkLeft");
            left = true;
        }
        else if(movement.x > 0)
        {
            animator.Play("WalkRight");
            left = false;
        }
        else if(movement.y != 0){
            if(left) {
                animator.Play("WalkLeft");
            }
            else
                animator.Play("WalkRight");
        }
        if(movement.x == 0 && movement.y == 0)
            walking = false;
        else{
            StopAllCoroutines();
            rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
        }
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        levelHandler = GameObject.FindGameObjectWithTag("LevelHandler").GetComponent<LevelHandler>();
        music = GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioSource>();
        switch (PlayerPrefs.GetInt("difficulty"))
        {
                case 0:
                    maxHealth = 500;
                    break;
                case 1:
                    maxHealth = 300;
                    break;
                case 2:
                    maxHealth = 200;
                    break;
                case 3:
                    maxHealth = 100;
                    break;
        }
        currentHealth = maxHealth;
    }

    private void FixedUpdate() {
        if(inFire)
            TakeDamage(1);
        if(!LevelHandler.isPaused) {
            bool moving = false;
            if(!playingAttackAnimation && !playingDeath) {
                if(walking) {
                    MovePlayer();
                    attacking = false;
                    moving = true;
                    if(!walkSound.isPlaying)
                        walkSound.Play();
                }
                else
                    walkSound.Stop();
                if(attackPressed) {
                    if(left == true && attacking == false)
                    {
                        StartCoroutine(AttackLeft());
                    }
                    else if(attacking == false)
                        StartCoroutine(AttackRight());
                    attackPressed = false;
                }
            }
            if(!moving && !attacking && !playingDeath) {
                if(!left)
                    animator.Play("IdleRight");
                else
                    animator.Play("IdleLeft");
            }
        }
    }

    IEnumerator AttackRight() {
        attacking = true;
        playingAttackAnimation = true;
        attackSound.Play();
        animator.Play("AttackRight");
        yield return new WaitForSeconds(0.75f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.tag == "Blob")
                enemy.GetComponent<Blob>().TakeDamage(attackDamage);
            else if(enemy.tag == "Spawner")
                enemy.GetComponent<Spawner>().TakeDamage(attackDamage);
        }
        playingAttackAnimation = false;
        animator.Play("IdleRight");
        //yield return new WaitForSeconds(2);
        attacking = false;
    }

    IEnumerator AttackLeft() {
        attacking = true;
        playingAttackAnimation = true;
        attackSound.Play();
        animator.Play("AttackLeft");
        yield return new WaitForSeconds(0.75f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.tag == "Blob")
                enemy.GetComponent<Blob>().TakeDamage(attackDamage);
            else if(enemy.tag == "Spawner")
                enemy.GetComponent<Spawner>().TakeDamage(attackDamage);
        }
        playingAttackAnimation = false;
        animator.Play("IdleLeft");
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
        if(currentHealth > 0) {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                StartCoroutine("EndGame");
            }
            if(!hurtSound.isPlaying)
                hurtSound.Play();
            healthBar.UpdateHealthBar();
        }
        
    }

    IEnumerator EndGame()
    {
        //Add death animation
        playingDeath = true;
        animator.Play("Death");
        yield return new WaitForSeconds(2.5f);
        isDead = true;
    }

    void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.CompareTag("SacredItem"))
        {
            Destroy(other.gameObject);
            hasTreasure = true;
            music.Stop();
            pickupItem.Play();
        }
        if(other.gameObject.CompareTag("Fire")) {
            inFire = true;
        }
        if(other.gameObject.CompareTag("HealthDrop")) {
            currentHealth = maxHealth;
            recovered = true;
            Destroy(other.gameObject);
            healthBar.UpdateHealthBar();
            regenHealth.Play();
        }
     }

     void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Fire"))
            inFire = false;
     }
}
