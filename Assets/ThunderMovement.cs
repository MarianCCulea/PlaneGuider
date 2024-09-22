using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderMovement : MonoBehaviour
{
    // Speed at which the GameObject moves down
    public float moveSpeed ;

    // Update is called once per frame
    void Update()
    {
        // Move the GameObject down along the Y-axis
        transform.Translate(Vector2.down * (moveSpeed * Time.deltaTime));
    }
}
