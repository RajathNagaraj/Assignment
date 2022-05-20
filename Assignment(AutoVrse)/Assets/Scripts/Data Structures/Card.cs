using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private int cardNumber;
    

    public Card(int cardNumber)
    {     
      this.cardNumber = cardNumber;
    }

    public int PrintCardNumber()
    {
        return cardNumber;
    }


}

