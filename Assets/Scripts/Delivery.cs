using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage; // default is "false" in defining condition
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("You've hit something");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

    if(other.tag == "Package" && hasPackage == false)
    {
        Debug.Log("Package picked up!");
        hasPackage = true;
    }

    if(other.tag == "Customer" && hasPackage) // default is "true" in situational condition
    {
        Debug.Log("Package delivered!");
        hasPackage = false;
    }

    }
}
