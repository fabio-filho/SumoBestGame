using UnityEngine;
using System.Collections;

public class BotAI : MonoBehaviour {

	Rigidbody2D playerBody;
	Rigidbody2D botBody;


	[SerializeField]
	public static float vel;

	float defaultVelocity = 1.5f, velocityIncreaseRate = 0.04f;

	void Start() {
		botBody = gameObject.GetComponent<Rigidbody2D> ();
		playerBody = GameObject.Find ("Player").GetComponent<Rigidbody2D>();

		vel = defaultVelocity;
	}


	void Update2 () {
		
		Rigidbody2D mNearEnemy = null;
		float mDistance = 0;

		foreach (GameObject mEnemyTemp in GameObject.FindGameObjectsWithTag("Enemy")){
			
			Rigidbody2D mEnemy = mEnemyTemp.GetComponent<Rigidbody2D> ();

			if (mNearEnemy == null)
				mNearEnemy = mEnemy;
   
			float mTempDistance = Vector2.Distance (playerBody.position, mEnemy.position); 

			if (mDistance == 0)
				mDistance = mTempDistance;

			if (mTempDistance <= mDistance) {
				mNearEnemy = mEnemy; 
				mDistance = mTempDistance;
			}
			
			Debug.Log (mTempDistance + "  -  "+ (mTempDistance <= mDistance));

			if (botBody == mNearEnemy) {
				followObject (playerBody, botBody);
				//Debug.Log ("followPlayer");
			} else {
				followObject (mNearEnemy, botBody);
				Debug.Log ("followEnemy");
			}
									
		    }

	}


	void Update () {

		followObject (playerBody, botBody);
	}


	void followObject( Rigidbody2D mTarget, Rigidbody2D mBody ){

		Vector2 mBodyPosition   = mBody.position;
		Vector2 mTargetPosition = mTarget.position;

		Vector2 mDistance = mTargetPosition - mBodyPosition;

		Vector2 mMoveDirection = mDistance.normalized;

		if (vel < defaultVelocity)
			vel += velocityIncreaseRate;		
		else 
			mBody.velocity = mMoveDirection * vel;
		
		if (mMoveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(mMoveDirection.y, mMoveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+270, Vector3.forward);
		}
	}


}
