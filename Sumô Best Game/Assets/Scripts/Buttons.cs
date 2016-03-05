using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public void RestartGame() {
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}
}
