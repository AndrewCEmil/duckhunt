using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;

	public GameObject bullet;

	private BulletController bulletController;
	private Rigidbody rb;
	private Rigidbody bulletRb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		bulletController = bullet.gameObject.GetComponent<BulletController> ();
		bulletRb = bullet.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && !bullet.gameObject.activeSelf) {
			bullet.gameObject.transform.position = rb.position + new Vector3(0.0f, 0.0f, 1.0f);
			bulletRb.velocity = new Vector3 (0, 0, 50.0f);
			bullet.gameObject.SetActive (true);
			bulletController.shotCount += 1;
			bulletController.UpdateScoreText ();
		}

		if (Vector3.Distance(bullet.gameObject.transform.position, rb.position) > 100) {
			bullet.gameObject.SetActive(false);
			bullet.gameObject.GetComponent<BulletController> ();
		}
	}

	//Physics stuff in here
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertial = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertial, 0.0f);

		//rb.AddForce (movement * speed);
		rb.MovePosition (rb.position + movement * speed);
	}
}