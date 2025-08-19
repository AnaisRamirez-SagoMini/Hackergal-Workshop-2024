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

	// a field to store jinja's jump setting
	[SerializeField]
	float jump = 0.3f;

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

		// was the spacebar pressed and is jinja on a platform?
		if (Input.GetKeyDown(KeyCode.Space) && IsJinjaOnPlatform())
		{
			// apply jump force
			velocity.y = jump;
		}

		// apply friction
		velocity.x *= friction;

		// apply gravity
		velocity += Vector3.down * gravity;

		// move jinja by her current velocity
		tf.position += velocity;

		CheckForCollision();

		// if jinja is moving
		if (Mathf.Abs(velocity.x) >= acceleration)
		{
			// get direction from jinja's velocity, 1 or -1
			float direction = Mathf.Sign(velocity.x);
			// make her look the right way
			tf.localScale = new Vector3(direction, 1, 1);
		}

		// get a reference to Animator component
		Animator animator = GetComponentInChildren<Animator>();
		animator.ResetTrigger("Idle");
		animator.ResetTrigger("Run");
		animator.ResetTrigger("Jump");

		// check if jinja is in the air
		if (!IsJinjaOnPlatform())
		{
			// tell the animator to play the jump animation
			animator.SetTrigger("Jump");
		}
		else if (Input.GetKey(KeyCode.LeftArrow) ||
		Input.GetKey(KeyCode.RightArrow) ||
		Mathf.Abs(velocity.x) >= acceleration)
		{
			// tell the animator to play the run animation
			animator.SetTrigger("Run");
		}
		else
		{
			// tell the animator to play the idle animation
			animator.SetTrigger("Idle");
			// make jinja stop moving
			velocity.x = 0;
		}

		if (tf.position.y < -10)
		{
			tf.position = Vector3.zero;
			velocity = Vector3.zero;
		}
	}

	void CheckForCollision()
	{
		Transform tf = GetComponent<Transform>();

		// the start of the ray (jinja's position before she moved)
		Vector3 origin = tf.position - velocity;

		// the direction of the ray
		Vector3 direction = velocity;

		// the length of the ray (the distance jinja moved)
		float length = velocity.magnitude;

		// the result of the raycast
		RaycastHit2D hit = Physics2D.Raycast(origin, direction, length);

		// did jinja go down through a platform when she moved?
		if (velocity.y < 0 && hit.collider != null)
		{
			// put her exactly on the platform
			tf.position = new Vector3(tf.position.x, hit.point.y, tf.position.z);
			// reset her y velocity
			velocity.y = 0;
		}
	}

	bool IsJinjaOnPlatform()
	{
		Transform tf = GetComponent<Transform>();
		bool isJinjaOnPlatform =
		Physics2D.Raycast(tf.position, Vector3.down, 0.1f).collider != null;
		return isJinjaOnPlatform;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// check if jinja hit the sun
		if (other.tag == "Finish")
		{
			// play the sound
			GetComponent<AudioSource>().Play();
		}
	}
}
