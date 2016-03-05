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
	GameObject teste;

	void Start() {
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space))
			Instantiate (teste);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("DEAD");
			Time.timeScale = 0;
			loseUI.SetActive (true);
		} else {
			Destroy (other.gameObject);
		}
	}
}
