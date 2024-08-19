using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	// a field to store jinja's transform
	[SerializeField]
	Transform jinjaTransform = null;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		// move the camera to jinja's position
		GetComponent<Transform>().position = jinjaTransform.position;
	}
}
