using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    public bool isGrounded;
    public float jumpSpeed = 5;
    public LayerMask groundLayer;
    public bool isAtLeftWall;
    public bool isAtRightWall;
    public Animator animator;
    public Camera cam;
    public int hp = 3;
    public GameObject HighHp;
    public GameObject MidHp;
    public GameObject LowHp;
    public List<GameObject> checkpoint;
    public int whitchCheckpoint = 0;
    
    AudioSource source;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

    }

    void Update()
    {
        isGrounded = IsGrounded();
        isAtLeftWall = IsAtLeftWall();
        isAtRightWall = IsAtRightWall();
        var hor = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(hor));
        animator.SetBool("jump", isGrounded);
        if (isAtLeftWall && hor < 0 || isAtRightWall && hor > 0)
        {
            hor = 0f;
        }

        rb.velocity = new Vector2(hor * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            source.Play();
        }

        if (hor > 0)
        {
            transform.localScale = new Vector2(1,1);

        }
        else if (hor < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x > 1.0f)
        {
            cam.transform.position += new Vector3(17.9f, 0, 0);
        }
        else if (viewPos.x < 0.0f)
        {
            cam.transform.position -= new Vector3(17.9f, 0, 0);
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


    void Death()
    {
        transform.position = checkpoint[whitchCheckpoint].transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "owie")
        {
            Death();
            hp--;
            if (hp == 2)
            {
                HighHp.GetComponent<SpriteRenderer>().enabled = false;
                MidHp.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (hp == 1)
            {
                MidHp.GetComponent<SpriteRenderer>().enabled = false;
                LowHp.GetComponent<SpriteRenderer>().enabled = true;

            }



            if (hp < 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (collision.gameObject.tag == "checkpoint")
        {
            whitchCheckpoint++;
            checkpoint[whitchCheckpoint].GetComponent<BoxCollider2D>().enabled = false;
        }
    }


}
