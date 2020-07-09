using UnityEngine;

public class UsefulFunctions : MonoBehaviour{
	public static void DebugRay(Vector3 origin, Vector3 destination, Color c) {
		Vector3 direction = destination - origin;
		Debug.DrawRay(origin, direction, c);
	}	

	public static Vector3 ClampMagnitude(Vector3 v, float max) {
		if (v.magnitude > max)
			return v.normalized * max;
		else
			return v;
	}
}
