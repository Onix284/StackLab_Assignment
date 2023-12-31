
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private Animator anime;
    [SerializeField] private LayerMask jumpmingGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private enum MovementState{idle, running, jumping, falling}
    private float dirX = 0f;

    [SerializeField] private AudioSource jumpSound;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

   
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        AnimationUpdate();
       
    }

    private void AnimationUpdate()
    {
        MovementState state;
        if(dirX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if(dirX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
           state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anime.SetInteger("state", (int) state);
    }


    private bool isGrounded()
    {
       return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpmingGround);
    }
}
