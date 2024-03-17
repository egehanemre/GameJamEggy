using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveDirection;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        IsVerticalMovement();
        IsHorizontalMovement();
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void IsVerticalMovement()
    {
        if (moveDirection.y > 0)
        {
            anim.SetInteger("Vertical", 1);
        }
        else if (moveDirection.y < 0)
        {
            anim.SetInteger("Vertical", -1);
        }
        else
        {
            anim.SetInteger("Vertical", 0);
        }
    }

    void IsHorizontalMovement()
    {
        if (moveDirection.x > 0)
        {
            anim.SetInteger("Horizontal", 1);
            spriteRenderer.flipX = true;
        }
        else if (moveDirection.x < 0)
        {
            anim.SetInteger("Horizontal", -1);
            spriteRenderer.flipX = false;
        }
        else
        {
            anim.SetInteger("Horizontal", 0);
        }
    }
}
