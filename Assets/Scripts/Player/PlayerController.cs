using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D body;
    private Vector2 axisMovement;
    public Animator animator;

    void Start() { body = GetComponent<Rigidbody2D>(); }


    void Update() 
    {
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        axisMovement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(axisMovement.x));
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        body.velocity = axisMovement.normalized * speed;
        CheckForFlipping();
    }

    private void CheckForFlipping()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if (movingLeft)
        {
            transform.localScale = new Vector3(-6f, transform.localScale.y);
        }

        if (movingRight)
        {
            transform.localScale = new Vector3(6f, transform.localScale.y);
        }
    }
}

//    public float moveSpeed = 5f; // Adjust this value to control the player's movement speed

//    private Rigidbody2D rb;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    private void Update()
//    {
//        float horizontalInput = Input.GetAxis("Horizontal");
//        float verticalInput = Input.GetAxis("Vertical");

//        // Check if the player is moving primarily in the horizontal or vertical direction
//        bool isMovingHorizontally = Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput);

//        if (isMovingHorizontally)
//        {
//            rb.velocity = new Vector2(horizontalInput * moveSpeed, 0f);
//        }
//        else
//        {
//            rb.velocity = new Vector2(0f, verticalInput * moveSpeed);
//        }
//        CheckForFlipping();
//    }

//    private void CheckForFlipping()
//    {
//        bool movingLeft = axisMovement.x < 0;
//        bool movingRight = axisMovement.x > 0;

//        if(movingLeft)
//        {
//            transform.localScale = new Vector3(-1f, transform.localScale.y);
//        }

//        if (movingRight)
//        {
//            transform.localScale = new Vector3(1f, transform.localScale.y);
//        }
//    }
//}
