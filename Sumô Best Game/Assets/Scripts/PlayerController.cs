using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Transform playerTransf;
	Rigidbody2D playerBody;

	[SerializeField]
	float vel;

	// Use this for initialization
	void Start () {
		playerTransf = GetComponent<Transform> ();
		playerBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis ("Vertical");

		playerBody.velocity = new Vector2 (x, y) * vel;

		Vector2 moveDirection = playerBody.velocity;
		if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.forward);
		}
	}
}
