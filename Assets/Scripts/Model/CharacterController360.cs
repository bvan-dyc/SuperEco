using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController360 : MonoBehaviour {
	[Range(0, 50)] public float	speed;
	private Rigidbody2D rbody;
	public Animator anim;

	public void Awake()
	{
		rbody = GetComponent<Rigidbody2D>();
	}

	public void Move(Vector2 movement)
	{
		rbody.velocity = movement * speed;
	}
}
