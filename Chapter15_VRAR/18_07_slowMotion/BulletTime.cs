using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to implement
 * bullet time effect 
 */ 
public class BulletTime : MonoBehaviour
{
	// float variable for slow motion speed (default is 0.1, which is equal to 1/10 of game's regular speed)
	public float sloSpeed = 0.1f;

	// float variable for how many seconds of bullet time player has at start 
	public float totalTime = 10f;

	// float variable for how fast the energy bar recovers when bullet effect time is not in use
	public float recoveryRate = 0.5f;

	// The Slider to be used as energy bar 
	public Slider EnergyBar;

	// How many seconds the player has spent using the bullet time effect
	private float elapsed = 0f;

	// boolean variable for indicating if the effect is in use
	private bool isSlow = false;

	/* ----------------------------------------
	 * Whenever the mouse is right click, activate bullet time. Deactive it when button is released or  
	 * the player runs out of this resource
	 */
	void Update ()
	{

		if (Input.GetButtonDown ("Fire2") && elapsed < totalTime)
			// IF Fire2 button is pressed down and player hasn't run out of time, THEN pass slow motion speed to SetSpeed function
			SetSpeed (sloSpeed);
		
		if (Input.GetButtonUp ("Fire2"))
			// IF Fire2 button is released, THEN pass regular speed (1f) to SetSpeed function, ending effect. 
			SetSpeed (1f);
		
		if (isSlow) {
			// IF Bullet Time effect is in use, THEN add passing time to the amount the player has used
			elapsed += Time.deltaTime / sloSpeed;

			if (elapsed >= totalTime)
				//IF elapsed time equals or exceeds total time, THEN pass regular speed (1f) to SetSpeed function, ending effect. 
				SetSpeed (1f);
			
		} else {
			// ELSE, if bullet time is not in use, subtract passing time (multiplied by recovery rate) from the amount player has used, allowing for more time.
			elapsed -= Time.deltaTime * recoveryRate;
			// Constrain elapsed time between 0 and total allowed time
			elapsed = Mathf.Clamp (elapsed, 0, totalTime);
		}

		// float variable for ratio between remaining effect time and total allowed time
		float remainingTime = (totalTime - elapsed) / totalTime;

		// Set Slider position to represent amount of bullet time effect left
		EnergyBar.value = remainingTime;
	}

	/* ----------------------------------------
	 * A function to set the game speed that receives
	 * a float argument for the time scale (1.0f being regular speed)
	 */
	private void SetSpeed (float speed)
	{
		// Set time scale as 1.0 (regular speed) or sloSpeed (slow motion)
		Time.timeScale = speed;

		// set fixed delta time as 0.02 * time scale, avoiding problems with physics during bullet time
		Time.fixedDeltaTime = 0.02f * speed;

        // set isSlow variable according to timeScale: true if not equal or greater than 1.0f, false if less than 1.0f
        isSlow = !(speed >= 1.0f);	
	}
}
