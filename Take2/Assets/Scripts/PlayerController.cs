using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    [Header("Jumping")]
    public float jumpForce;
    public int maxJumpTime;
    private float jumpTime;
    public float maxJumps;
    private float currentJumps;
    private int currentJumpTime=0;
    
    public int jumpBufferTime; // Time before air time

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    void AirTime()
    {
        // Extends jump, aka airtime
        if (Input.GetKey(KeyCode.Space) && currentJumpTime > 0)
        {    
            if (currentJumpTime < maxJumpTime-1)
            {rb.AddForce(Vector2.up * (jumpForce*.75f));}
            currentJumpTime--;
        }
    }

    void FastFall()
    {
        if (Input.GetKey(KeyCode.S))
        {
            
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x,0);    
            }

            rb.AddForce(Vector2.down* (rb.gravityScale * 5),ForceMode2D.Impulse);
        }
    }
    void Update()
    {

        AirTime();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        FastFall();

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        resetJumps();
    }

    void FixedUpdate()
    {
        
        
        
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(h * speed, rb.velocity.y);
        rb.velocity = movement;
    }


    void resetJumps()
    {
        currentJumps = maxJumps;
    }
    
    void Jump()
    {
        if (currentJumps > 0)
        {
            currentJumps--;
            currentJumpTime = maxJumpTime+jumpBufferTime;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
