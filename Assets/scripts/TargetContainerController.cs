using UnityEngine;
using System.Collections;

enum TargetContainerControllerState { HiddenSleep, Moving, Frozen };

public class TargetContainerController : MonoBehaviour {
	public GameObject target;
	public GameObject bullet;
	public GameObject player;
	public float PlayerDistance;
	public float MaxSpeed;


	private BulletController bulletController;
	private Rigidbody targetRb;
	private int frameCounter;
	private TargetContainerControllerState state;

	// Use this for initialization
	void Start () {
		bulletController = bullet.GetComponent<BulletController> ();
		targetRb = target.GetComponent<Rigidbody> ();
		frameCounter = 0;
	}

	// Update is called once per frame
	void Update () {
		frameCounter++;
		if (state == TargetContainerControllerState.HiddenSleep) {
			if (frameCounter > 50) {
				CreateNewTarget ();
			}
		} else if (state == TargetContainerControllerState.Frozen) {
			if (frameCounter > 100) {
				state = TargetContainerControllerState.HiddenSleep;
				Hide ();
			}
		}
	}

	public void CreateNewTarget() {
		target.transform.position = player.transform.position + new Vector3(0,0,PlayerDistance);
		target.SetActive (true);
		targetRb.velocity = GetRandomVelocity ();
		bulletController.targetCount++;
		bulletController.UpdateScoreText ();
		frameCounter = 0;
		state = TargetContainerControllerState.Moving;
	}

	Vector3 GetRandomVelocity () {
		return new Vector3 ((float)Random.Range (-MaxSpeed / 3, MaxSpeed / 3), (float)Random.Range (-MaxSpeed, MaxSpeed), 0);
	}

	public void Freeze() {
		targetRb.velocity = new Vector3 (0, 0, 0);
		state = TargetContainerControllerState.Frozen;
		frameCounter = 0;
		bulletController.Freeze ();
	}

	public void Hide() {
		frameCounter = 0;
		target.SetActive (false);
	}
}
