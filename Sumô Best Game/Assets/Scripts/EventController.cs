using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

	[SerializeField]
	GameObject player;

	[SerializeField]
	GameObject ring;

	[SerializeField]
	GameObject loseUI;

	[SerializeField]
	ScoreManager scoreManager;

	[SerializeField]
	UnityAds unityAds;

	void Start() {
		Time.timeScale = 1;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Time.timeScale = 0;
			loseUI.SetActive (true);
			unityAds.ShowAd ();
		} else {
			Destroy (other.gameObject);
			scoreManager.addScore ((int)other.attachedRigidbody.mass);
		}
	}
}
