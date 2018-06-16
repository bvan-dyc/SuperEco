using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
	[SerializeField] private GameObject[] items;
	[SerializeField] private float[] spawnRates;
	[SerializeField] [Range(0, 20)] private float initSpawnDelay = 3f;
	[SerializeField] [Range(0, 20)] private float spawnDelay = 3f;
	[SerializeField] private float maxX = 7f;
	[SerializeField] private float maxY = 4f;
	[SerializeField] private float minX = -7f;
	[SerializeField] private float minY = -4f;

	private GameObject toSpawn;
	const float RADIUS = 1f;

	private void Start () {
		InvokeRepeating("SpawnItem", initSpawnDelay, spawnDelay);
	}

	private void SpawnItem () {
		toSpawn = ItemRoller();
		Collider2D collider = toSpawn.GetComponent<Collider2D>();
		Vector3 spawnPosition = getRandomPosition(collider);
		GameObject enemyInstance = Instantiate(toSpawn, spawnPosition, transform.rotation);
	}

	private GameObject ItemRoller()
	{
		float roll = Random.Range(0.1f, 1.0f);
		float leftLimit = 0.0f;
		float rightLimit = spawnRates[0];
		int i = 0;
		while (items[i] && i < spawnRates.Length)
		{
			if (roll >= leftLimit && roll <= rightLimit)
				return (items[i]);
			leftLimit += spawnRates[i];
			if (i + 1 < spawnRates.Length) {
				rightLimit += spawnRates[i + 1];
				i++;
			}
		}
		return (items[0]);
	}

	private Vector3 getRandomPosition(Collider2D collider)
	{
		Vector3 nextPosition;

		nextPosition.x = Random.Range(minX, maxX);
		nextPosition.y = Random.Range(minY, maxY);
		nextPosition.z = transform.position.z;
		Vector3 min = nextPosition - collider.bounds.extents;
		Vector3 max = nextPosition + collider.bounds.extents;
		Collider2D[] hitColliders = Physics2D.OverlapAreaAll(min, max);
		if (hitColliders.Length == 0)
		{
			Debug.Log("Generating new Item");
			return (nextPosition);
		}
		else
		{
			Debug.Log("Object overlap. Searching another position");
			return getRandomPosition(collider);
		}
	}
}
