﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<CharacterController360>().Powerup();
			Object.Destroy(gameObject);
		}
	}
}
