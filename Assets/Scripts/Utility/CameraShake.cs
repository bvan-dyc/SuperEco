using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
	public Camera mainCamera;
	public float duration;
	[Range(0, 10)]
	public float strength = 3;
	[Range(0, 60)]
	public int vibrato = 10;
	[Range(0, 180)]
	public float randomness = 90;
	public bool fadeOut = true;

	public void Shake()
	{
		mainCamera.DOShakePosition(duration, strength, vibrato, randomness, fadeOut);
	}
}