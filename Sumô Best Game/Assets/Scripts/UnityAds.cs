using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{

	[SerializeField]
	ScoreManager scoreManager;


	public void ShowAd()
	{
		Debug.Log ("ShowAd, is ready: " + Advertisement.IsReady ("rewardedVideo"));

		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			scoreManager.updateCoins(50);
			break;

		case ShowResult.Skipped:
			scoreManager.updateCoins(25);
			break;

		case ShowResult.Failed:
			break;
		}
	}
}