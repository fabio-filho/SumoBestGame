using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CnControls;

public class PlayerController : MonoBehaviour {


	[SerializeField]
	float pushForce = 40;

	[SerializeField]
	SimpleButton buttonEnemyPush;

	[SerializeField]
	float vel;

	Rigidbody2D playerBody;

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
				if (CnInputManager.GetButtonDown ("EnemyPush")) {
					
					Vector2 buffer;
					buffer = (other.attachedRigidbody.position - playerBody.position).normalized;

					BotAI.vel = 0f;
					other.attachedRigidbody.velocity = Vector2.zero;
					other.attachedRigidbody.AddForce ((buffer * pushForce) / Time.fixedDeltaTime, ForceMode2D.Force);

					canPush = false;
					timeLeftToEnablePushButton = timeLeftToEnablePushButtonDefault;
					buttonEnemyPush.gameObject.GetComponent<Image>().color = new Color32(107, 107, 107, 125);
				}
			}
		}
		
	}


	void CountDownToEnablePushButton(){

		timeLeftToEnablePushButton -= Time.deltaTime;

		if (timeLeftToEnablePushButton < 0) {				
			buttonEnemyPush.gameObject.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
			canPush = true;
		}
		
	}
		


}
