using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public const int COINS_TO_REVIVE = 100;

	[SerializeField]
	Text scoreText;

	[SerializeField]
	Text highScoreText;

	[SerializeField]
	Text coinsText;

	int score = 0, high_score=0;
	int coins = 0;

	const string ID_COINS = "ID_COINS";
	const string ID_SCORE = "ID_SCORE";

	void Start(){	

		if(!PlayerPrefs.HasKey (ID_COINS))
			PlayerPrefs.SetInt (ID_COINS, 0);

		if(!PlayerPrefs.HasKey (ID_SCORE))
			PlayerPrefs.SetInt (ID_SCORE, 0);
		
		coinsText.text = PlayerPrefs.GetInt (ID_COINS).ToString();
		high_score = PlayerPrefs.GetInt (ID_SCORE);
		highScoreText.text = PlayerPrefs.GetInt (ID_SCORE).ToString();
	}

	public int Coins{
		get{ 
			return coins;
		}
	}

	public void updateCoins(int number = 2){
		coins += number;
		coinsText.text = coins.ToString();
		PlayerPrefs.SetInt (ID_COINS, coins);
		PlayerPrefs.Save ();
	}

	public void addScore (int number) {
		score += number;
		scoreText.text = score.ToString();

		if (score > high_score) {
			high_score = score;
			PlayerPrefs.SetInt (ID_SCORE, score);
			PlayerPrefs.Save ();
			highScoreText.text = PlayerPrefs.GetInt (ID_SCORE).ToString();
		}
	}

	public void resetScore() {
		score = 0;
	}

}
