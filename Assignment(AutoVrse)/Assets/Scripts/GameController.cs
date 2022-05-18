using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Deck deck;
    System.Random rand;
    int maxValue;
    //The reference to the centre of the floor
    [SerializeField]
    private Transform FloorCentre;
    //A reference to the card prefab
    [SerializeField]
    private Transform cardPrefab;
    //A reference to the deck of cards
    public List<Transform> deckPrefab;



    // Start is called before the first frame update
    void Start()
    {
        deck = new Deck();  
        rand = new System.Random();
        maxValue = 13;
        deckPrefab = new List<Transform>();
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
    }
    public void AddCard()
    {
        Debug.Log("Pushing Card onto deck");
        deck.Push(new Card(rand.Next(1, maxValue + 1)));
    }

    public void PopCard()
    {
        Card card = deck.Pop();
        if (card != null)
        {
            Debug.Log("Popping Card from Deck");
            Debug.Log("Popped Card from Deck is " + card.PrintCardNumber());
        }
        else
        {
            Debug.Log("No cards left to Pop");
        }
    }

    public void Peek()
    {
        if (deck.Peek() != 0)
        {
            Debug.Log("Peeking Deck");
            Debug.Log("The top card number is " + deck.Peek());
        }
        else
        {
            Debug.Log("No cards in Deck to Peek");
        }
    }

    public void Shuffle()
    {
        Debug.Log("Shuffling Deck");
        deck.Shuffle();
    }

}
