using UnityEngine;

/**
 * make parent GameObject rotate around the Worlds Y-axis each frame
 */
public class Orbit : MonoBehaviour
{
	private float speed = 20f;
	void Update () 
	{
		transform.Rotate(Vector3.up * Time.deltaTime * speed);
	}
}
