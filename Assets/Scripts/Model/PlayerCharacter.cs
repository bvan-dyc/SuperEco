using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerCharacter : MonoBehaviour {
	[SerializeField] [Range(0, 1)] float knockbackDuration = 0.3f;
	[SerializeField] [Range(0, 10)] float knockbackDistance = 2f;
	public string isPressed = "";

	[SerializeField] private List<GameObject> inventoryX;
	[SerializeField] private List<GameObject> inventoryY;
	[SerializeField] private List<GameObject> inventoryB;
	[SerializeField] private Transform XSpawn;
	[SerializeField] private Transform YSpawn;
	[SerializeField] private Transform BSpawn;

	public int				score = 0;
	private Vector2			knockbackDirection;
	private Rigidbody2D		rb;
	public TextMeshProUGUI	scoreText;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (scoreText)
			scoreText.text = score.ToString("000");
	}

	private void Knockback(Vector2 direction)
	{
		Vector2 knockbackPosition = new Vector2(transform.position.x + (knockbackDistance * direction.x), transform.position.y + (knockbackDistance * direction.y));
		rb.DOMove(knockbackPosition, knockbackDuration);
	}

	public void Powerup()
	{
		GetComponent<CharacterController360>().speed *= 2;
	}

	public void AddScore(int scoreMod)
	{
		score += scoreMod;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Vector2 dir = new Vector2(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y);
			dir = -dir.normalized;
			Knockback(dir);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Item")
		{
			if (isPressed == "X") {
				other.gameObject.transform.position = XSpawn.position;
				inventoryX.Add(other.gameObject);
			}
			if (isPressed == "Y") {
				other.gameObject.transform.position = YSpawn.position;
				inventoryY.Add(other.gameObject);
			}
			if (isPressed == "B") {
				other.gameObject.transform.position = BSpawn.position;
				inventoryB.Add(other.gameObject);
			}
		}
		if (other.gameObject.tag == "Container")
		{
			if (isPressed == "X")
			{
				RemoveFromInventory(inventoryX);
				isPressed = "";
			}
			if (isPressed == "Y")
			{
				RemoveFromInventory(inventoryY);
				isPressed = "";
			}
			if (isPressed == "B")
			{
				RemoveFromInventory(inventoryB);
				isPressed = "";
			}
		}
	}

	private void RemoveFromInventory(List<GameObject> inventory)
	{
		if (inventory.Count > 0)
		{
			AddScore(inventory[0].GetComponent<Item>().score);
			Destroy(inventory[0]);
			inventory.RemoveAt(0);
		}
	}
}

