using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderMovement : MonoBehaviour
{
    // Speed at which the GameObject moves down
    public float moveSpeed = 2f;
    
    
    Collider2D playerCollider;

    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the GameObject down along the Y-axis
        transform.Translate(Vector2.down * (moveSpeed * Time.deltaTime));
    }
    
    // This method is called when another collider enters the trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        // Log a debug message when the trigger is activated
        Debug.Log("Trigger entered by: " + other.gameObject.name);
    }
}
