using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float RoadSpeed = 10f;

    [SerializeField] float GrassSpeed = 6f;
    [SerializeField] float boostSpeed = 18f;

    float currentSpeed;
    void Start()
    
    {
        currentSpeed = RoadSpeed;
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        // cannot change direction in still
        if(moveAmount == 0)
        {
            steerAmount = 0;
        }

        // direction recurrection when moving backward
        if(moveAmount < 0)
        {
            transform.Rotate(0, 0, steerAmount);
        } 
        else 
        {
            transform.Rotate(0, 0, -steerAmount);
        }

        transform.Translate(0,moveAmount,0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        currentSpeed = GrassSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Grass")
        {
            currentSpeed = GrassSpeed;
        }

        if(other.tag == "Road")
        {
            currentSpeed = RoadSpeed;
        }

        if(other.tag == "SpeedUpItem")
        {
            currentSpeed = boostSpeed;
        }
    }
}
