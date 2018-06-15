using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	[SerializeField] [Range(0, 50)] private float	speed;
	private Rigidbody2D rbody;

	public void Awake()
	{
		rbody = GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 movement)
	{
		rbody.velocity = movement * speed;
	}
}
