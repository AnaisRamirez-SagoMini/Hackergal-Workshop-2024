using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JinjaController : MonoBehaviour
{
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
			tf.position += Vector3.right * 0.1f;
		}
	}
}
