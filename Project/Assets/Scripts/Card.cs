using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enumerator for different card types
/// </summary>
public enum CardType
{
    Action,
    Defence,
    Taunt,
    Star
}

/// <summary>
/// Holds a CardType
/// </summary>
public class Card : MonoBehaviour
{
    public CardType cardType;
    // Start is called before the first frame update

    public void SetCardType(CardType ct)
    {
        cardType = ct;
    }
}
