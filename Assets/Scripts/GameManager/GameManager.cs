using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject	canvas;
	public GameObject victoryp1;
	public GameObject victoryp2;
	public Countdown count;
	public bool			poulpeMode = true;
	[SerializeField] private PlayerCharacter player1;
	[SerializeField] private PlayerCharacter player2;

	private void Awake()
	{
		canvas.SetActive(true);
		victoryp1.SetActive(false);
		victoryp2.SetActive(false);
	}

	private void Update()
	{
		if (player1.score < player2.score)
		{
			player1.isWinning = false;
			player2.isWinning = true;
		}
		if (player1.score > player2.score)
		{
			player1.isWinning = true;
			player2.isWinning = false;
		}
		if (count.timer <= 0)
		{
			if (player1.score > player2.score)
				victoryp1.SetActive(true);
			else
				victoryp2.SetActive(true);
		}
	}
}
