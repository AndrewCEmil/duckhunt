using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {
	public Text scoreText;
	public Text cockedText;

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
		if (other.CompareTag("target")) {
			other.gameObject.SetActive (false);
			Finish ();
			hitCount++;
			UpdateScoreText ();
		}
	}

	public void UpdateScoreText() {
		scoreText.text = "HITS: " + hitCount.ToString() + ", SHOTS: " + shotCount.ToString() + ", TARGETS: " + targetCount.ToString();
	}

	public void UpdateCockedText(bool isCocked) {
		if (isCocked) {
			cockedText.text = "GUN COCKED";
		} else {
			cockedText.text = "";
		}
	}

	public void Finish() {
		gameObject.SetActive (false);
	}
}
