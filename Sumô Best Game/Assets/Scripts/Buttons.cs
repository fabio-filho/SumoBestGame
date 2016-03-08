using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	[SerializeField]
	ScoreManager scoreManager;

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


}
