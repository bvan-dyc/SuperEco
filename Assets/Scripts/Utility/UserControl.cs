using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UserControl : MonoBehaviour
{
	[SerializeField] private int playerID;
	public bool enabledControl = true;

	private CharacterController360 character;

	private void Awake()
	{
		character = GetComponent<CharacterController360>();
	}

	private void FixedUpdate()
	{
		Debug.Log(Input.GetJoystickNames());
		if (enabledControl)
		{
			Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("P" + playerID + "_Horizontal"),
				CrossPlatformInputManager.GetAxis("P" + playerID + "_Vertical"));
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
