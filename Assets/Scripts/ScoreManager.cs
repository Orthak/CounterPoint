using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour 
{
	public float score;
	public float scoreMultiplyer = 1f;

	BattleManagement battle;
	TextMesh scoreText;
	TextMesh scoreMultiplyerText;

	void Start ()
	{		
		battle = GameObject
				 .Find("CounterBattle")
				 .GetComponent<BattleManagement>();
		scoreText = GameObject
					.Find("ScoreText")
					.GetComponent<TextMesh>();
		scoreMultiplyerText = GameObject
							  .Find("ScoreMultiplyerText")
							  .GetComponent<TextMesh>();

	}
	
	void Update () 
	{
		scoreMultiplyer = Mathf.Clamp(scoreMultiplyer, 1f, 30f);
		battle.speed = Mathf.Clamp(battle.speed, .5f, 3f);
		scoreText.text = score.ToString();
		scoreMultiplyerText.text = string.Format("x{0}", scoreMultiplyer); 
	}

	public void ManageChallenge(string increase)
	{
		switch (increase)
		{
			case "up":
				battle.speed += .2f;
				scoreMultiplyer++;
				break;
			case "down":
				battle.speed -= .4f;
				scoreMultiplyer -= 2;
				break;
		}
	}
}