using UnityEngine;
/* ----------------------------------------
 * class to demonstrate how to call 
 * a function from a script attached to a Reflection Probe
 */ 
public class RandomRotation : MonoBehaviour {
	// A variable to receive the Reflection Probe game object
	private GameObject probe; 

	// A variable to access the 'UpdateProbe' script, attached to the Reflection probe
	private UpdateProbe updateProbe;
	
	/* ----------------------------------------
	 * At Awake, assign the 'OnDemandProbe' game object to 
	 * 'probe', and the 'UpdateProbe' to the 'up' variable 
	 */
//	void Awake(){
//		// Asign the 'OnDemandProbe' game object to the 'probe' variable
//		probe = GameObject.Find("ReflectionProbe-onDemand");
//	
//		// Assign the 'UpdateProbe' component of the 'probe' object to the 'up' variable
//		updateProbe = probe.GetComponent<UpdateProbe>();
//	}
	
	/* ----------------------------------------
	 * During Update, detect if any key is pressed. If so, randomly rotate the game object this script is attached to.
	 * Also, call the external 'RefreshProbe' function
	 */
	void Update () {
		if (Input.anyKeyDown) {
			// IF any key is down, THEN assign the object's euler angles to a Vector3 variable named newRotation...
			Vector3 newRotation = transform.eulerAngles;

			// Set a random value between 0 and 360 as the newRotation.y
			newRotation.y = Random.Range(0F, 360F);
			
			// Update the object's euler angle with the values from newRotation (now including a random Y angle)
			transform.eulerAngles = newRotation; 
			
			// Call the external 'RefreshProbe' function
//			updateProbe.RefreshProbe();
		}
	}
}
