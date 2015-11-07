using UnityEngine;
using System.Collections;

public class BattleManagement : MonoBehaviour 
{
	public float speed;
	public float step;
	public Transform player;
	public Transform enemy;
	public Vector3 playerDefault;
	public Vector3 enemyDefault;
	public bool isPlaying;

	CountdownTimer countdownTimer;
	Camera escapeCamera;

	void Start()
	{
		countdownTimer = GameObject
						 .Find("TimeLabel")
						 .GetComponent<CountdownTimer>();
		escapeCamera = GameObject
					   .Find("EscapeMenu")
					   .camera;
		isPlaying = true;
	}

	void Update () 
	{
		if (isPlaying)
		{
			MoveTowards();
			countdownTimer.StartCountdown();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
			if (escapeCamera.enabled == false)
				escapeCamera.enabled = true;
			else if (escapeCamera.enabled == true)
				escapeCamera.enabled = false;
	}

	void MoveTowards()
	{
		step = speed * Time.deltaTime;
		player.position = Vector3.MoveTowards(player.position, enemy.position, step);
		enemy.position = Vector3.MoveTowards(enemy.position, player.position, step);
	}

	public void ResetPostions()
	{
		player.position = playerDefault;
		enemy.position = enemyDefault;
	}
}