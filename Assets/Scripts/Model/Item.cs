using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour {
	public int		scoreBonus = 1;
	public int		scoreMalus = 1;

	public string	destination = "";
	[SerializeField] private bool	simulated;
	[SerializeField] private float	spawnDuration = 0.2f;
	[Range(0, 50)] public float		speed = 5;
	[Range(0, 5)] [SerializeField] private float	scaleTo = 1.5f;

	private Rigidbody2D rb;

	public void Awake() {
		rb = GetComponent<Rigidbody2D>();
		transform.DOScale(0,0);
	}

	public void Start()
	{
		transform.DOScale(1.5f, spawnDuration);
	}

	public void Update() {
		if (transform.localScale.x >= scaleTo)
		{
			transform.DOScale(1f, spawnDuration);
		}
		if (simulated)
			rb.velocity = Vector2.down * speed;
	}

	public void Hold() {
		simulated = true;
	}
}
