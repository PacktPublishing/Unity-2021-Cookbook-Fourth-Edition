using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorGridGizmoMenuItem : Editor
{
	/**
	 * menu item to create a GridSnapper
	 */
	[MenuItem("GameObject/Create New Snapgrid", false, 10000)]
	static void CreateCustomEmptyGameObject(MenuCommand menuCommand)
	{
		GameObject gameObject = new GameObject("___snap-to-grid___");
		
		// ensure not a child of any other object
		gameObject.transform.parent = null;
		
		// zero position
		gameObject.transform.position = Vector3.zero;

		// add Scripted component
		gameObject.AddComponent<GridGizmo>();

	}

}