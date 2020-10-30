using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class LoadMapFromTextfile : MonoBehaviour 
{
	// text file containing level data
	public TextAsset levelDataTextFile;
	
	// prefab for tiles
	public GameObject floor_848;	
	public GameObject corridor_849;	
	public GameObject horiz_1034;	
	public GameObject vert_1025;	
	public GameObject corpse_175;	
	public GameObject door_844;	
	public GameObject potion_675;	
	public GameObject chest_586;	
	public GameObject alter_583;	
	public GameObject stairs_up_994;	
	public GameObject stairs_down_993;	
	public GameObject wizard_287;	

	public Dictionary<char, GameObject> dictionary = new Dictionary<char, GameObject>();


	/*-------------------------------------------------------------
	 * calls methods to create each ROW of the scene
	 */
	void Awake()
	{
		// (1) declare a newline character variable
		char newlineChar = '\n';

		// (2) setup dictionary mapping characters to prefabs
		dictionary['.'] = floor_848;
		dictionary['#'] = corridor_849;	
		dictionary['('] = chest_586;
		dictionary['!'] = potion_675;
		dictionary['_'] = alter_583;
		dictionary['>'] = stairs_down_993;
		dictionary['<'] = stairs_up_994;
		dictionary['-'] = horiz_1034;
		dictionary['|'] = vert_1025;
		dictionary['+'] = door_844;
		dictionary['%'] = corpse_175;
		dictionary['@'] = wizard_287;

		// (3) read in and make array from level data		
    	string[] stringArray = levelDataTextFile.text.Split(newlineChar);

		// (4) call the method to build this maze
		BuildMaze( stringArray );
	}
	
	/*-------------------------------------------------------------
	 * create objects on screen as defined by this string array
	 */
	private void BuildMaze(string[] stringArray)
	{
		// count the number of rows in the string array
		int numRows = stringArray.Length;

		// now we know how many rows
		// we can calcualte the Z-offset
		float yOffset = (numRows / 2);
		
		// loop for each row of the array
		for(int row=0; row < numRows; row++){
			// extract the string for the current row
			string currentRowString = stringArray[row];
			
			// calculate the Y value for this row
			float y = -1 * (row - yOffset);

			// now call CreateRow for this string at this Y position
			CreateRow(currentRowString, y);
		}
	}
	
	/*-------------------------------------------------------------
	 * create a row of the scene given a string like "X..p...X"
	 */
	private void CreateRow(string currentRowString, float y)
	{
		// calculate X-offset based on Lenth of the string (numChars)
		int numChars = currentRowString.Length;
		float xOffset = (numChars/2);
	
		// loop for each character in the row string
		for(int charPos = 0; charPos < numChars; charPos++){
			float x = (charPos - xOffset);

			char prefabCharacter = currentRowString[charPos];

			// if char found in dictionary, create corresponding prefab at (x,y)
			if (dictionary.ContainsKey(prefabCharacter)){
				CreatePrefabInstance( dictionary[prefabCharacter], x, y);
			}
		}
	}

	/*-------------------------------------------------------------
	 *  create instance of given Prefab at position (x, 1, z)
	 */
	private void CreatePrefabInstance(GameObject objectPrefab, float x, float y)
	{
		// all objects are to be created at Y = 1
		float z = 0;
	
		// create new position Vector
		Vector3 position = new Vector3(x, y, z);
		
		// create no rotation Quaternion
		Quaternion noRotation = Quaternion.identity;
		
		// create Prefab instance
		Instantiate (objectPrefab, position, noRotation);
	}
}

