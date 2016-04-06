using UnityEngine;
using System.Collections;

public class TargetContainerController : MonoBehaviour {
	public GameObject target;
	public Vector2 startPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!target.gameObject.activeSelf) {
			if (Random.Range (0, 100) > 49) { //50 : 50
				target.gameObject.transform.position = new Vector3(startPosition.x, 0, startPosition.y);
				target.gameObject.SetActive (true);
			}
		}
	}
}
