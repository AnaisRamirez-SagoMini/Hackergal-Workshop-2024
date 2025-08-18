using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinjaController : MonoBehaviour
{
	// a field to store jinja's velocity
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
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// get jinja's transform component
		Transform tf = GetComponent<Transform>();

		if (Input.GetKey(KeyCode.RightArrow))
		{
			// move jinja one unit to the right
			velocity += Vector3.right * acceleration;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// move jinja one unit to the left
			velocity += Vector3.left * acceleration;
		}

		// apply friction
		velocity.x *= friction;

		// apply gravity
		velocity += Vector3.down * gravity;

		// move jinja by her current velocity
		tf.position += velocity;
	}
}
