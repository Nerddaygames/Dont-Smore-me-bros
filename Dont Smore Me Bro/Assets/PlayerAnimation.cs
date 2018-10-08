using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{

    private Animator anim;
    private Rigidbody2D rb;
    private PlayerGroundCheck playerGroundCheck;

	// Use this for initialization
	void Start () 
	{
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerGroundCheck = GetComponent<PlayerGroundCheck>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(playerGroundCheck.IsLeftGrounded() || playerGroundCheck.IsRightGrounded())
        {
            anim.SetFloat("HSpeed", Input.GetAxisRaw("Horizontal"));
        }
        else
        {
            anim.SetFloat("HSpeed", 0.0f);
        }

        Vector2 movement = rb.velocity.normalized;
        anim.SetFloat("VSpeed", movement.y);
	}
}
