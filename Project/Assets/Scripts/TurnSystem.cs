using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnSystem : MonoBehaviour
{
	public static int turnCount = 1;

	[Header("Player Characters")]
	public PlayableCharacter Wizard;
	public PlayableCharacter Ranger;
	public PlayableCharacter Tank;

	[Space]

	[Header("timing")]
	public float startTime = 1f;
	public float playerTime = 1f;
	public float enemyTime = 1f;
	public float endTime = 1f;

	[Space]

	[Header("UI")]
	public TMP_Text turnText;

	private bool isGameOver = false;
	private bool isDrawDone = false;
	private bool player1Done = false;
	private bool player2Done = false;
	private bool player3Done = false;
	private bool isEnemyActionDone = false;

	private GameManager gm;
	private EnemyManager em;
	private PlayerManager pm;
	private Deck deck;

    // Start is called before the first frame update
    void Start()
    {
		gm = FindObjectOfType<GameManager>();
		em = FindObjectOfType<EnemyManager>();
		pm = FindObjectOfType<PlayerManager>();
		deck = FindObjectOfType<Deck>();
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

		StartCoroutine(em.StartEnemyTurn(gm.enemies, gm.playableCharacters, this));
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
		// reset the cards
		deck.ResetGrid();

		// spawn the enemies to the grid

		// move the background to new env

		// change the classes of each character
		int r = Random.Range(0, 3);

		switch (r)
		{
			case 0:
				Ranger.ToggleSupport();
				Tank.ToggleSupport();
				break;
			case 1:
				Ranger.ToggleSupport();
				Wizard.ToggleSupport();
				break;
			case 3:
				Tank.ToggleSupport();
				Wizard.ToggleSupport();
				break;
		}
		// wait for <startTime> seconds
		yield return new WaitForSeconds(startTime);
	}

	private IEnumerator Player()
	{
		turnText.text = "Player's Turn";

		// wait for player to draw
		while (!isDrawDone)
		{
			yield return null;
		}
		print("draw is done");
		// wait for characters to use actions
		// actions implemented later
		while (!player1Done || !player2Done || !player3Done)
		{
			yield return null;
		}

		print("ending player turn");
		yield return new WaitForSeconds(playerTime);
	}

	private IEnumerator Enemy()
	{
		turnText.text = "Enemy's Turn";

		// wait for enemies to go
		while (!isEnemyActionDone)
		{
			yield return null;
		}

		yield return new WaitForSeconds(enemyTime);


	}
}
