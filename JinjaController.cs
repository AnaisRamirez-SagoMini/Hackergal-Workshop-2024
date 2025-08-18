using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JinjaController : MonoBehaviour {
		// get jinja's transform component
		Transform tf = GetComponent<Transform>();

		if (Input.GetKey(KeyCode.RightArrow))
		{
			// move jinja one unit to the right
			tf.position += Vector3.right;
		}
}
