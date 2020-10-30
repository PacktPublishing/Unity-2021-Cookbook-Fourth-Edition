using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to pause a game
 * and change quality settings 
 */ 
public class PauseGame : MonoBehaviour 
{
	// Boolean variable that informs script if game should be paused or not, false by default.
	private bool isPaused = false;

	private QualityChooser qualityChooser;

	/* ----------------------------------------
	 * At Start, make mouse cursor invisible, adjust UI Slider settings 
	 * and set UI Panel inactive.
	 */ 	
	void Start ()
	{
		qualityChooser = GetComponent<QualityChooser>();
	}

	/* ----------------------------------------
	 * Whenever 'ESC' key is pressed, toggle 'isPaused' boolean 
	 * and call SetPause() to pause/resume game 
	 */
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// IF 'Esc' key is pressed, THEN invert boolean 'isPaused'
			isPaused = !isPaused;
			//... and call SetPause() function
			SetPause ();
		}
	}

	/* ----------------------------------------
	 * A function to pause/resume the game   
	 */
	private void SetPause()
	{
		// Invert 'isPaused' boolean and convert it into a float variable, being true = 1; and false = 0f.  
		float timeScale = !isPaused ? 1f : 0f;

		// Set the Time Scale as 1(game runs normally) or 0(game pauses)
		Time.timeScale = timeScale;

		// Enable/Disable mouse movement of First Person Controller from our example scene.
		GetComponent<MouseLook> ().enabled = !isPaused;

		// show/hide pointer and slider based on value of isPaused flag
		qualityChooser.SetQualitySliderActive(isPaused);
	}

}
