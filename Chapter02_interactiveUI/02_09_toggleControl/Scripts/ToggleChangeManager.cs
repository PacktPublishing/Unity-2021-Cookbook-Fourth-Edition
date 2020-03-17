using UnityEngine;
using UnityEngine.UI;

public class ToggleChangeManager : MonoBehaviour
{
	// reference to UI toggle
	private Toggle toggle;

	//-----------------------------------------
	// get reference to the Toggle component
	// in the parent GameObject to which this script instance has been attached
	void Awake ()
	{
		toggle = GetComponent<Toggle>();	
	}

	//-----------------------------------------
	// display to Console window the true/false status
	// of the current state of the Toggle component
	//
	// this will be called each time the Toggle receives an OnValueChanged interaction event
	public void PrintNewToggleValue()
	{
		bool status = toggle.isOn;
		print ("toggle status = " + status);
	}

}
