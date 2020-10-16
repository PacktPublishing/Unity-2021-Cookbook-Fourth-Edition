using UnityEngine;

/* ----------------------------------------
 * class to demonstrate how to update Reflection Probes 
 * via scripting
 */ 
public class UpdateProbe : MonoBehaviour 
{
	// reference to ReflectionProbe component 
	private ReflectionProbe probe;

	/* ----------------------------------------
	 * At Awake, assign ReflectionProbe component to 
	 * probe' variable and update cubemap
	 */
	void Awake () 
	{
		// cache reference to ReflectionProbe component
		probe = GetComponent<ReflectionProbe> ();
		
		// refresh reflection cubemap
		RefreshProbe();
	}

	/* ----------------------------------------
	 * update the reflection cubemap
	 * - public to can be invoked from another scripted object ...
	 */
	public void RefreshProbe()
	{
		// Use RenderProbe function to update reflection cubemap
		probe.RenderProbe();
	}
}
