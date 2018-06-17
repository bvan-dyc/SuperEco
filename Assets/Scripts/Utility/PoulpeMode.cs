using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoulpeMode : MonoBehaviour {
	private GameObject gm;

	private void Awake()
	{
		gm = GameObject.FindGameObjectWithTag("GameController");
	}

	private void Update()
	{
		if (gm.GetComponent<GameManager>().poulpeMode == false)
		{
			gameObject.SetActive(false);
		}
	}
}
