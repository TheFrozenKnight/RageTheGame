using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    Vector2 startingPos;
    public Vector2 movementVector;
    float movementFactor;

    public float timePeriod = 2f; // ek oscillation mei kitni der
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePeriod == 0) { return; }            // To protect against NaN error, dividing by zero error, instead of time pd == 0  we should use time period <= mathf.Epsilon as epsilon is the smallest number recognised by unity 
        float cycles = Time.time / timePeriod;      
        float tau = Mathf.PI * 2;                  
        float sinWave = Mathf.Sin(cycles * tau);    
                                                   
        movementFactor = (sinWave + 1f) / 2f;       
                                                    
        Vector2 offSet = movementVector * movementFactor;
        transform.position = startingPos + offSet;   

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
