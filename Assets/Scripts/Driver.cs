using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 1f;
    void Start()
    
    {
        
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

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
}
