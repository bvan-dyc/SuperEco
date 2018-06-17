using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController360 : MonoBehaviour {
	[Range(0, 50)] public float	speed;
	private Rigidbody2D rbody;
	[SerializeField] private Animator anim;
	[SerializeField] private float epsilon = 0.3f;

	public void Awake()
	{
		rbody = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		if (rbody.velocity.x == 0 && rbody.velocity.y == 0)
		{
			anim.SetBool("isWalking", false);
		}
	}

	public void Move(Vector2 movement)
	{
		anim.SetBool("isWalking", true);
		rbody.velocity = movement * speed;
		if (movement.y >= epsilon)
			anim.SetTrigger("faceNorth");
		else if (movement.y < epsilon)
			anim.SetTrigger("faceSouth");
		else if (movement.x <= epsilon)
			anim.SetTrigger("faceLeft");
		else if (movement.x > epsilon)
			anim.SetTrigger("faceRight");
	}
}
