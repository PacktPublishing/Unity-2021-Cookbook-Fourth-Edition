using UnityEngine;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to fade a material upon mouse click
 */ 
public class FadeObject: MonoBehaviour 
{
	// Time for fade duration, in seconds
	public float fadeDurationSeconds = 1.0f;
	
	// Alpha value at start (if not using the material's original alpha value)
	public float alphaStart = 1.0f;
	
	// Alpha value at the end of the fade transition
	public float alphaEnd = 0.0f;

	// float value for transition's starting time
	private float startTime;
	
	// variable for storing the object's meshRenderer component
	private MeshRenderer meshRenderer;
	
	// variable for calculating the color of the material, including its alpha value
	private Color fadeColor;
	
	// boolean variable for activating/deactivating fade
	private bool isFading = false;

	/* ----------------------------------------
	 * At Start, adjust object's material to desired alpha value, and also 
	 * calculate difference between initial and final alpha values
	 */
	void Start () 
	{
		// store reference to object's meshRenderer component into 'meshRenderer' variable
		meshRenderer = GetComponent<MeshRenderer>();
	
		// set object material's original color as fadeColor
		fadeColor = meshRenderer.material.color;
		
		// start object's alpha at our alphaStart value
		UpdateMaterialAlpha(alphaStart);
	}
	
	/* ----------------------------------------
	 * If "F" key pressed - start fading
	 */
	void Update()
	{
		if (isFading)
		{
			FadeAlpha();
		}
	}

	/* ----------------------------------------
	 * If object clicked on with mouse - start fading
	  */	
	void OnMouseUp()
	{
		StartFading();
	}

	/*
	 * actions for when we want to begin fading
	 */
	private void StartFading()
	{
		// store current time as the time fading started
		startTime = Time.time;
		
		// set flag to say we are now fading
		isFading = true;
	}

	/*
	 * calculate current proportion of fading
	 * use Lerp() to calculate new alpha value (from alphaStart ... alphaEnd)
	 * update Material's alpha
	 *
	 * finaly, test whether fading is now complete  (fadePercentage >= 1)
	 */
	private void FadeAlpha()
	{
		float timeFading = Time.time - startTime;
		float fadePercentage = timeFading / fadeDurationSeconds;
		float alpha = Mathf.Lerp(alphaStart, alphaEnd, fadePercentage);
		UpdateMaterialAlpha(alpha);

		if (fadePercentage >= 1)
			isFading = false;
	}

	/*
	 * update the apha value of the GameObject's Color object with the given value
	 */
	private void UpdateMaterialAlpha(float newAlpha)
	{
		fadeColor.a = newAlpha;
		meshRenderer.material.color = fadeColor;		
	}
}
