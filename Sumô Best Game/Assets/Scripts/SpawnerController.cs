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
			countdownAndSpawn ();
		}
	}

	void spawnEnemies() {
		for (int i = 0; i < easySpawnSeq[level]; i++)
			GameObject.Instantiate (enemyEasy);
		for (int i = 0; i < mediumSpawnSeq[level]; i++)
			GameObject.Instantiate (enemyMedium);
		for (int i = 0; i < hardSpawnSeq[level]; i++)
			GameObject.Instantiate (enemyHard);
		level++;
	}

	void countdownAndSpawn() {
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

}
