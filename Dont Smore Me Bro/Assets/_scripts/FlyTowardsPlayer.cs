using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsPlayer : MonoBehaviour 
{
    [SerializeField]
    private bool isEnabled = false;
    [SerializeField]
    private float flySpeed = 5.0f;
    [SerializeField]
    private float minDistance = 0.2f;

    private Transform playerTransform;

	// Use this for initialization
	void Start () 
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void FixedUpdate()
    {
        if (isEnabled)
        {
            Move();
        }
    }

    private void Move()
    {
        // rb.velocity = Vector2.MoveTowards (transform.position, target.position, step);
        Vector2 movement = Vector2.MoveTowards(transform.position, playerTransform.position, flySpeed);
        transform.position = movement;
    }

    public void Enable()
    {
        isEnabled = true;
    }
}
