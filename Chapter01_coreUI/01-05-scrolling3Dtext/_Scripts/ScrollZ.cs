using UnityEngine;
using System.Collections;

public class ScrollZ : MonoBehaviour
{
	// variable letting us change how fast we'll move text into the 'distance'
	public float scrollSpeed = 20;

	//-----------------
	void Update ()
	{
		// get current position of parent GameObject
		Vector3 pos = transform.position;

		// get vector pointing into the distance
		Vector3 localVectorUp = transform.TransformDirection(0,1,0);

		// move the text object into the distance to give our 3D scrolling effect
		pos += localVectorUp * scrollSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
