using UnityEngine;

/* ----------------------------------------
 * class to demonstrate how to access ChangePitch component 
 * from a different game object
 */ 
public class ExternalChangePitch : MonoBehaviour 
{

	// A variable for referencing the external ChangePitch component
	public ChangePitch changePitchScripedComponent;

	/* ----------------------------------------
	 * Whenever UP or DOWN buttons are clicked, 
	 * call AccelerateRocket() from external ChangePitch component to readjust speed 
	 */
	void Update () 
    {
        if (Input.GetKey(KeyCode.UpArrow))
			// IF the left button of the mouse is clicked, THEN call AccelRocket to increase speed 
            changePitchScripedComponent.AccelerateRocket(changePitchScripedComponent.acceleration);
		
        if (Input.GetKey(KeyCode.DownArrow))
			// IF the right button of the mouse is clicked, THEN call AccelRocket to decrease speed 
            changePitchScripedComponent.AccelerateRocket(-changePitchScripedComponent.acceleration);
	}
}
