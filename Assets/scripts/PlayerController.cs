using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float phoneSpeed;
	public float bulletWarpScaler;

	public GameObject bullet;

	private BulletController bulletController;
	private Rigidbody rb;
	private Rigidbody bulletRb;
	private ConstantForce bulletForce;
	private bool gunCocked;
	private bool inversionOn;
	private Vector3 lastMovement;
	private Vector3 maxMovement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		bulletController = bullet.gameObject.GetComponent<BulletController> ();
		bulletRb = bullet.GetComponent<Rigidbody> ();
		bulletForce = bullet.GetComponent<ConstantForce> ();
		gunCocked = false;
		lastMovement = new Vector3 (0, 0, 0);
		VariableHolder variables = GameObject.FindWithTag ("VariableHolder").GetComponent<VariableHolder> ();
		phoneSpeed = variables.phoneSpeed;
		inversionOn = variables.invertControl;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && !bullet.activeSelf) {
			ShootBullet ();
		} 

		for (int i = 0; i < Input.touches.Length; i++) {
			Touch touch = Input.touches [i];
			if (touch.phase == TouchPhase.Began && !bullet.activeSelf) {
				CockGun ();
			} else if (touch.phase == TouchPhase.Ended && gunCocked) {
				ShootBullet ();
			}
		}
	}

	//Physics stuff in here
	void FixedUpdate() {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
		
			// Move object across XY plane
			lastMovement.x = -touchDeltaPosition.x * phoneSpeed; 
			lastMovement.y = -touchDeltaPosition.y * phoneSpeed; 
			//rb.transform.Translate (lastMovement);
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertial = Input.GetAxis ("Vertical");
		if (moveHorizontal != 0 || moveVertial != 0) {

			lastMovement.x = moveHorizontal * speed;
			lastMovement.y = moveVertial * speed;
			//rb.AddForce (movement * speed);
			if (Math.Abs(lastMovement.x) > Math.Abs(maxMovement.x)) {
				maxMovement.x = lastMovement.x;
			}
			if (Math.Abs(lastMovement.y) > Math.Abs(maxMovement.y)) {
				maxMovement.y = lastMovement.y;
			}
			rb.MovePosition (rb.position + lastMovement);
		}
	}

	void ShootBullet() {
		Debug.Log ("ShootBullet called.  Last: " + lastMovement.ToString () + ", Max: " + (maxMovement * phoneSpeed).ToString());
		//bulletController.Shoot (rb.position, maxMovement * phoneSpeed);
		if (inversionOn) {
			bulletController.Shoot (rb.position, lastMovement);
		} else {
			bulletController.Shoot (rb.position, lastMovement * -1.0f);
		}
		gunCocked = false;
	}

	void CockGun() {
		gunCocked = true;
		bulletController.UpdateCockedText (true);
		lastMovement.x = 0;
		lastMovement.y = 0;
		lastMovement.z = 0;
		maxMovement.x = 0;
		maxMovement.y = 0;
		maxMovement.z = 0;
	}
}