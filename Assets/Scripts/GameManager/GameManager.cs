using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject canvas;

	private void Awake()
	{
		canvas.SetActive(true);
	}
}
