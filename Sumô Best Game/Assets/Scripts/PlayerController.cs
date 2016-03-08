using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CnControls;

public class PlayerController : MonoBehaviour {


	[SerializeField]
	float pushForce = 500000;

	Rigidbody2D playerBody;

	[SerializeField]
	float vel;

	bool canPush = true; 

	const float timeLeftToEnablePushButtonDefault = 3;
	float timeLeftToEnablePushButton = 3;


	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		//Player moving
		float x = CnInputManager.GetAxis("Horizontal");
		float y = CnInputManager.GetAxis ("Vertical");

		playerBody.velocity = new Vector2 (x, y) * vel;

		Vector2 moveDirection = playerBody.velocity;
		if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.forward);
		}


		//Push button.
		Debug.Log (canPush);
		if(!canPush)
			CountDownToEnablePushButton ();
		
	}


	void OnTriggerStay2D(Collider2D other){

		if (canPush) {
			if (other.gameObject.tag == "Enemy") {
				if (Input.GetButtonDown ("EnemyPush")) {
					
					Vector2 buffer;
					buffer = (other.attachedRigidbody.position - playerBody.position).normalized;
					other.attachedRigidbody.AddForce (buffer * pushForce * Time.deltaTime);
					BotAI.vel = 0f;
					canPush = false;
					timeLeftToEnablePushButton = timeLeftToEnablePushButtonDefault;
				}
			}
		}
		
	}


	void CountDownToEnablePushButton(){

		timeLeftToEnablePushButton -= Time.deltaTime;

		if (timeLeftToEnablePushButton < 0)
			canPush = true;
		
	}
		
}
