using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpandDOwn : MonoBehaviour {
	private float timer = 0;
	[SerializeField] private float scaleDuration = 0.2f;
	[SerializeField] private float scaleTo = 1.3f;

	public Transform sprite;

	private void Update()
	{
		if (timer == 0)
			sprite.DOScale(scaleTo, scaleDuration);
		if (timer != 0)
			timer -= Time.deltaTime;
		if (timer <= 0)
		{

		}
	}
}
