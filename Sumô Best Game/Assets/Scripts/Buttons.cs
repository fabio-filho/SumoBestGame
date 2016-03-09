using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	[SerializeField]
	ScoreManager scoreManager;

	[SerializeField]
	SpawnerController spawnerController;


	public void playGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Jogo");
	}

	public void backToMenu() {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Menu");
	}

	public void quitGame() {
		Application.Quit ();
	}

	public void RestartGame() {

		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
		scoreManager.resetScore ();
	}


	public void Revive(){

		if (scoreManager.Coins < ScoreManager.COINS_TO_REVIVE) {
			return;
		}
		spawnerController.killEnemies ();
		spawnerController.continueGame ();
	}


}
