using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnerController : MonoBehaviour {

	[SerializeField]
	GameObject enemyEasy;

	[SerializeField]
	GameObject enemyMedium;

	[SerializeField]
	GameObject enemyHard;

	[SerializeField]
	GameObject timerUI;

	[SerializeField]
	Text roundText;

	[SerializeField]
	Text counterText;

	[SerializeField]
	GameObject loseUI;

	[SerializeField]
	ScoreManager scoreManager;

	[SerializeField]
	Rigidbody2D playerBody;

	int[] easySpawnSeq;
	int[] mediumSpawnSeq;
	int[] hardSpawnSeq;

	int level;

	float timeLeft = 4;

	void Start() {
		//spawnSeq = new int[]{1,2,3,7,8,9};

		easySpawnSeq = new int[]{1,2,3,6,6,6};
		mediumSpawnSeq = new int[]{0,0,0,1,2,2};
		hardSpawnSeq = new int[]{0,0,0,0,0,1};

		level = 0;
	}

	void Update() {
		if (GameObject.FindWithTag ("Enemy") == null) {
			if (!loseUI.activeInHierarchy)
				countdownAndSpawn ();			
		}
	}

	void spawnEnemies() {
		int seq;
		seq = level;
		if (level > 5) {
			seq = 5;
		}
		for (int i = 0; i < easySpawnSeq[seq]; i++)
			GameObject.Instantiate (enemyEasy);
		for (int i = 0; i < mediumSpawnSeq[seq]; i++)
			GameObject.Instantiate (enemyMedium);
		for (int i = 0; i < hardSpawnSeq[seq]; i++)
			GameObject.Instantiate (enemyHard);		
		
		level++;

		if(level != 1)
			scoreManager.updateCoins ();
	}

	public void countdownAndSpawn() {
		
		timerUI.SetActive (true);
		timeLeft -= Time.deltaTime;
		counterText.text = ((int)timeLeft).ToString ();
		roundText.text = "Rodada " + (level + 1).ToString ();

		if (timeLeft < 0) {
			spawnEnemies ();
			timerUI.SetActive (false);
			timeLeft = 4;
		}

	}


	public void continueGame(){

		level--;
		timeLeft = 4;
		loseUI.SetActive (false);
		scoreManager.updateCoins (-ScoreManager.COINS_TO_REVIVE);
		Time.timeScale = 1;
		countdownAndSpawn ();
	}


	public void killEnemies(){

		foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Enemy"))
			Destroy (gameObject);
	}

}
