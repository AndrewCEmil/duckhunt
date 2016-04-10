using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainController {
	public GameObject target;
	public GameObject bullet;

	public Text scoreText;
	public Text cockedText;

	private int hitCount { get; set;}
	private int shotCount { get; set;}
	private int targetCount { get; set;}
	// Use this for initialization
	void Start () {
		hitCount = 0;
		shotCount = 0;
		targetCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (target.activeSelf) {

		}
	}

	public void TargetHit() {
		target.SetActive (false);
		FinishBullet ();
		hitCount++;
		UpdateScoreText ();
	}

	private void FinishBullet() {
		bullet.SetActive (false);
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
}
