using UnityEngine;

/* ----------------------------------------
 * class to demonstrate how to simulate a cloudy/windy
 * outdoor environment with cookie textures
 */ 
public class ShadowMover : MonoBehaviour
{
	// speed of the wind on the X-axis
	public float windSpeedX = 2;

	// speed of the wind on the Z-axis
	public float windSpeedZ = 2;
	
	// cookie texture size
	private float lightCookieSize;
	
	// light object's initial position 
	private Vector3 startPosition;

	// max X value
	private float limitX;

	// max Z value
	private float limitZ;

	// vector for wind movement per second
	private Vector3 windMovement;

	/* ----------------------------------------
	 * At Start, get the light object's initial position
	 * and light cookie size.
	 */
	void Start(){
		// Keep object's initial posision on the startPosition variable
		startPosition = transform.position;

		// Keep clight's ookie size on the lightCookieSize variable
		lightCookieSize = GetComponent<Light>().cookieSize;
		
		// Set a limit for the X-axis position (equal to the initial position plus cookie size)
		limitX = Mathf.Abs(startPosition.x) + lightCookieSize;

		// Set a limit for the X-axis position (equal to the initial position plus cookie size)
		limitZ = Mathf.Abs(startPosition.z) + lightCookieSize;
		
		// create vector for wind movement
		windMovement = new Vector3(windSpeedX, 0, windSpeedZ);
		
	}

	/* ----------------------------------------
	 * if X or Z position would go past cookie size
	 * return that coordinate back to its start value
	 * (wrap around effect)
	 */
	void Update(){
		// Get current position + proportion of wind movement for this frame
		Vector3 position = transform.position + (Time.deltaTime * windMovement);

		// limit (wrap) X and Z based on cookie size 
		position.x = WrapValue(position.x, limitX, startPosition.x);
		position.z = WrapValue(position.z, limitZ, startPosition.z);

		// Update transform position
		transform.position = position;
	}

	/**
	 * if positive value of <n> greater than limit, return startValue
	 * otherwise return <n>
	 */
	private float WrapValue(float n, float limit, float startValue)
	{
		// get positive value
		float absoluteValue = Mathf.Abs(n);
		
		// if exceeds limit, return start value
		if (absoluteValue > limit)
			return startValue;
		else
			// else return n unchanged
			return n;
	}
}
