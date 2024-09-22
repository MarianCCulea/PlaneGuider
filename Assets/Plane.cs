using UnityEngine;

public class Plane : MonoBehaviour
{
    public float moveDistance = 2.94f;
    public GameObject panel;

    // Whether the object is currently moving
    private bool isMovingLeft = false;
    
    public void onTriggerLeft()
    {
        transform.position = new Vector2(transform.position.x - moveDistance, transform.position.y);
    }
    
    public void onTriggerRight()
    {
        transform.position = new Vector2(transform.position.x + moveDistance, transform.position.y);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        panel.SetActive(true);
    }
}
