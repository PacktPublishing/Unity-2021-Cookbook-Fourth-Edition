using UnityEngine;

public class GizmoHighlightSelected : MonoBehaviour 
{
	public float radius = 5.0f;
        
	void OnDrawGizmosSelected()
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radius - 0.1f);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, radius - 0.2f);
	}
}
