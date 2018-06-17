using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
	[SerializeField] [Range(0, 1)] float knockbackDuration = 0.3f;
	[SerializeField] [Range(0, 10)] float knockbackDistance = 2f;
	public string isPressed = "";

	[SerializeField] private List<GameObject> inventoryX;
	[SerializeField] private List<GameObject> inventoryY;
	[SerializeField] private List<GameObject> inventoryB;
	[SerializeField] [Range(0, 20)] private int inventorySize = 6;
	[SerializeField] private Transform XSpawn;
	[SerializeField] private Transform YSpawn;
	[SerializeField] private Transform BSpawn;
	[SerializeField] private TextMeshProUGUI scoreText;

	public int				score = 0;
	private Vector2			knockbackDirection;
	private Rigidbody2D		rb;
	private Indicator		indicator;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		indicator = GetComponent<Indicator>();
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
			if (isPressed == "X" && inventoryX.Count < inventorySize) {
				other.gameObject.transform.position = XSpawn.position;
				other.gameObject.GetComponent<Item>().Hold();
				inventoryX.Add(other.gameObject);
			}
			if (isPressed == "Y" && inventoryY.Count < inventorySize) {
				other.gameObject.transform.position = YSpawn.position;
				other.gameObject.GetComponent<Item>().Hold();
				inventoryY.Add(other.gameObject);
			}
			if (isPressed == "B" && inventoryB.Count < inventorySize) {
				other.gameObject.transform.position = BSpawn.position;
				other.gameObject.GetComponent<Item>().Hold();
				inventoryB.Add(other.gameObject);
			}
		}
		if (other.gameObject.tag == "Container")
		{

			if (isPressed == "X")
			{
				RemoveFromInventory(inventoryX, other.gameObject.name);
				isPressed = "";
			}
			if (isPressed == "Y")
			{
				RemoveFromInventory(inventoryY, other.gameObject.name);
				isPressed = "";
			}
			if (isPressed == "B")
			{
				RemoveFromInventory(inventoryB, other.gameObject.name);
				isPressed = "";
			}
		}
	}

	private void RemoveFromInventory(List<GameObject> inventory, string binName)
	{
		if (inventory.Count > 0)
		{
			if (binName == inventory[0].GetComponent<Item>().destination)
			{
				AddScore(inventory[0].GetComponent<Item>().scoreBonus);
				indicator.PlayerisRight();
			}
			else
			{
				AddScore(-1 * inventory[0].GetComponent<Item>().scoreMalus);
				indicator.PlayerisWrong();
			}
			Destroy(inventory[0]);
			inventory.RemoveAt(0);
		}
	}
}
