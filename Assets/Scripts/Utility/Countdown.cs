using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour {
	private TextMeshProUGUI scoreText;
	[SerializeField] [Range(0, 960)] private float timeLimit = 180;
	[SerializeField] [Range(0, 120)] private float lastStretchTime = 30;
	[SerializeField] private Color lastStretchColor = new Color(255f, 0f, 0f);
	private float timer;

	private void Awake()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	}

	private void Start()
	{
		timer = timeLimit;
	}

	private void Update()
	{
		if (timer != 0)
			timer -= Time.deltaTime;
		if (timer <= lastStretchTime)
		{
			scoreText.color = lastStretchColor;
			Debug.Log("TimeIsRunningOut");
		}
		if (timer < 0)
		{
			timer = 0;
			Debug.Log("GameEnd");
		}
		scoreText.text = timer.ToString("000");
	}
}
