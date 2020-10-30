using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GridGizmo))]
public class EditorGridGizmo : Editor
{
	private GridGizmo gridGizmoObject;
	private int grid;
	private Color gridColor;
	private int numLines;
	private int lineLength;
	
	private string[] gridSizes = {
		"1", "2", "3", "4", "5"
	};
	
	void OnEnable()
	{
		gridGizmoObject = (GridGizmo)target;
		grid = serializedObject.FindProperty("grid").intValue;
		gridColor = serializedObject.FindProperty("gridColor").colorValue;
		numLines = serializedObject.FindProperty("numLines").intValue;
		lineLength = serializedObject.FindProperty("lineLength").intValue;
	}
		
	public override void OnInspectorGUI()
	{
		serializedObject.Update ();
		
		// Grid size dropdown
		int gridIndex = grid - 1;
		gridIndex =  EditorGUILayout.Popup("Grid size:",  gridIndex, gridSizes);
		
		// grid color picker
		gridColor = EditorGUILayout.ColorField("Color:", gridColor);

		// num lines in grid
		numLines =  EditorGUILayout.IntField("Number of grid lines",  numLines);

		// grid line length
		lineLength =  EditorGUILayout.IntField("Length of grid lines",  lineLength);

		// update new values
		grid = gridIndex + 1;
		gridGizmoObject.SetGrid(grid);	
		gridGizmoObject.gridColor = gridColor;
		gridGizmoObject.numLines = numLines;	
		gridGizmoObject.lineLength = lineLength;	
		serializedObject.ApplyModifiedProperties ();
		
		// force OnDrawGizmos call to GameObjects in Scene
		SceneView.RepaintAll();
	}

}