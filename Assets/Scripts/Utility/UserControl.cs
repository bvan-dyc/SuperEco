using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UserControl : MonoBehaviour
{
	[SerializeField] private int playerID;
	public bool enabledControl = true;

	private CharacterController360 ccontroller;
	private PlayerCharacter pc;

	private void Awake()
	{
		ccontroller = GetComponent<CharacterController360>();
		pc = GetComponent<PlayerCharacter>();
	}

	private void FixedUpdate()
	{
		if (enabledControl)
		{
			Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("P" + playerID + "_Horizontal"),
				CrossPlatformInputManager.GetAxis("P" + playerID + "_Vertical"));
			ccontroller.Move(movement);
			getcurrentPress();
		}
	}

	private void getcurrentPress()
	{
		if (CrossPlatformInputManager.GetButtonDown("P" + playerID + "_Fire3")) {
			pc.isPressed = "X";
		}
		else if (CrossPlatformInputManager.GetButtonDown("P" + playerID + "_Fire2")) {
			pc.isPressed = "B";
		}
		else if (CrossPlatformInputManager.GetButtonDown("P" + playerID + "_Fire4")) {
			pc.isPressed = "Y";
		}
		if (CrossPlatformInputManager.GetButtonUp("P" + playerID + "_Fire3")) {
			pc.isPressed = "";
		}
		else if (CrossPlatformInputManager.GetButtonUp("P" + playerID + "_Fire2")) {
			pc.isPressed = "";
		}
		else if (CrossPlatformInputManager.GetButtonUp("P" + playerID + "_Fire4")) {
			pc.isPressed = "";
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
