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
	/// Sprite for the support state
	/// </summary>
	public Sprite supportImg;
	/// <summary>
	/// Sprite for the Attack state
	/// </summary>
	public Sprite attackImg;

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

	protected SpriteRenderer sr;

	protected Animator anim;

    #endregion
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        starCardActive = false;
        pm = FindObjectOfType<PlayerManager>();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

    /// <summary>
    /// Makes this character use the held card
    /// </summary>
    public void UseCard()
    {
		ResetAnimTriggers();

        if (card.cardType == CardType.Action)
        {
			// support anim is the same for all characters
			if (isSupport)
			{
				anim.SetTrigger("Heal");
			}

            ActionCard();
			print(this.gameObject.name + " Action");
		}

        if (card.cardType == CardType.Defence)
        {
			anim.SetTrigger("Defence");
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
			anim.SetTrigger("Taunt");
            isTaunting = true;
            starCardActive = false;
			print(this.gameObject.name + " Taunt");
		}

        if (card.cardType == CardType.Star)
        {
			anim.SetTrigger("Star");
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

	[ContextMenu("Toggle Support")]
	public void ToggleSupport()
	{
		isSupport = !isSupport;
		sr.sprite = isSupport ? supportImg : attackImg;
	}

    /// <summary>
    /// Executes this character's specific effect.
    /// </summary>
    protected virtual void ActionCard()
    {
        print("This is not a real player, please instantiate a Healer, Cleric, or Druid instead.");
    }

	protected void ResetAnimTriggers()
	{
		if (anim == null)
		{
			print("anim not configured");
		}

		foreach (AnimatorControllerParameter param in anim.parameters)
		{
			anim.ResetTrigger(param.name);
		}
	}
}
