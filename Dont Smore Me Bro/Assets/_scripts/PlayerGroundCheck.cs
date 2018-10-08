using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour 
{
    [SerializeField]
    private float radius = 0.15f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheckRight;
    [SerializeField]
    private Transform groundCheckLeft;


	// Use this for initialization
	void Start () 
    {
		
	}
	
    public bool IsRightGrounded()
    {
        // bool isGrounded = Physics.CheckSphere(pos, radius, groundLayer);
        return Physics2D.OverlapCircle(groundCheckRight.position, radius, groundLayer);
    }

    public bool IsLeftGrounded()
    {
        // bool isGrounded = Physics.CheckSphere(pos, radius, groundLayer);
        return Physics2D.OverlapCircle(groundCheckLeft.position, radius, groundLayer);
    }
}
