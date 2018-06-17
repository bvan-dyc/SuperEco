using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Speed : MonoBehaviour {
	public float speedModifier = 1.5f;
	public float powerupDuration = 5f;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && other.GetComponent<PlayerCharacter>().isUpped == false)
		{
			other.GetComponent<PlayerCharacter>().Powerup_Speed(speedModifier, powerupDuration);
			Object.Destroy(gameObject);
		}
	}
}

