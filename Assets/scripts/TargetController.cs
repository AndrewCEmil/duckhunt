using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	public Vector2 startPosition;
	public Vector2 velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.position = gameObject.transform.position + new Vector3 (velocity.x, 0, velocity.y);
	}
}
