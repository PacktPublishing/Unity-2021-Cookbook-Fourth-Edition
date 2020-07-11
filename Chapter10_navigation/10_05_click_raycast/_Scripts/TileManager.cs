using UnityEngine;

public class TileManager : MonoBehaviour
{
	public int rows = 50;
	public int cols = 50;
	public GameObject prefabClickableTile;
	
	void Start () 
	{
		for (int r = 0; r < rows; r++)
		{
			for (int c = 0; c < cols; c++)
			{
				// just _above_ the terrain
				float y = 0.01f;
				
				// center at (0, y, 0)
				Vector3 pos = new Vector3(r - rows/2, y, c - cols/2);
				Instantiate(prefabClickableTile, pos, Quaternion.identity);
			}
		}
		
	}
}
