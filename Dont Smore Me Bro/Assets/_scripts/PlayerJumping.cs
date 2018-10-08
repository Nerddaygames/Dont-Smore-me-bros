using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour 
{
    [SerializeField]
    private int numberOfJumps = 1;
    [SerializeField]
    private float jumpStartForce = 10.0f;
    [SerializeField]
    private float jumpContinueForce = 2.0f;

    private int jumpsUsed = 0;
    private bool isJumpPressed = false;
    private bool isJumpReleased = false;
    private bool isJumpHeld = false;
    private bool isJumping = false;

    [SerializeField]
    private bool gL;
    [SerializeField]
    private bool gR;

    private Rigidbody2D rb;
    private PlayerGroundCheck playerGroundCheck;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        playerGroundCheck = GetComponent<PlayerGroundCheck>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        isJumpPressed = Input.GetButtonDown("Jump");
        isJumpHeld = Input.GetButtonDown("Jump");
        if(Input.GetButtonUp("Jump") == true)
        {
            isJumpReleased = true;
        }
        /*
        if(Input.GetButtonUp("Jump") == false)
        {
            isJumpHeld = false;
        }
        */

        gL = playerGroundCheck.IsLeftGrounded();
        gR = playerGroundCheck.IsRightGrounded();

        if(playerGroundCheck.IsLeftGrounded() || playerGroundCheck.IsRightGrounded())
        {
            isJumping = false;
            // isJumpReleased = false;
        }
        else
        {
            isJumping = true;
        }
	}

    private void FixedUpdate()
    {
        if(isJumpPressed && !isJumping)
        {
            isJumping = true;

            StartJump();
        }


        if(isJumping && !isJumpReleased)
        {
            ContinueJump();
        }
    }

    private void StartJump()
    {
        isJumpReleased = false;
        Vector2 jumpForce = transform.up * (jumpStartForce * Time.deltaTime);
        Vector2 newVel = rb.velocity + jumpForce;
        rb.velocity = newVel;
    }

    private void ContinueJump()
    {
        Vector2 jumpForce = transform.up * (jumpContinueForce * Time.deltaTime);
        Vector2 newVel = rb.velocity + jumpForce;
        rb.velocity = newVel;
    }

}
