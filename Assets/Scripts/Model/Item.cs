using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public int score = 1;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<PlayerCharacter>().AddScore(score);
			Object.Destroy(gameObject);
		}
	}
}
