using UnityEngine;
using UnityEngine.Audio;

/* ----------------------------------------
 * class to demonstrate how to change the sound volume of Audio Mixers through GUI and script.
 * This script should be attached to the GUI game object.
 */ 
public class VolumeControl : MonoBehaviour
{
    // reference to UI Panel
    public GameObject panel;

    // reference to Audio Mixer
	public AudioMixer myMixer;

	//  whether the game is paused or not;
	private bool isPaused = false;

	/* ----------------------------------------
	 * initialise Panel to being inactive.
	 */ 
	void Start()
	{
		// Set 'panel' as inactive, hiding the volume control sliders
        panel.SetActive(false);

        ON_CHANGE_OverallVol(0.01F);
        ON_CHANGE_MusicVol(0.01F);
        ON_CHANGE_FxVol(0.01F);
	}

	/* ----------------------------------------
	 * Whenever the Escape key is pressed, 
	 * enable/disable the GUI panel and pause/unpause the game 
	 */
	void Update()
	{
		if (Input.GetKeyUp (KeyCode.Escape)) {
			// IF the Escape key is hit, THEN invert active/inactive status for the GUI Panel
			panel.SetActive(!panel.activeInHierarchy);

			if(isPaused)
				// IF game is paused, THEN set time scale as 1, to unpause it
				Time.timeScale = 1.0f;
			else
				// ELSE, if game is not paused, THEN set time scale as 0, to pause it
				Time.timeScale = 0.0f;

			// Update isPaused boolean by inverting its value 
			isPaused = !isPaused;
		}		
	}	


    /* ----------------------------------------
     * A function for changing the Overall Volume 
     * The function receives a float value as the new volume level
     */
    public void ON_CHANGE_OverallVol(float vol)
    {
        // Assigns to the exposed parameter 'OverallVolume' a new volume level, converted from linear to decibels
        myMixer.SetFloat("OverallVolume", Mathf.Log10(vol) * 20f);
    }

	/* ----------------------------------------
	 * A function for changing the Volume of the music
	 * The function receives a float value as the new volume level
	 */
	public void ON_CHANGE_MusicVol(float vol)
	{
        // Assigns to the exposed parameter 'MusicVolume' a new volume level, converted from linear to decibels
		myMixer.SetFloat ("MusicVolume", Mathf.Log10(vol) * 20f);
	}

	/* ----------------------------------------
	 * A function for changing the Volume of sound effects
	 * The function receives a float value as the new volume level
	 */
	public void ON_CHANGE_FxVol(float vol)
	{
        // Assigns to the exposed parameter 'FxVolume' a new volume level, converted from linear to decibels
		myMixer.SetFloat ("FxVolume", Mathf.Log10(vol) * 20f);
	}

}

