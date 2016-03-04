using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

	[SerializeField]
	GameObject player;

	[SerializeField]
	GameObject ring;
	
	// Update is called once per frame
	void Update () {
		Vector2 playerPos = new Vector2 (player.transform.position.x, player.transform.position.y);
		Vector2 ringPos = new Vector2 (ring.transform.position.x, ring.transform.position.y);

		float distance = Vector2.Distance (playerPos, ringPos);
		//float buffer = ring.transform.localScale.x / 2 + player.transform.localScale.x;
		float buffer = ring.GetComponent<Renderer>().bounds.size.x/2 + player.GetComponent<Renderer>().bounds.size.x / 2;

		if (distance > buffer) {
			Debug.Log ("DEAD");
		} else {
			Debug.Log ("NOT DEAD");
		}
	}
}
