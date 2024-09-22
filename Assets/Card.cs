using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string cardAction;
    public Image cardImage;
    public TextMeshProUGUI cardText;

    public Plane planeToControl;

    public void SetAction(string action)
    {
        cardAction = action;
        // Optionally set text or image here to represent the action
        // Set the card's text and font color based on the action
        switch (cardAction)
        {
            case "Move Blue Plane Right":
            case "Move Blue Plane Left":
                cardText.color = new Color(0f,0.6745098f,0.937255f);
                planeToControl= GameObject.Find("Plane_blue").GetComponent<Plane>();
                break;
            
            case "Move Red Plane Right":
            case "Move Red Plane Left":
                cardText.color = new Color(0.9215687f,0.1137255f,0.1411765f);
                planeToControl= GameObject.Find("Plane_red").GetComponent<Plane>();                
                break;
        }

        // Set the text content to match the action
        cardText.text = action;
    }
    
    public void TriggerAction()
    {
        switch(cardAction)
        {
            case "Move Blue Plane Right":
                planeToControl.onTriggerRight();
                break;
            case "Move Blue Plane Left":
                planeToControl.onTriggerLeft();
                break;
            case "Move Red Plane Right":
                planeToControl.onTriggerRight();
                break;
            case "Move Red Plane Left":
                planeToControl.onTriggerLeft();
                break;
        }
    }
}