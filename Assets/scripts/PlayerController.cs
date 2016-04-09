using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;

	public GameObject bullet;

	private BulletController bulletController;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		bulletController = bullet.gameObject.GetComponent<BulletController> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && !bullet.gameObject.activeSelf) {
			bullet.gameObject.transform.position = rb.position;
			bullet.gameObject.SetActive (true);
			bulletController.shotCount += 1;
			bulletController.UpdateScoreText ();
		}

		if (Vector3.Distance(bullet.gameObject.transform.position, rb.position) > 20) {
			bullet.gameObject.SetActive(false);
			bullet.gameObject.GetComponent<BulletController> ();
		}
	}

	//Physics stuff in here
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertial = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (-moveHorizontal, 0.0f, -moveVertial);

		//rb.AddForce (movement * speed);
		rb.MovePosition (rb.position + movement * speed);
	}
}