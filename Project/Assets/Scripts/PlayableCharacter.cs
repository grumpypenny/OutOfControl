using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character
{
    Card card;
    public int defenceBuff;
    public static float[] positionMultiplier = { 0.75f, 1f, 1.5f };
    protected bool starCardActive;
    protected bool isSupport;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        starCardActive = false;
    }

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
                SetDefence(GetDefence() + defenceBuff * starMultiplier);
            }

            if (card.cardType == CardType.MoveBackward)
            {
                print("Implement positions");
            }

            if (card.cardType == CardType.MoveForward)
            {
                print("Implement positions");
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
        }
    }

    // Each player character class needs to implement this
    protected virtual void ActionCard()
    {
        throw new System.NotImplementedException();
    }
}
