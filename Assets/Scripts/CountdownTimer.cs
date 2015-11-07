using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour 
{
	public float countdown;
	public Camera gameOverCamera;

	TextMesh timeText;
	TextMesh finalScoreText;
	ScoreManager scoreManager;
	BattleManagement battleManager;

	void Start () 
	{
		countdown = 30f;
		if (gameOverCamera.enabled == true)
			gameOverCamera.enabled = false;

		timeText = GameObject
				   .Find("TimeText")
				   .GetComponent<TextMesh>();
		finalScoreText = GameObject
						 .Find("FinishScore")
						 .GetComponent<TextMesh>();
		scoreManager = GameObject
					   .Find("ScoreManager")
					   .GetComponent<ScoreManager>();
		battleManager = GameObject
						.Find("CounterBattle")
						.GetComponent<BattleManagement>();
	}

	public void StartCountdown()
	{
		countdown = Mathf.Clamp(countdown, 0f, int.MaxValue);
		if (countdown != 0)
			countdown -= Time.deltaTime;
		else
			ShowGameOverScreen();
		
		timeText.text = string.Format("{0}s", countdown.ToString("0"));
	}

	public void ShowGameOverScreen()
	{
		battleManager.isPlaying = false;
		gameOverCamera.enabled = true;
		finalScoreText.text = scoreManager.score.ToString();
	}
}
