using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]
public class Deck : MonoBehaviour
{
	public Button[] grid;

	private Animator anim;
	private int cardCount = 0;

	private GameManager gm;

	public void Start()
	{
		anim = GetComponent<Animator>();
		gm = FindObjectOfType<GameManager>();
	}

	public void ToggleDeck()
	{
		bool nextStatus = !anim.GetBool("open");
		anim.SetBool("open", nextStatus);
	}

	public void SelectCard(string type)
	{
		cardCount++;

		// send in the cards to execute
		if (gm != null)
		{
			CardType ct = (CardType)System.Enum.Parse(typeof(CardType), type);

			gm.AddCard(ct);
		}

		if (cardCount >= 5)
		{
			foreach (Button b in grid)
			{
				b.interactable = false;
			}
			cardCount = 0;

			if (gm != null)
			{
				gm.Execute();
				anim.SetBool("open", false);
				return;
			}
		}
	}

	public void DisableButton(Button b)
	{
		b.interactable = false;
	}

	public void ResetGrid()
	{
		foreach (Button b in grid)
		{
			b.interactable = true;
		}

		// reset the amount of cards
		if (gm != null)
		{
			gm.ResetCards();
		}
	}
}

