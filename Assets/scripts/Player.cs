using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    public bool isGrounded;
    public float jumpSpeed = 5;
    public LayerMask groundLayer;
    public bool isAtLeftWall;
    public bool isAtRightWall;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = IsGrounded();
        isAtLeftWall = IsAtLeftWall();
        isAtRightWall = IsAtRightWall();
        var hor = Input.GetAxisRaw("Horizontal");
        
        if (isAtLeftWall || isAtRightWall)
        {
            hor = 0f;
        }
        else
        {
            rb.velocity = new Vector2(hor * moveSpeed, rb.velocity.y);
        }
        
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    bool IsGrounded()
    {

        float raycastDistance = 0.1f;
        return Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.down, raycastDistance, groundLayer);
    }

    bool IsAtLeftWall()
    {
        float raycastDistance = 0.1f;
        return Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size,0, Vector2.left, raycastDistance, groundLayer);
    }

    bool IsAtRightWall()
    {
        float raycastDistance = 0.1f;
        return Physics2D.BoxCast(GetComponent<BoxCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.right, raycastDistance, groundLayer);
    }
}
