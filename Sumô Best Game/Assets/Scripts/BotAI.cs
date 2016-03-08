using UnityEngine;
using System.Collections;

public class BotAI : MonoBehaviour {

	Rigidbody2D playerBody;
	Rigidbody2D botBody;

	Vector2 playerPos;
	Vector2 botPos;
	Vector2 distanceVector;


	[SerializeField]
	public static float vel;

	float defaultVelocity = 1.5f;

	void Start() {
		botBody = gameObject.GetComponent<Rigidbody2D> ();
		playerBody = GameObject.Find ("Player").GetComponent<Rigidbody2D>();

		vel = defaultVelocity;
	}

	// Update is called once per frame
	void Update () {

		Debug.Log (vel);

		playerPos = playerBody.position;
		botPos = botBody.position;

		distanceVector = playerPos - botPos;

		Vector2 moveDirection = distanceVector.normalized;


		if (vel < defaultVelocity)
			vel += 0.04f;		
		else 
			botBody.velocity = moveDirection * vel;
					

		if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.forward);
		}


	}
}
