using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Deck deck;
    System.Random rand;
    int maxValue;
    // Start is called before the first frame update
    void Start()
    {
        deck = new Deck();  
        rand = new System.Random();
        maxValue = 13;
    }

    // Update is called once per frame
    void Update()
    {
        //Prints the contents of deck when Space is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Printing Deck");
            deck.PrintDeck();
        }
        //Pushes a card with a number between 1 and 13 onto deck on pressing q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Pushing Card onto deck");
            deck.Push(new Card(rand.Next(1,maxValue + 1)));
        }
        //Pops a card from deck when w is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {            
            Card card = deck.Pop();
            if(card != null)
            {
                Debug.Log("Popping Card from Deck");
                Debug.Log("Popped Card from Deck is " + card.PrintCardNumber());
            }
            else
            {
                Debug.Log("No cards left to Pop");
            }
            
        }
        //Peeks at the deck when e is pressed
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(deck.Peek() != 0)
            {
                Debug.Log("Peeking Deck");
                Debug.Log("The top card number is " + deck.Peek());
            }
            else
            {
                Debug.Log("No cards in Deck to Peek");
            }
           
        }
        //Shuffles deck when r is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Shuffling Deck");
            deck.Shuffle();
        }

    }
}
