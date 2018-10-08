using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]
    private float threshold = 0.2f;
    [SerializeField]
    private float runningSpeed = 800.0f;
    [SerializeField]
    private float airSpeed = 600.0f;
    [SerializeField]
    private float airDrag = 0.98f;
    [SerializeField]
    private bool grounded = false;
    [SerializeField]
    private bool wasGroundedLastFrame = false;

    private float currentSpeed = 0.0f;
    private float input = 0.0f;
    private Rigidbody2D rb;
    private PlayerGroundCheck groundCheck;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<PlayerGroundCheck>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        input = Input.GetAxisRaw("Horizontal");

        CheckIfGrounded();

        if(grounded)
        {
            OnGroundMovement();
        }
        else
        {
            InAirMovement();
        }


	}

    private void CheckIfGrounded()
    {
        // TODO is wasGroundedLastFrame redundant? 
        // used for if checking grounded with velocity.y == 0(not with floats)
        if (groundCheck.IsLeftGrounded() || groundCheck.IsRightGrounded())
        {
            if(wasGroundedLastFrame)
            {
                wasGroundedLastFrame = false;
                grounded = true;
            }
            else
            {
                wasGroundedLastFrame = true;
            }

        }
        else
        {
            wasGroundedLastFrame = false;
            grounded = false;
        }

    }


    private void OnGroundMovement()
    {
        if (input > threshold)
        {
            input = 1.0f;

        }
        else if(input < -threshold)
        {
            input = -1.0f;
        }
        else
        {
            currentSpeed = 0.0f;
        }

        currentSpeed = runningSpeed * input;
    }

    private void InAirMovement()
    {
        if (input > threshold || input < -threshold)
        {
            currentSpeed += airSpeed * input;
            currentSpeed = Mathf.Clamp(currentSpeed, -airSpeed, airSpeed);
        }
        else
        {
            Vector2 currentVel = rb.velocity;
            currentVel.x *= airDrag;
            rb.velocity = currentVel;
        }


    }


    private void FixedUpdate()
    {
        /*
        Vector2 moveForce = transform.right * (currentSpeed * Time.deltaTime);
        Vector2 newVel = rb.velocity + moveForce;
        rb.velocity = newVel;
        */
        Vector2 newVel = rb.velocity;
        float moveSpeed = currentSpeed * Time.deltaTime;
        newVel.x = moveSpeed;
        rb.velocity = newVel;
    }
}
