using UnityEngine;
using System.Collections;

public class TargetContainerController : MonoBehaviour {
	public GameObject target;
	public GameObject bullet;
	public GameObject player;

	private BulletController bulletController;
	private Rigidbody targetRb;
	private int missingFrames;

	// Use this for initialization
	void Start () {
		bulletController = bullet.GetComponent<BulletController> ();
		targetRb = target.GetComponent<Rigidbody> ();
		missingFrames = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!target.gameObject.activeSelf) {
			if (missingFrames > 50) {
				target.transform.position = player.transform.position + new Vector3(0,0,60);
				target.SetActive (true);
				targetRb.velocity = GetRandomVelocity ();
				bulletController.targetCount++;
				bulletController.UpdateScoreText ();
				missingFrames = 0;
			} else {
				missingFrames++;
			}
		}
	}

	Vector3 GetRandomVelocity () {
		return new Vector3 ((float)Random.Range (-10, 10), (float)Random.Range (-10, 10), (float)Random.Range (0, 6));
	}
}
