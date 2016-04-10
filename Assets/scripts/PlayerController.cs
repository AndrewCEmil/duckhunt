using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
	private Vector3 lastMovement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		bulletController = bullet.gameObject.GetComponent<BulletController> ();
		bulletRb = bullet.GetComponent<Rigidbody> ();
		bulletForce = bullet.GetComponent<ConstantForce> ();
		gunCocked = false;
		lastMovement = new Vector3 (0, 0, 0);
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

		if (Vector3.Distance(bullet.gameObject.transform.position, rb.position) > 100) {
			bullet.SetActive(false);
			bullet.GetComponent<BulletController> ();
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
			rb.transform.Translate (lastMovement);
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertial = Input.GetAxis ("Vertical");
		if (moveHorizontal != 0 || moveVertial != 0) {
			lastMovement.x = moveHorizontal * speed;
			lastMovement.y = moveVertial * speed;
			//rb.AddForce (movement * speed);
			rb.MovePosition (rb.position + lastMovement);
		}
	}

	void ShootBullet() {
		bullet.gameObject.transform.position = rb.position + new Vector3 (0.0f, 0.0f, 1.0f);
		bulletRb.velocity = new Vector3 (0, 0, 50.0f);
		bulletForce.force = lastMovement * bulletWarpScaler;
		bullet.gameObject.SetActive (true);
		bulletController.shotCount += 1;
		bulletController.UpdateScoreText ();
		gunCocked = false;
		bulletController.UpdateCockedText (false);
	}

	void CockGun() {
		gunCocked = true;
		bulletController.UpdateCockedText (true);
	}
}