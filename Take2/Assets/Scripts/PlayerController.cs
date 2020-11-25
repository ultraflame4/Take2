using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    [Header("Jumping")]
    public float jumpForce;
    public float maxJumpTime;
    private float jumpTime;
    public float maxJumps;
    private float currentJumps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(h * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }
}
