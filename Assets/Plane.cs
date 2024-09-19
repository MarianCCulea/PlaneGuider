using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Plane : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Speed of the leftward movement
    public float moveSpeed = 5f;

    // Duration to move to the left when triggered
    public float moveDuration = 1f;

    // Whether the object is currently moving
    private bool isMovingLeft = false;
    
    public void onTriggerLeft()
    {
        isMovingLeft = true; // Indicate that the object is currently moving
        float elapsedTime = 0f;

        // Move left for the duration of 'moveDuration'
        while (elapsedTime < moveDuration)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // Move the object to the left
            elapsedTime += Time.deltaTime; // Track how long the object has been moving
        }

        isMovingLeft = false; // Reset the moving state after movement is complete
    }
    
    public void onTriggerRight()
    {
        isMovingLeft = true; // Indicate that the object is currently moving
        float elapsedTime = 0f;

        // Move left for the duration of 'moveDuration'
        while (elapsedTime < moveDuration)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // Move the object to the left
            elapsedTime += Time.deltaTime; // Track how long the object has been moving
        }

        isMovingLeft = false; // Reset the moving state after movement is complete
    }
    
}
