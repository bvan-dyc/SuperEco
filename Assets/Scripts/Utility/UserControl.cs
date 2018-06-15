using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UserControl : MonoBehaviour
{
	CharacterController360 character;
	bool enabledControl = true;

	private void Awake()
	{
		character = GetComponent<CharacterController360>();
	}

	private void FixedUpdate()
	{
		if (enabledControl)
		{
			Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

			character.Move(movement);
		}
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
