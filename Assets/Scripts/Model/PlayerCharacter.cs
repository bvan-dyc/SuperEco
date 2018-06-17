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
	[SerializeField] private SpriteRenderer Crown;
	[SerializeField] private TextMeshProUGUI scoreText;

	[SerializeField] private AudioClip takeAudio;
	[SerializeField] private AudioClip failAudio;
	[SerializeField] private AudioClip scoreUp1Audio;
	[SerializeField] private AudioClip powerupAudio;

	[SerializeField] private float scaleDuration;

	public int			score = 0;
	public bool			isWinning = false;
	[SerializeField] private int scoreMultiplier = 1;
	public bool			isUpped = false;

	private Vector2			knockbackDirection;
	private Rigidbody2D		rb;
	private AudioSource		playerAS;
	private Indicator		indicator;
	private float			timer = 0f;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		indicator = GetComponent<Indicator>();
		playerAS = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (timer != 0)
			timer -= Time.deltaTime;
		if (timer < 0)
		{
			isUpped = false;
		}
		if (scoreText)
			scoreText.text = score.ToString("000");
		if (isWinning == true)
		{
			Debug.Log(gameObject.name + " is winning!");
			Color tmp = Crown.color;
			tmp.a = 1f;
			Crown.color = tmp;
		}
		else
		{
			Color tmp = Crown.color;
			tmp.a = 0f;
			Crown.color = tmp;
		}
	}

	private void Knockback(Vector2 direction)
	{
		Vector2 knockbackPosition = new Vector2(transform.position.x + (knockbackDistance * direction.x), transform.position.y + (knockbackDistance * direction.y));
		rb.DOMove(knockbackPosition, knockbackDuration);
	}

	public void Powerup_Speed(float speedMod, float powerupDuration)
	{
		isUpped = true;
		timer += powerupDuration;
		GetComponent<CharacterController360>().speed *= speedMod;
		playerAS.PlayOneShot(powerupAudio);
	}

	public void Powerup_Multiplier(float speedMod, float powerupDuration)
	{
		isUpped = true;
		timer += powerupDuration;
		scoreMultiplier *= 2;
		playerAS.PlayOneShot(powerupAudio);
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
				playerAS.PlayOneShot(takeAudio);
				inventoryX.Add(other.gameObject);
			}
			if (isPressed == "Y" && inventoryY.Count < inventorySize) {
				other.gameObject.transform.position = YSpawn.position;
				other.gameObject.GetComponent<Item>().Hold();
				playerAS.PlayOneShot(takeAudio);
				inventoryY.Add(other.gameObject);
			}
			if (isPressed == "B" && inventoryB.Count < inventorySize) {
				other.gameObject.transform.position = BSpawn.position;
				other.gameObject.GetComponent<Item>().Hold();
				playerAS.PlayOneShot(takeAudio);
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
				AddScore(inventory[0].GetComponent<Item>().scoreBonus * scoreMultiplier);
				indicator.PlayerisRight();
				playerAS.PlayOneShot(scoreUp1Audio);
			}
			else
			{
				AddScore(-1 * inventory[0].GetComponent<Item>().scoreMalus);
				indicator.PlayerisWrong();
				playerAS.PlayOneShot(failAudio);
			}
			Destroy(inventory[0]);
			inventory.RemoveAt(0);
		}
	}
}
