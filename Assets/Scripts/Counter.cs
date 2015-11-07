using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour 
{
	public ScoreManager scoreManager;
	public GameObject parent;
	public BattleManagement battle;

	public AudioSource perfectCounterSound;
	public AudioSource CounterSound;
	public AudioSource missSound;


	CounterType counterType;

	void OnTriggerStay(Collider collider)
	{
		if (Input.GetKeyDown(KeyCode.Space))
			switch(counterType)
			{
				case CounterType.PerfectCounter:
					scoreManager.score += 100 * scoreManager.scoreMultiplyer;
					perfectCounterSound.Play();
					scoreManager.ManageChallenge("up");
					goto default;
				case CounterType.GoodCounter:
					scoreManager.score += 50 * scoreManager.scoreMultiplyer;
					CounterSound.Play();
					scoreManager.ManageChallenge("up");
					goto default;
				case CounterType.OkayCounter:
					scoreManager.score += 25 * scoreManager.scoreMultiplyer;
					CounterSound.Play();
					scoreManager.ManageChallenge("up");
					goto default;
				default:
					battle.ResetPostions();
					break;
			}
	}

	void OnTriggerEnter(Collider collider)
	{
		switch (collider.tag)
		{
			case "PerfectCounter":
				counterType = CounterType.PerfectCounter;
				break;
			case "GoodCounter":
				counterType = CounterType.GoodCounter;
				break;
			case "OkayCounter":
				counterType = CounterType.OkayCounter;
				break;
			case "Player":
				scoreManager.ManageChallenge("down");
				missSound.Play();
				battle.ResetPostions();
				break;
		}
	}
}
