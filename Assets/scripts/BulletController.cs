using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {
	public Text scoreText;

	public int hitCount;
	public int shotCount;
	public int targetCount;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		hitCount = 0;
		shotCount = 0;
		targetCount = 0;
	}
		
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("target")) {
			other.gameObject.SetActive (false);
			rb.velocity = new Vector3 (0, 0, 0);
			gameObject.SetActive (false);
			hitCount++;
			UpdateScoreText ();
		}
	}

	public void UpdateScoreText() {
		scoreText.text = "HITS: " + hitCount.ToString() + ", SHOTS: " + shotCount.ToString() + ", TARGETS: " + targetCount.ToString();
	}
}
