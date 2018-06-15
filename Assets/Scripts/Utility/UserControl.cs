using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
	CharacterController character;
	bool enabledControl;

	private void Awake()
	{
		character = GetComponent<CharacterController>();
	}

	private void FixedUpdate()
	{
		Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		character.Move(movement);
	}

	public void enableControl()
	{
		enabledControl = true;
	}

	public void disableControl()
	{
		enabledControl = false;
	}
}
