using UnityEngine;
using System.Collections;

// import UI pacakge so we can use the Text claass
using UnityEngine.UI;

//import System so we can use DateTime class
using System;

/*
 * class to display a digital clock in the form: 11:23:22 - hours:minutes:seconds
 */
public class ClockDigital : MonoBehaviour {
	// reference to the UI Text object that we'll use to display the time
	private Text textClock;

	//------------------------
	void Start()
	{
		// cache a reference to the Text component
		// that is in the same GameObject to which an instance of this script has been addeedd
		textClock = GetComponent<Text>();
	}

	//------------------------
	void Update ()
	{
		// get current time
		DateTime time = DateTime.Now;

		// extract hour / minutes / seconds
		string hour = LeadingZero( time.Hour );
		string minute = LeadingZero( time.Minute );
		string second = LeadingZero( time.Second );

		// build String containing the time, and assign this to 'text' property of the Text component of our parent GameObject
		textClock.text = hour + ":" + minute + ":" +  second;
	}
	
	
	/**
	* given an integer, return a 2-character string
	* adding a leading zero if required
	*/
	string LeadingZero(int n)
	{
		return n.ToString().PadLeft(2, '0');
	}
}
