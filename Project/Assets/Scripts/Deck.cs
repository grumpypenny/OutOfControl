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
	private bool open = false;
	private int cardCount = 0;

	public void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void ToggleDeck()
	{
		open = !open;
		anim.SetBool("open", open);
	}

	public void SelectCard(string type)
	{
		cardCount++;

		if (cardCount >= 5)
		{
			foreach (Button b in grid)
			{
				b.interactable = false;
			}
			cardCount = 0;
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
	}
}

