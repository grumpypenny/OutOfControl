using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character
{
    #region fields
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

    /// <summary>
    /// Player targetting system
    /// </summary>
    protected PlayerManager pm;
    #endregion
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        starCardActive = false;
        pm = FindObjectOfType<PlayerManager>();
    }

    /// <summary>
    /// Makes this character use the held card
    /// </summary>
    public void UseCard()
    {
        if (card.cardType == CardType.Action)
        {
            ActionCard();
			print(this.gameObject.name + " Action");
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
			print(this.gameObject.name + " Defence");
		}

        if (card.cardType == CardType.Taunt)
        {
            isTaunting = true;
            starCardActive = false;
			print(this.gameObject.name + " Taunt");
		}

        if (card.cardType == CardType.Star)
        {
            starCardActive = true;
			print(this.gameObject.name + " Star");
		}        
    }

	public void isCardNull()
	{
		if (card == null)
		{
			print(this.gameObject.name + " card is null");
		}
	}

    public void SetCard(Card card)
    {
        this.card = card;
    }

	public CardType GetCardType()
	{
		return this.card.cardType;
	}

    /// <summary>
    /// Executes this character's specific effect.
    /// </summary>
    protected virtual void ActionCard()
    {
        print("This is not a real player, please instantiate a Healer, Cleric, or Druid instead.");
    }
}
