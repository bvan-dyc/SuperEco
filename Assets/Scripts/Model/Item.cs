using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	[SerializeField] private int score = 1;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<PlayerCharacter>().AddScore(score);
			//gameObject.SetActive(false);
		}
	}
}
