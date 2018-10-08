using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHazards : MonoBehaviour 
{
    private BurntLevel burntLevel;


	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 1.0f;
        burntLevel = GetComponentInChildren<BurntLevel>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("FireMonster"))
        {
            // gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FireMonster"))
        {
            burntLevel.StepColor();
            Time.timeScale = 0.5f;

            gameObject.SetActive(false);
        }

        if(collision.CompareTag("HeatRange"))
        {
            burntLevel.StepColor();
        }

    }
}
