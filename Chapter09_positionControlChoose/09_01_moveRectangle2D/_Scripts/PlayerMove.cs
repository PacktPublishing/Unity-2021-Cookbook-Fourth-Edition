using UnityEngine;
using System.Collections;

/*
 * basic 2D character controller
 * use array keys / WASD to move object up/down/left/right
 */
public class PlayerMove : MonoBehaviour
{
	// reference to object with MAX X and Y
	public Transform corner_max;

	// reference to object with MIN X and Y
	public Transform corner_min;

	// min X
	private float x_min;

	// min Y
	private float y_min;

	// max X
	private float x_max;

	// max Y
	private float y_max;
	
	// change speed
	public float speed = 10;

	// cached reference to a physics RigidBody
	private Rigidbody2D rigidBody2D;

	// the new velocity based on inputs
	private Vector2 newVelocity;

	//--------------------------
	// get reference tot the RigidBody 2D compoonent
	// that is in the parent GameObject to which an instance of this script has been added
	void Awake()
	{
		rigidBody2D = GetComponent<Rigidbody2D>();
		x_max = corner_max.position.x;
		x_min = corner_min.position.x;
		y_max = corner_max.position.y;
		y_min = corner_min.position.y;
	}

	//---------------------------
	void Update()
	{
		// read from movement keys
		// arrow keys / WASD
		// GetAxis returns values between -1.0...0...+1.0
		float xMove = Input.GetAxis("Horizontal");
		float yMove = Input.GetAxis("Vertical");

		// mutliple by speed factor
		float xSpeed = xMove * speed;
		float ySpeed = yMove * speed;

		// create (dx,dy) vector object
		newVelocity = new Vector2(xSpeed, ySpeed);
	}
	
	//---------------------------
	void FixedUpdate()
	{
		// set the velocity of the Physics rigid body to this (x,y) vector
		rigidBody2D.velocity = newVelocity;

		// restrict player movement
		KeepWithinMinMaxRectangle();
	} 
	
	//---------------------------
	private void KeepWithinMinMaxRectangle()
	{
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		float clampedX = Mathf.Clamp(x, x_min, x_max);
		float clampedY = Mathf.Clamp(y, y_min, y_max);
		transform.position = new Vector3(clampedX, clampedY, z);
	} 
	
	/// <summary>
	/// Draw gizmos - to show the rectangular boundary
	/// </summary>
	void OnDrawGizmos()
	{
		Vector3 top_right = Vector3.zero;
		Vector3 bottom_right = Vector3.zero;
		Vector3 bottom_left = Vector3.zero;
		Vector3 top_left = Vector3.zero;

		if (corner_max && corner_min)
		{
			top_right = corner_max.position;
			bottom_left = corner_min.position;

			bottom_right = top_right;
			bottom_right.y = bottom_left.y;

			top_left = top_right;
			top_left.x = bottom_left.x;
		}

		//Set the following gizmo colors to YELLOW
		Gizmos.color = Color.yellow;

		//Draw 4 lines making a rectangle
		Gizmos.DrawLine(top_right, bottom_right);
		Gizmos.DrawLine(bottom_right, bottom_left);
		Gizmos.DrawLine(bottom_left, top_left);
		Gizmos.DrawLine(top_left, top_right);
	}
}
