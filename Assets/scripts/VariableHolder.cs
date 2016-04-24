using UnityEngine;
using System.Collections;

public class VariableHolder : MonoBehaviour {

	public bool useGravity;
	public float phoneSpeed; 

	private static GameObject instance;

	void Awake() {
		if (instance == null) {
			DontDestroyOnLoad (transform.gameObject);
			instance = gameObject;
		} else {
			Destroy (gameObject);
		}
	}

	public void GravityButtonClicked() {
		useGravity = !useGravity;
	}

	public void SetPhoneSpeed() {

	}
}
