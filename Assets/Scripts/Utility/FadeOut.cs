using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

	private Image screen;
	[SerializeField] private float fadeDuration;

	private void Awake()
	{
		screen = GetComponent<Image>();
	}

	private void Update()
	{
		screen.DOFade(1f, fadeDuration);
	}
}
