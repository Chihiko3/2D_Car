using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
     [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage; // default is "false" in defining condition

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("You've hit something");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

    if(other.tag == "Package" && !hasPackage)
    {
        Debug.Log("Package picked up!");
        hasPackage = true;
        spriteRenderer.color = hasPackageColor;
        Destroy(other.gameObject, destroyDelay);
    }

    if(other.tag == "Customer" && hasPackage) // default is "true" in situational condition
    {
        Debug.Log("Package delivered!");
        hasPackage = false;
        spriteRenderer.color = noPackageColor;
    }

    }
}
