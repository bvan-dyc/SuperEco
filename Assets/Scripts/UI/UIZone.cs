using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UIZone : MonoBehaviour {
	private SceneTransition transition;
	private bool canTransition = false;
	public FadeIn fadein;

	private void Awake()
	{
		transition = GetComponent<SceneTransition>();
	}

	private void Update()
	{
		if (canTransition && CrossPlatformInputManager.GetButtonDown("P1_Fire1")) {
			fadein.FadeOut();
			transition.Transition();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		canTransition = true;
	}

	private void OnTriggerLeave2D(Collider2D other)
	{
		canTransition = false;
	}
}
