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

	public Sprite action;
	public Sprite defence;
	public Sprite taunt;
	public Sprite star;

	private SpriteRenderer sr;
	// Start is called before the first frame update

	public void SetCardType(CardType ct)
    {
		sr = GetComponent<SpriteRenderer>();
        cardType = ct;

		print(sr == null);
		if (sr != null)
		{
			print("changing sprite");
			if (ct == CardType.Action)
			{
				sr.sprite = action;
			}
			else if (ct == CardType.Defence)
			{
				sr.sprite = defence;
			}
			else if (ct == CardType.Taunt)
			{
				sr.sprite = taunt;
			}
			else if (ct == CardType.Star)
			{
				sr.sprite = star;
			}
		}
    }


}
