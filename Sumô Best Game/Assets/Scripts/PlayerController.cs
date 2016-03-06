using UnityEngine;
using System.Collections;
using CnControls;

public class PlayerController : MonoBehaviour {

	Rigidbody2D playerBody;

	[SerializeField]
	float vel;

	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		float x = CnInputManager.GetAxis("Horizontal");
		float y = CnInputManager.GetAxis ("Vertical");

		playerBody.velocity = new Vector2 (x, y) * vel;

		Vector2 moveDirection = playerBody.velocity;
		if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.forward);
		}
	}
}
