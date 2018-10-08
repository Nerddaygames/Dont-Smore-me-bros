using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipSprite : MonoBehaviour 
{
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () 
	{
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetAxisRaw("Horizontal") < 0.2f)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

	}
}
