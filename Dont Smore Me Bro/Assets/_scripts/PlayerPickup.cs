using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour 
{
    private FlyTowardsPlayer flyTowardsPlayer;

	// Use this for initialization
	void Start () 
	{
        flyTowardsPlayer = GetComponent<FlyTowardsPlayer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        if(collision.CompareTag("CoinAttractor"))
        {
            // move towards player
            flyTowardsPlayer.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
