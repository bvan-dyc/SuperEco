using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject	canvas;
	public bool			poulpeMode = true;
	[SerializeField] private PlayerCharacter player1;
	[SerializeField] private PlayerCharacter player2;

	private void Awake()
	{
		canvas.SetActive(true);
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
	}
}
