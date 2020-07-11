using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Tracks All entities in the game along with actions
/// </summary>
public class GameManager : MonoBehaviour
{
	public List<Card> turnActions;
	public PlayableCharacter[] playableCharacters;
	/// <summary>
	/// Enemies in the level
	/// </summary>
	public EnemyCharacter[] enemies;
	public GameObject CardObject;
	public Transform[] CardPos;
	private int index = 0;

	private TurnSystem ts;

	private void Start()
	{
		ts = FindObjectOfType<TurnSystem>();
	}

	// Add a card to the player actions
	public void AddCard(CardType type)
	{
		if (index > CardPos.Length)
		{
			Debug.LogError("Not Enough Card Pos");
			return;
		}

		// spawn card as child of positon
		GameObject card = Instantiate(CardObject, CardPos[index]);
		Card newCard = card.GetComponent<Card>();
		newCard.cardType = type;
		index++;
		turnActions.Add(newCard);
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
		foreach (PlayableCharacter pc in playableCharacters)
		{
			//  Get random card
			int rando = Random.Range(0, turnActions.Count);
			Card card = turnActions[rando];
			turnActions.RemoveAt(rando);

			// give the players the card
			pc.SetCard(card);
			//print(pc.gameObject.name + " got " + card.cardType);
		}

		StartCoroutine(delayAttacks(2f));

		// reset the current cards
		StartCoroutine(resetAfterTime(1f));
		
	}

	private IEnumerator delayAttacks(float time)
	{
		int num = 0;
		foreach (PlayableCharacter pc in playableCharacters)
		{
			//print(pc.gameObject.name + " card is " + pc.GetCardType());
			pc.UseCard();
			num++;
			yield return new WaitForSeconds(time);

			if (ts != null)
			{
				ts.SetActionDone(num);
			}
		}
	}

	private IEnumerator resetAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		ResetCards();
	}
}
