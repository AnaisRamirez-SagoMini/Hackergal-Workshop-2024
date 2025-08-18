using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinjaController : MonoBehaviour
{
	// a field to store jinja's velocity
	Vector3 velocity = Vector3.zero;

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
			velocity += Vector3.right * 0.1f;
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// move jinja one unit to the left
			velocity += Vector3.left * 0.1f;
		}

		// move jinja by her current velocity
		tf.position += velocity;
	}
}
