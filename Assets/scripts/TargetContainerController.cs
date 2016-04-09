using UnityEngine;
using System.Collections;

public class TargetContainerController : MonoBehaviour {
	public GameObject target;
	public GameObject bullet;
	public GameObject player;

	private TargetController targetController;
	private BulletController bulletController;

	// Use this for initialization
	void Start () {
		targetController = target.GetComponent<TargetController> ();
		targetController.velocity = GetRandomVelocity ();
		bulletController = bullet.GetComponent<BulletController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!target.gameObject.activeSelf) {
			if (Random.Range (0, 100) > 49) { //50 : 50
				target.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, 0, player.gameObject.transform.position.z);
				targetController.velocity = GetRandomVelocity ();
				target.gameObject.SetActive (true);
				bulletController.targetCount++;
				bulletController.UpdateScoreText ();
			}
		}
	}

	Vector2 GetRandomVelocity () {
		return new Vector2 (((float)Random.Range (-8, 8)) / 100.0f, ((float)Random.Range (-8, 8)) / 100.0f);
	}
}
