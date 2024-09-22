using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    [SerializeField] public List<Card> cards = new List<Card>();
    [SerializeField] public Transform cardContainer;
    [SerializeField] GameObject cardPrefab;

    private int selectedCardIndex = 0;
    private float highlightTime = 2.0f; // Time to trigger action after highlight
    private float highlightTimer = 0.0f;
    private bool cardHighlighted = false;

    // Fixed actions, these must always be represented
    private  string[] actions = { "Move Blue Plane Right", "Move Blue Plane Left", "Move Red Plane Right", "Move Red Plane Left" };

    void Start()
    {
        // Populate cards, ensuring all actions are present
        for (int i = 0; i < actions.Length; i++)
        {
            AddCard(actions[i]);
        }

        // Add 2 random cards to complete 6 total cards
        for (int i = 0; i < 3; i++)
        {
            AddRandomCard();
        }
    }

    void Update()
    {
        // Scroll through cards by pressing 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            ScrollCards();
        }

        // Highlight timer
        if (cardHighlighted)
        {
            highlightTimer += Time.deltaTime;

            if (highlightTimer >= highlightTime)
            {
                // Trigger the highlighted card action
                cards[selectedCardIndex].TriggerAction();

                // Remove the card and replace it
                ReplaceCard(selectedCardIndex);

                // Reset highlight timer
                highlightTimer = 0.0f;
                cardHighlighted = false;

                // Update selected index
                selectedCardIndex = Mathf.Clamp(selectedCardIndex, 0, cards.Count - 1);
            }
        }
    }

    private void ScrollCards()
    {
        // Move to the next card
        selectedCardIndex = (selectedCardIndex + 1) % cards.Count;
        HighlightSelectedCard();
    }

    private void HighlightSelectedCard()
    {
        // Reset timer and highlight flag
        highlightTimer = 0.0f;
        cardHighlighted = true;

        for (int i = 0; i < cards.Count; i++)
        {
            if (i == selectedCardIndex)
                cards[i].cardImage.color = Color.yellow; // Highlight
            else
                cards[i].cardImage.color = Color.white; // Reset others
        }
    }

    private void ReplaceCard(int index)
    {
        // Destroy the old card and remove it from the list
        Destroy(cards[index].gameObject);
        cards.RemoveAt(index);

        // Add either a random card or one of the fixed actions
        if (cards.Count < actions.Length)
        {
            // Ensure all actions are represented
            foreach (string action in actions)
            {
                if (!cards.Exists(c => c.cardAction == action))
                {
                    AddCard(action);
                    return;
                }
            }
        }
        else
        {
            // Add a random card from the available actions to keep the total at 6
            AddRandomCard();
        }
    }

    private void AddCard(string action)
    {
        // Instantiate a new card and set its action
        GameObject newCardObj = Instantiate(cardPrefab, cardContainer);
        Card newCard = newCardObj.GetComponent<Card>();

        newCard.SetAction(action);
        cards.Add(newCard);
    }

    private void AddRandomCard()
    {
        // Pick a random action from the available ones
        string randomAction = actions[Random.Range(0, actions.Length)];
        AddCard(randomAction);
    }
}
