using UnityEngine;
using System.Collections;
using UnityEngine.UI;

enum BulletControllerState { Frozen, Shot, Cocked, Hidden }

public class BulletController : MonoBehaviour {
	public Text scoreText;
	public Text cockedText;
	public GameObject targetContainer;
	public int WarpScalar;
	public GameObject target;

	public int hitCount;
	public int shotCount;
	public int targetCount;

	private TargetContainerController targetContainerController;
	private BulletControllerState state;
	private int frameCount;
	private Rigidbody rb;
	private ConstantForce bulletForce;

	// Use this for initialization
	void Awake () {
		hitCount = 0;
		shotCount = 0;
		targetCount = 0;
		frameCount = 0;
		targetContainerController = targetContainer.GetComponent<TargetContainerController> ();
		state = BulletControllerState.Hidden;
		rb = GetComponent<Rigidbody> ();
		bulletForce = GetComponent<ConstantForce> ();
	}
		
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("target")) {
			targetContainerController.Freeze ();
			hitCount++;
			UpdateScoreText ();
		}
	}

	public void FixedUpdate() {
		frameCount++;
		if (state == BulletControllerState.Frozen) {
			if (frameCount > 100) {
				Renew ();
			}
		} else if (state == BulletControllerState.Shot) {
			if (transform.position.z > target.transform.position.z) {
				targetContainerController.Freeze ();
			}
		}
	}

	public void UpdateScoreText() {
		scoreText.text = "HITS: " + hitCount.ToString() + "\nSHOTS: " + shotCount.ToString() + "\nTARGETS: " + targetCount.ToString();
	}

	public void UpdateCockedText(bool isCocked) {
		if (isCocked) {
			cockedText.text = "GUN COCKED";
		} else {
			cockedText.text = "";
		}
	}

	public void Freeze() {
		state = BulletControllerState.Frozen;
		frameCount = 0;
		rb.isKinematic = true;
		transform.position = new Vector3 (transform.position.x, transform.position.y, ((float)target.transform.position.z) - 0.8f);
	}

	public void Renew() {
		gameObject.SetActive (false);
		targetContainerController.CreateNewTarget ();
		rb.isKinematic = false;
	}

	public void Shoot(Vector3 startPosition, Vector3 lastMovement) {
		gameObject.SetActive (true);
		gameObject.transform.position = startPosition + new Vector3 (0.0f, 0.0f, 1.0f);
		rb.velocity = new Vector3 (0, 0, 50.0f);
		bulletForce.force = lastMovement * WarpScalar;
		shotCount += 1;
		UpdateScoreText ();
		UpdateCockedText (false);
		state = BulletControllerState.Shot;
	}
}
