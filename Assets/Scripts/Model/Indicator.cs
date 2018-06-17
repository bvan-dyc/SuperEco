using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Indicator : MonoBehaviour {
	[SerializeField] private SpriteRenderer VSprite;
	[SerializeField] private SpriteRenderer XSprite;
	[SerializeField] private float fadeOutDuration = 0.5f;

	private bool isRight = false;
	private bool isWrong = false;

	public void Update() {
		if (isRight)
		{
			VSprite.DOFade(1, 0);
			VSprite.DOFade(0, fadeOutDuration);
			isRight = false;
		}
		else if (isWrong)
		{
			XSprite.DOFade(1, 0);
			XSprite.DOFade(0, fadeOutDuration);
			isWrong = false;
		}
	}

	public void PlayerisRight() {
		isRight = true;
	}

	public void PlayerisWrong() {
		isWrong = true;
	}
}
