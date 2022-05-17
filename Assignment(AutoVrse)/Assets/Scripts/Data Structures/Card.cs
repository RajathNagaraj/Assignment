using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private int cardNumber;
    private bool isExposed;

    public Card(int cardNumber)
    {     
      this.cardNumber = cardNumber;
    }

    public int PrintCardNumber()
    {
        return cardNumber;
    }


}

