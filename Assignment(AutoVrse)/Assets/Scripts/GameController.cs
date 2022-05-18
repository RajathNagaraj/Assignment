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

    //A reference to each card in the deck
    private List<Transform> cards;

    //Location of the last card being spawned
    private Vector3 nextCardLocation;

    //A reference to the deck gameobject
    private GameObject deckGameObject ;



    // Start is called before the first frame update
    void Start()
    {
        //Creating an object of deck
        deck = new Deck();
        //Initialising rand
        rand = new System.Random();
        //setting the maxValue to 13
        maxValue = 13;

        nextCardLocation = FloorCentre.position;
        deckGameObject = new GameObject("Deck"); 
        cards = new List<Transform>();
        Instantiate(deckGameObject, FloorCentre.position,Quaternion.identity);
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
        //Logically creating a card and adding it to the deck
        int random = rand.Next(1, maxValue + 1);
        deck.Push(new Card(random));
        //Visually creating the card        
        cards.Add(Instantiate(cardPrefab,nextCardLocation,Quaternion.identity));
        //Setting up nextCardLocation so that the next card is spawned on top of the last card
        nextCardLocation.y += 0.2f;
        //Getting a reference to the card on the top of the deck
        Transform card = cards[cards.Count - 1];
        //Setting the deck gameobject as its parent
        card.SetParent(deckGameObject.transform);
        //Updating the text on the button to the random value
        card.GetComponent<CardController>().SetValue(random);
    }

    public void PopCard()
    {
        //Logically creating a reference to the card to be popped
        Card card = deck.Pop();        
        if (card != null)
        {
            Debug.Log("Popping Card from Deck");
            Debug.Log("Popped Card from Deck is " + card.PrintCardNumber());
            //Getting a reference to the visual card and then destroying it
            Transform cardTransform = cards[cards.Count - 1];
            cards.Remove(cardTransform);
            Destroy(cardTransform.gameObject);
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
        //Logically shuffling the deck
        deck.Shuffle();
        //Visually reflecting the change
        for(int i = 0; i < deck.cards.Count; ++i)
        {
            Transform cardObject = cards[i];
            //Setting the values of the cards in the visual deck to that of the logical deck
            cardObject.GetComponent<CardController>().SetValue(deck.cards[i].PrintCardNumber());
        }
    }

}
