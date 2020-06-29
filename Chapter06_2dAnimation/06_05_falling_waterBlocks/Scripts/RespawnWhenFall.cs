using UnityEngine;
using System.Collections;

public class RespawnWhenFall : MonoBehaviour
{
	// variable to record the POSITION where our player object starts at
	// so we can reset the position back to this when he needs to respawn (e.g. when a life is lost)
	private Vector3 startPosition;

	//---------------------------------------
	void Start ()
	{
		// record position when scene starts
		startPosition = transform.position;	
	}
	
	//---------------------------------------
	void Update ()
	{
		// if we have fallen to low down (Y < -10)
		// then respawn us
		if(transform.position.y < -10)
			Respawn();
	}

	//---------------------------------------
	// set velocity to zero (so we stop left/right/up/down movement)
	// and then move us to our, cached, start position
	void Respawn()
	{
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		transform.position = startPosition;
	}
}
