using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;

	public GameObject bullet;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && !bullet.gameObject.activeSelf) {
			bullet.gameObject.transform.position = rb.position;
			bullet.gameObject.SetActive (true);
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