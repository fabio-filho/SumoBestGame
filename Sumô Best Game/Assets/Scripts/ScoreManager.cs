using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	[SerializeField]
	Text scoreNumber;

	int score;

	public void addScore (int number) {
		score += number;
		scoreNumber.text = score.ToString();
	}

	public void resetScore() {
		score = 0;
	}

}
