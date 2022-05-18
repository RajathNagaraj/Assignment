using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    public List<Card> cards;

    public Deck()
    {
        this.cards = new List<Card>();
    }
    
    //Pushes a card onto the stack
    public void Push(Card card)
    {
        cards.Add(card);
    }


    //Removes a card from the top of the stack and returns it
    public Card Pop()
    {
        if(cards.Count > 0)
        {
            Card card = cards[cards.Count - 1];
            cards.Remove(card);
            return card;
        }
        return null;
        
    }


    //Reveals the number of the card at the top of the stack
    public int Peek()
    {
        if(cards.Count > 0)
        {
            int lastCardNumber = cards[cards.Count - 1].PrintCardNumber();
            return lastCardNumber;
        }
        return 0;
        
    }

    //Shuffles the deck using something called Fisher–Yates shuffle algorithm
    public void Shuffle()
    {
        if(cards.Count > 0)
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int k = (new System.Random()).Next(i + 1);
                Card card = cards[k];
                cards[k] = cards[i];
                cards[i] = card;
            }
        }

        else
        {
            Debug.Log("No cards to shuffle in Deck");
        }
        
    }

    public void PrintDeck()
    {
        if(cards.Count > 0)
        {
            foreach (Card card in cards)
            {
                Debug.Log(card.PrintCardNumber());
            }
        }
        else
        {
            Debug.Log("No cards to print in Deck");
        }
    }
}