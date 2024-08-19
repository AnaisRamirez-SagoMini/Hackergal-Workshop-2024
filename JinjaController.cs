using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinjaController : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		// variable for jinja's transform component
		Transform tf = GetComponent<Transform>();


		// check if the right arrow is down
		if (Input.GetKey(KeyCode.RightArrow)) {
			// move jinja to the right
			tf.position += Vector3.right * 0.1f;
		}

		// check if the left arrow is down
		if (Input.GetKey(KeyCode.LeftArrow)) {
			// move jinja to the left
			tf.position += Vector3.left * 0.1f;
		}
	}
}
