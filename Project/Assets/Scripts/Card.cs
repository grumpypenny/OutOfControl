using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Action,
    Defence,
    Movement,
    Taunt,
    Star
}

public class Card : MonoBehaviour
{
    public CardType cardType;
    // Start is called before the first frame update

    public void SetCardType(CardType ct)
    {
        cardType = ct;
    }
}
