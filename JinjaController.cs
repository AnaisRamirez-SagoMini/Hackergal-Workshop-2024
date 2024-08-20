using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinjaController : MonoBehaviour {

	// a field to store Jinja's velocity
	Vector3 velocity = Vector3.zero;

	// a field to store jinja's acceleration setting
	[SerializeField]
	float acceleration = 0.1f;

	// a field to store jinja's friction setting
	[SerializeField]
	float friction = 0.9f;

	// a field to store jinja's gravity setting
	[SerializeField]
	float gravity = 0.02f;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		// variable for jinja's transform component
		Transform tf = GetComponent<Transform>();

		// add friction
		velocity.x *= friction;

		//apply gravity 
		velocity += Vector3.down * gravity;

		// check if the right arrow is down
		if (Input.GetKey(KeyCode.RightArrow)) {
			// increasing velocity
			velocity += Vector3.right * acceleration;
		}

		// check if the left arrow is down
		if (Input.GetKey(KeyCode.LeftArrow)) {
			// decreasing velocity
			velocity += Vector3.left * acceleration;
		}

		//move jinja by her current velocity
		tf.position += velocity;

		//COLLISION

		//the start of the ray (jinja's position before she moved)
		Vector3 origin = tf.position - velocity;

		// the direction of the ray
		Vector3 direction = velocity;

		// the length of the ray (the distance jinja moved)
		float length = velocity.magnitude;

		// the result of the raycast
		RaycastHit2D hit = Physics2D.Raycast(origin, direction, length);

		// did jinja go down through a platform when she moved?
		if (velocity.y < 0 && hit.collider != null) {
			// put jinja exactly on the platform
			tf.position = new Vector3(tf.position.x, hit.point.y, tf.position.z);

			// reset her y velocity
			velocity.y = 0;
		}
	}
}
