using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce;
    Rigidbody2D rb;
    public float maxVelocity = 10f;
    public bool isGrounded;
    public float jumpSpeed = 5;
    public LayerMask groundLayer;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = IsGrounded();
        var hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(hor, 0) * Time.deltaTime * moveForce);
        LimitVelocity();
        print(rb.velocity);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity += Vector2.up * jumpSpeed;
        }
    }

    
    void LimitVelocity()
    {
        
        Vector2 currentVelocity = rb.velocity;
        float currentSpeed = currentVelocity.magnitude;
        if (currentSpeed > maxVelocity)
        { 
            Vector2 newVelocity = currentVelocity.normalized * maxVelocity;
            rb.velocity = newVelocity;
        }
    }

    bool IsGrounded()
    {

        float raycastDistance = 0.1f;
        return Physics.Raycast(GetComponent<BoxCollider2D>().bounds.center, Vector2.down, GetComponent<BoxCollider2D>().bounds.extents.y + raycastDistance, groundLayer);
    }
}
