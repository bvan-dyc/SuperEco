using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UIZone : MonoBehaviour {
	private SceneTransition transition;
	private bool canTransition = false;

	private void Awake()
	{
		transition = GetComponent<SceneTransition>();
	}

	private void Update()
	{
		if (canTransition && Input.GetButtonDown("Fire1")) {
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
