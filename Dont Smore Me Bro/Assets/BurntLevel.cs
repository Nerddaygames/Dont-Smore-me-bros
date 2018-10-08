using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurntLevel : MonoBehaviour 
{
    private float burntTimer;
    [SerializeField]
    private float burntTime = 10.0f;

    [SerializeField]
    Color color1;
    [SerializeField]
    Color color2;
    [SerializeField]
    Color color3;
    [SerializeField]
    private int step;

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () 
    {
        sr = GetComponent<SpriteRenderer>();
        ResetColors();
        burntTime = Time.time;
	}

	private void ResetTimer()
    {
        burntTimer = Time.time + burntTime;
    }


    public void StepColor()
    {
        if(burntTimer < Time.time)
        {
            ResetTimer();

            step++;
            switch(step)
            {
                case 1:
                    sr.color = color1;
                    break;
                case 2:
                    sr.color = color2;
                    break;
                case 3:
                    sr.color = color3;
                    break;
            }

        }

    }

    public void ResetColors()
    {
        step = 0;
        sr.color = Color.white;
    }

}
