using UnityEngine;

/* ----------------------------------------
 * class to demonstrate how to use a Line Renderer
 * and a Projector to create a Laser Aim effect
 */ 
public class LaserBeam : MonoBehaviour 
{
	// float variable for the laser line width
	public float lineWidth = 0.2f;

	// the color of the line whenever the weapon is NOT being fired.
	public Color regularColor = new Color (0.15f, 0, 0, 1);
	
	// Material to be applied on the line renderer for the laser
	public Material beamMaterial;
	
	// Vector 3 variable for the position where the line ends 
	private Vector3 lineEnd;
	
	// Variable for the Line Renderer component
	private LineRenderer line;

	/* ----------------------------------------
 	* At Start, set up effects components (Line Renderer and Projector)
 	*/ 
	void Start () 
	{
		// Add Line Renderer component
		line = gameObject.AddComponent<LineRenderer>();
		
		// Set the Material for the Line Renderer
		line.material = beamMaterial;
		
		// Set initial color for the Line Renderer's material
		line.material.SetColor("_TintColor", regularColor);
		
		// Set number of vertices 
		line.SetVertexCount(2);
		
		// Set Line Renderer's width at each vertex
		line.SetWidth(lineWidth, lineWidth);
	}
	
	/* ----------------------------------------
	 * During Update, adjust the range of the line and projector to the object being aimed at.
	 * Also, animate the Line's color if the Fire button is pressed. We will do that by interpolating between 'regularColor' and 'firingColor',
	 * making it look as if pulsing
	 */
	void Update () 
	{
		// Create RaycastHit variable to detect if the projector is aiming at any object's collider
		RaycastHit hit; 
		
		// Create 3D Vector for keeping the projector's forward direction 
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		
		if (Physics.Raycast (transform.position, forward, out hit))
			lineEnd =  hit.point;
		else
			// IF Ray cast from projector to its forward direction DOES NOT hit something, THEN place the Line's end at an arbitrary distance in the projector's forward direction
			lineEnd = transform.position + forward * 10f;
		
		// Set the position of the Line's initial vertex at the projector's origin
		line.SetPosition(0, transform.position);
		
		// Set the position of the Line's final vertex at the point stored at the lineEnd vector
		line.SetPosition(1, lineEnd);
	}

}
