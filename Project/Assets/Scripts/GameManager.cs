using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Tracks All entities in the game along with actions
/// </summary>
public class GameManager : MonoBehaviour
{
	public List<Card> turnActions;
	public GameObject CardObject;
	public Transform[] CardPos;
	private int index = 0;

	// Add a card to the player actions
	public void AddCard(CardType type)
	{
		print(type);

		if (index > CardPos.Length)
		{
			Debug.LogError("Not Enough Card Pos");
			return;
		}

		// spawn card as child of positon
		Instantiate(CardObject, CardPos[index]);
		index++;
	}

	// Remove all cards from player actions
	// and remove them from world space
	public void ResetCards()
	{
		turnActions.Clear();
		index = 0;
		foreach (Transform t in CardPos)
		{
			ArrayList children = new ArrayList();
			foreach(Transform child in t)
			{
				children.Add(child);
			}

			foreach(Transform c in children)
			{
				Destroy(c.gameObject);
			}
		}
	}

	// apply card effects
	public void Execute()
	{
		print("executing cards");
	}
}
