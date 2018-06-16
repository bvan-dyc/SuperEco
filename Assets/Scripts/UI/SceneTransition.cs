﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	public string TransitionTo;

	public void Transition()
	{
		SceneManager.LoadScene(TransitionTo);
	}
}