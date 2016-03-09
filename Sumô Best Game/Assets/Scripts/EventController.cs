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
	GameObject timeUI;

	void Start() {
		Time.timeScale = 1;
	}

	void OnTriggerExit2D(Collider2D other)
	{			
		if (other.gameObject.CompareTag ("Player")) {
			Time.timeScale = 0;
			loseUI.SetActive (true);
			timeUI.SetActive (false);
			player.GetComponent<Rigidbody2D>().position = Vector2.zero;

		} else {
			Destroy (other.gameObject);
			scoreManager.addScore ((int)other.attachedRigidbody.mass);
		}
	}


}
