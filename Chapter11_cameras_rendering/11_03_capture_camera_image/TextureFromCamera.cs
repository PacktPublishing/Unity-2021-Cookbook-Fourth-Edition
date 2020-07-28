using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to take snapshots
 * of the screen and use it as a UI texture
 */ 

public class TextureFromCamera : MonoBehaviour 
{
	public GameObject rawImagePhoto;
	public GameObject imageFrame;
	
	// Float variable for the ratio between size of the snapshot and displayed texture 
	public float ratio = 0.25f;

	/* ----------------------------------------
	 * IF mouse button clicked
	 * THEN
	 * 	- hide Raw Image
	 *  - capture screen within frame
	 *  - show Raw Image
	 */
	void  LateUpdate ()
	{
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			// Disable UI element for the last snapshot taken (otherwise it will be superposed to the next snapshot)
			rawImagePhoto.SetActive (false);

			// IF the left mouse button was pressed, THEN start the CaptureScreen coroutine
			StartCoroutine(CaptureScreen());
			
			// Re-activate UI element for displaying snapshot
			rawImagePhoto.SetActive (true);
		}
	}

	/* ----------------------------------------
	 * A function to calculate the dimension and location of the snapshot,
	 * capture it and apply it to its respective UI element
	 */
	IEnumerator CaptureScreen ()
	{
		// A shorthand for the Rect Transform settings of the UI element for the framing 
		RectTransform frameTransform = imageFrame.GetComponent<RectTransform> ();

		// Rect for the snapshot area, initially based on the UI frame's the Rect Transform 
		Rect framing = frameTransform.rect;

		// A shorthand for the coordinates of the UI frame's pivot
		Vector2 pivot = frameTransform.pivot;
		
		// A 2D vector for the Anchor Min (defines horizontal and vertical origin of the frame)
		Vector2 origin = frameTransform.anchorMin;

		// Convert X coordinate of origin point to pixels by multiplying it by screen's width
		origin.x *= Screen.width;

		// Convert Y coordinate of origin point to pixels by multiplying it by screen's height
		origin.y *= Screen.height;

		// float var for horizontal offset of the frame, obtained by multiplying horizontal pivot point by frame width
		float xOffset = pivot.x * framing.width;

		// Add horizontal offset to frame horizontal origin
		origin.x += xOffset;

		// float var for vertical offset of the frame, obtained by multiplying vertical pivot point by frame height
		float yOffset = pivot.y * framing.height;

		// Add vertical offset to frame vertical origin
		origin.y += yOffset;

		// Offset framing horizontal location 
		framing.x += origin.x;

		// Offset framing vertical location 
		framing.y += origin.y;

		// Create a new Texture measuring textWidth x textHeight
		Texture2D texture = new Texture2D((int)framing.width, (int)framing.height);	

		// Wait for the EndOfFrame before capturing snapshot
		yield return new WaitForEndOfFrame();

		//Read Pixels from screen 
		texture.ReadPixels(framing, 0, 0);

		// Apply captured pixels onto texture
		texture.Apply();

		// 3D Vector for the new snapshot dimension (based on framing dimension multplied by selected ratio)
		Vector3 photoScale = new Vector3 (framing.width * ratio, framing.height * ratio, 1);

		// Resize UI texture display to specified dimensions
		rawImagePhoto.GetComponent<RectTransform> ().localScale = photoScale;

		// Set captured texture as UI display's texture  
		rawImagePhoto.GetComponent<RawImage>().texture = texture;
	}
}