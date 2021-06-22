using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGizmo : MonoBehaviour
{
    public int grid = 2;

	public void SetGrid(int grid)
	{
		this.grid = grid;
		SnapAllChildren();
	}

	public Color gridColor = Color.red;

    public int numLines = 6;

    public int lineLength = 50;


	private void SnapAllChildren()
	{
		// snap all childre to new grid value
		foreach (Transform child in transform)
            SnapPositionToGrid(child);
	}
 
	// draw the grid :) 
	void OnDrawGizmos()
	{
		Gizmos.color = gridColor;

		int min = -lineLength;
		int max = lineLength;

		// draw the horizontal lines
		int n = -1 * RoundForGrid(numLines / 2);
		for (int i = 0; i < numLines; i++)
		{
			// X lines
			Vector3 start = new Vector3(min, n, 0);
			Vector3 end = new Vector3(max, n, 0); 
			Gizmos.DrawLine(start, end);

			// Y lines
			start = new Vector3(n, min, 0);
			end = new Vector3(n, max, 0); 
			Gizmos.DrawLine(start, end);

			n += grid;
		}
	}

	/**
	 * int param
	 * return 'n' rounded for grid
	 */
	public int RoundForGrid(int n)
	{
		return (n/ grid) * grid;
	}
	
	/**
	 * float param
	 * return 'n' rounded for grid
	 */
	public int RoundForGrid(float n)
	{
		int posInt = (int) (n / grid);
		return posInt * grid;
	}
	
	/**
	* snap position to grid
	*/
	public void SnapPositionToGrid(Transform transform)
	{
		transform.position = new Vector3 (
			RoundForGrid(transform.position.x),
			RoundForGrid(transform.position.y),
			RoundForGrid(transform.position.z)
		);
	}

	
}
