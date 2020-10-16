using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to update rotate a Directional Light 
 * via scripting, affecting a procedural skybox  at runtime. This script 
 * should be attached to the Directional Light in the scene
 */ 
public class RotateLight : MonoBehaviour {
	// Float variable for the speed of the rotation
	public float speed = -1.0f;

	/* ----------------------------------------
	 * During Update, rotate this object around its X axis
	 */
	void Update () {
		//Rotate object around its X axis 
		transform.Rotate(Vector3.right * speed * Time.deltaTime);
	}
}
