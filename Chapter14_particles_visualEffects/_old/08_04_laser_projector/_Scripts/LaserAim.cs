using UnityEngine;

/* ----------------------------------------
 * limit distance of projection based on raycast hit
 */ 
public class LaserAim : MonoBehaviour 
{	
	private Projector projector;

	// small additional distance past hit object for projector far clip plane
	private float margin = 0.5f;
	
	void Start () 
	{
		// cache reference to Projector component
		projector = GetComponent<Projector> ();
	}
	
	void Update () 
	{
		// varaiable needed, since it will be updated by Raycast(...) method
		RaycastHit hit; 
		
		// Create 3D Vector for keeping the Projector's forward direction 
		Vector3 forward = transform.TransformDirection(Vector3.forward);

		// test for Raycast hit
		if (Physics.Raycast(transform.position, forward, out hit))
			// Place the Projector's far clip plane a bit over the hit point
			projector.farClipPlane = hit.distance + margin;
	}

}
