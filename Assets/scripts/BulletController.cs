using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("target")) {
			other.gameObject.SetActive (false);
			rb.velocity = new Vector3 (0, 0, 0);
			gameObject.SetActive (false);
		}
	}
}
