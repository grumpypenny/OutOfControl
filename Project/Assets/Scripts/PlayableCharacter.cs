using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character
{
    /// <summary>
    /// Card held by this character
    /// </summary>
    Card card;

    /// <summary>
    /// defence multiplier value for the defence card
    /// </summary>
    public int defenceCardBuff;

    /// <summary>
    /// positional bonuses/penalties for action card effects
    /// </summary>
    public static float[] positionMultiplier = { 0.75f, 1f, 1.5f };

    /// <summary>
    /// Tracks if the star card should affect the next card
    /// </summary>
    protected bool starCardActive;

    /// <summary>
    /// Tracks if character is acting as support role
    /// </summary>
    protected bool isSupport;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        starCardActive = false;
    }

    /// <summary>
    /// Makes this character use the held card
    /// </summary>
    void UseCard()
    {
        if (card != null)
        {
            if (card.cardType == CardType.Action)
            {
                ActionCard();
            }

            if (card.cardType == CardType.Defence)
            {
                int starMultiplier = 1;
                if (starCardActive)
                {
                    starMultiplier = 4;
                    starCardActive = false;
                }
                SetDefence(GetDefence() + defenceCardBuff * starMultiplier);
            }

            if (card.cardType == CardType.Taunt)
            {
                isTaunting = true;
                starCardActive = false;
            }

            if (card.cardType == CardType.Star)
            {
                starCardActive = true;
            }

            card = null;
        } else
        {
            print("this character's card is null");
        }
    }

    public void SetCard(Card card)
    {
        this.card = card;
    }

    /// <summary>
    /// Executes this character's specific effect.
    /// </summary>
    protected virtual void ActionCard()
    {
        print("This is not a real player, please instantiate a Healer, Cleric, or Druid instead.");
    }
}
