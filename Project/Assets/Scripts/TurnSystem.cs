using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
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
	private bool isActionsDone = false;
	private bool isEnemyActionDone = false;

    // Start is called before the first frame update
    void Start()
    {
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

	public void SetActionDone()
	{
		isActionsDone = true;
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
		isActionsDone = false;

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
		while (!isActionsDone)
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
