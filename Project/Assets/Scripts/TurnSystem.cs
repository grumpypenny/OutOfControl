using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
	public static int turnCount = 1;

	[Header("Player Characters")]
	public Character Wizard;
	public Character Ranger;
	public Character Tank;

	[Space]

	[Header("timing")]
	public float startTime = 1f;
	public float playerTime = 1f;
	public float enemyTime = 1f;
	public float endTime = 1f;

	private bool isGameOver = false;
	private bool isDrawDone = false;
	private bool player1Done = false;
	private bool player2Done = false;
	private bool player3Done = false;
	private bool isEnemyActionDone = false;

	private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
		gm = FindObjectOfType<GameManager>();
		StartCoroutine(Game());
    }

	public void SetGameOver()
	{
		isGameOver = true;
	}

	public void SetDrawOver()
	{
		isDrawDone = true;
	}

	public void SetActionDone(int player)
	{
		switch (player)
		{
			case 1:
				player1Done = true;
				break;
			case 2:
				player2Done = true;
				break;
			case 3:
				player3Done = true;
				break;
		}


	}

	public void SetEnemyAction()
	{
		isEnemyActionDone = true;
	}

	private IEnumerator Game()
	{
		// set up the battle
		yield return StartCoroutine(SetUp());

		// player turn goes first
		yield return StartCoroutine(Player());

		// reset bools
		isDrawDone = false;
		player1Done = false;
		player2Done = false;
		player3Done = false;

	// then enemy turn
	yield return StartCoroutine(Enemy());

		// reset bool
		isEnemyActionDone = false;

		// check if game is over or not
			// go to next or end
		if (isGameOver)
		{
			// end the game
		}
		else
		{
			// next round
			// start the loop again
			turnCount++;

			StartCoroutine(Game());
		}
	}

	private IEnumerator SetUp()
	{
		// spawn the enemies to the grid

		// move the background to new env

		// wait for <startTime> seconds
		yield return new WaitForSeconds(startTime);
	}

	private IEnumerator Player()
	{
		// wait for player to draw
		while (!isDrawDone)
		{
			yield return null;
		}
		// wait for characters to use actions
		// actions implemented later
		while (!player1Done)
		{
			yield return null;
		}
		while (!player2Done)
		{
			yield return null;
		}
		while (!player3Done)
		{
			yield return null;
		}

		yield return new WaitForSeconds(playerTime);
	}

	private IEnumerator Enemy()
	{
		// wait for enemies to go
		while (!isEnemyActionDone)
		{
			yield return null;
		}

		yield return new WaitForSeconds(enemyTime);
	}
}
