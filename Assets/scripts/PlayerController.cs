using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;

	public GameObject bullet;

	private BulletController bulletController;
	private Rigidbody rb;
	private Rigidbody bulletRb;
	private bool gunCocked;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		bulletController = bullet.gameObject.GetComponent<BulletController> ();
		bulletRb = bullet.GetComponent<Rigidbody> ();
		gunCocked = false;
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
			rb.transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertial = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertial, 0.0f);

		//rb.AddForce (movement * speed);
		rb.MovePosition (rb.position + movement * speed);
	}

	void ShootBullet() {
		bullet.gameObject.transform.position = rb.position + new Vector3 (0.0f, 0.0f, 1.0f);
		bulletRb.velocity = new Vector3 (0, 0, 50.0f);
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