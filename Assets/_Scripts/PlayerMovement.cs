using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.0f;
    public float deltaSpeed = 3.0f;
    public float jumpForce = 12.0f;
    public float bumpForce = 3.0f;
    public BoxCollider2D groundCollider;

    private Rigidbody2D rb;
    private const float gravity = 2.0f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool idle, walking, jumping;

    // Improvements to consider:
    // - Double jump

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        idle = false;
        walking = false;
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._gameOver)
        {
            return;
        }


        Vector3 vel = rb.velocity;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            vel.x -= deltaSpeed * Time.deltaTime;

            if (vel.x < -speed)
            {
                vel.x = -speed;
            }

            if (!walking)
            {
                animator.Play("Walk");
                walking = true;
            }
            idle = false;
            jumping = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
            vel.x += deltaSpeed * Time.deltaTime;
            if (vel.x > speed)
            {
                vel.x = speed;
            }
            if (!walking)
            {
                animator.Play("Walk");
                walking = true;
            }
            idle = false;
            jumping = false;
        }
        else
        {
            vel.x = 0;
            if (!idle && IsGrounded())
            {
                animator.Play("Idle");
                idle = true;
            }

            walking = false;
            jumping = false;
        }
        rb.velocity = vel;
        Debug.Log(vel.y > 0);


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            if (!jumping && vel.y > 0)
            {
                animator.Play("Jump");
                jumping = true;
            }

            idle = false;
            walking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground")) animator.Play("Idle");

        if (collision.transform.CompareTag("Enemy"))
        {
            //take a life 
            GameManager.SubtractLife();

            //bounce the player back
            Vector2 myCenter = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            myCenter.y = contactPoint.y;
            Vector3 forceVector = myCenter - contactPoint;
            forceVector.y += 0.5f;

            rb.AddForce(forceVector * bumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            //add points for the enemy
            GameManager.score += 100;

            //destroy the enemy
            Destroy(collision.gameObject);
        }
    }

    private bool IsGrounded()
    {
         return groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
