using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]

    public float speed = 3f;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    private Vector2 moveInput;
    private Animator animator;
    public AnimationStateChanger asc;
    

    public bool MovePlayer(Vector2 direction) {
        Vector2 moveVector = direction * speed * Time.fixedDeltaTime;
        rb2d.MovePosition(rb2d.position + moveVector);
        return true;
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // public void OnMove(InputValue value)
    // {
    //     moveInput = value.Get<Vector2>();
    // }
}
