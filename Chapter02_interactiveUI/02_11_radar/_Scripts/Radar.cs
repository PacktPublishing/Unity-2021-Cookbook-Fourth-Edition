using UnityEngine;
using UnityEngine.UI;

/*
 * class to present to user a 'radar'
 * showing different images positioned to indicate
 * relative distance and orientation to the 'Player' GameObject
 */
public class Radar : MonoBehaviour
{
	// when objects are within this distance to the Player
	// then they are canidates for displaying as blips on our radar
	public float insideRadarDistance = 20;

	// percentage of radar size taken up by each 'blip' image
	public float blipSizePercentage = 5;

	// images to display as blips
	// one for each type of item to display in the radar
	public GameObject rawImageBlipCube;
	public GameObject rawImageBlipSphere;

	// image we'll show behind the blips
	private RawImage rawImageRadarBackground;

	// reference to the Player's tranform
	private Transform playerTransform;

	// the size of the background radar image
	private float radarWidth;
	private float radarHeight;

	// the size we WANT out blip to be on screen
	private float blipHeight;
	private float blipWidth;

	//----------------------------------------
	void Start()
	{
		// (1) caches a reference to the background circle radar Raw Image
        // so we can perform withd/height calcuations on it ...
		rawImageRadarBackground = GetComponent<RawImage>();

        // (2) caches a reference to the Transform component of the player's character
		// (the one tagged as Player).
		// This allows the scripted object to know about the position of the Player's character in each frame.
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		// (3) the width and height of the radar image are cached
		// so the relative positions for 'blips' can be calculated, based on the size of this background radar image.
		radarWidth = rawImageRadarBackground.rectTransform.rect.width;
		radarHeight = rawImageRadarBackground.rectTransform.rect.height;

		// (4) the size each blip should be (width and height) is calculated, using the blipSizePercentage public variable.
		blipHeight = radarHeight * blipSizePercentage / 100;
		blipWidth = radarWidth * blipSizePercentage / 100;
	}

	//----------------------------------------
	void Update()
	{
		// (1) call the RemoveAllBlips() method
		// which removes any old RawImage UI GameObjects of cubes and spheres that might currently be displayed.
		RemoveAllBlips();

		// (2) the FindAndDisplayBlipsForTag(...)method is called twice
		// First, for the objects tagged Cube, to be represented on the radar with prefab rawImageBlipCube
		// then again for objects tagged Sphere, to be represented on the radar with prefab rawImageBlipSphere.
		FindAndDisplayBlipsForTag("Cube", rawImageBlipCube);
		FindAndDisplayBlipsForTag("Sphere", rawImageBlipSphere);
	}



	//----------------------------------------
	// This method inputs two parameters:
	// the string 'tag' for the objects to the searched for
	// a reference to the RawImage prefab 'prefabBlip' to be displayed on the radar for any such tagged objects within the range.
	private void FindAndDisplayBlipsForTag(string tag, GameObject prefabBlip)
	{
		// the current position of the player's character is retrieved from the cached player transform variable.
		Vector3 playerPos = playerTransform.position;

		// an array is constructed, referring to all GameObjects in the scene that have the provided tag
		GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

		// This array of GameObjects is looped through, and for each GameObject, the following actions are performed:
		foreach (GameObject target in targets)
		{
			// The position of the target GameObject is retrieved
			Vector3 targetPos = target.transform.position;

			// The distance from this target position to the player's position is calculated
			float distanceToTarget = Vector3.Distance(targetPos, playerPos);

			// IF this distance is within the range (less than or equal to insideRadarDistance)
            if ((distanceToTarget <= insideRadarDistance)){
				CalculateBlipPositionAndDrawBlip(playerPos, targetPos, prefabBlip);
			}
        }
    }

    private void CalculateBlipPositionAndDrawBlip(Vector3 playerPos, Vector3 targetPos, GameObject prefabBlip)
    {
		// three steps are required to get the blip for this object to appear on the radar:

		// (a) The normalized position of the target is calculated by calling NormalisedPosition(...)
		Vector3 normalisedTargetPosition = NormalisedPosition(playerPos, targetPos);

		// (b) The position of the blip on the radar is then calculated from this normalized position
		// by calling CalculateBlipPosition(...)
		print(normalisedTargetPosition);
		Vector2 blipPosition = CalculateBlipPosition(normalisedTargetPosition);

		// (c) Finally, the RawImage blip is displayed by calling DrawBlip(...)
		// and passing the blip position and the reference to the RawImage prefab that is to be created there
		DrawBlip(blipPosition, prefabBlip);

	}

	//---------------------------------------
	// remove all GameObjects in the scene that are tagged 'Blip'
	private void RemoveAllBlips()
	{
		GameObject[] blips = GameObject.FindGameObjectsWithTag("Blip");
		foreach (GameObject blip in blips)
			Destroy(blip);
	}


	//---------------------------------------
	// The NormalisedPosition(...) method inputs the player's character position and the target GameObject position.
	//
	// It has the goal of outputting the relative position of the target to the player,
	// returning a Vector3 object with a triplet of X, Y, and Z values.
	//
	// Note that since the radar is only 2D, we ignore the Y-value of target GameObjects.
	// So, the Y-value of the Vector3 returned by this method will always be 0.
	// So, for example, if a target was at exactly the same location as the player,
	// the returned X, Y, Z Vector3 object would be (0, 0, 0).
	private Vector3 NormalisedPosition(Vector3 playerPos, Vector3 targetPos)
	{
		// Since we know that target GameObject is no further from the player's character than insideRadarDistance,
		// we can calculate a value in the -1 ... 0 ... +1 range for the X and Z
		float normalisedyTargetX = (targetPos.x - playerPos.x) / insideRadarDistance;
		float normalisedyTargetZ = (targetPos.z - playerPos.z) / insideRadarDistance;

		// construct and return a new Vector3 object, with the calculated X and Z normalized values, and a Y value of zero.
		return new Vector3(normalisedyTargetX, 0, normalisedyTargetZ);
	}


	//--------------------------------
	// 'targetPos' the (x,y,z) position of the target
	private Vector2 CalculateBlipPosition(Vector3 targetPos)
	{
		// First, we calculate angleToTarget: the angle from (0, 0, 0) to our normalized target position.
		// find angle from player to target
		float angleToTarget = Mathf.Atan2(targetPos.x, targetPos.z) * Mathf.Rad2Deg;

		// direction player facing
		// Next, we calculate anglePlayer: the angle the player's character is facing.
		// This recipe makes use of the yaw angle of the rotation, which is the rotation about the
		// that is, the direction that a character controller is facing.
		float anglePlayer = playerTransform.eulerAngles.y;

		// subtract player angle, to get relative angle to object
		// subtract 90
		// (so 0 degrees (same direction as player) is UP)
		float angleRadarDegrees = angleToTarget - anglePlayer - 90;

		// calculate (x,y) position given angle and distance
		float normalisedDistanceToTarget = targetPos.magnitude;

		// The angle is then converted into radians, since this is required for the Unity trigonometry methods.
		float angleRadians = angleRadarDegrees * Mathf.Deg2Rad;

		// We then multiply the Sin() and Cos() results by our normalized distances to calculate the X and Y
		float blipX = normalisedDistanceToTarget * Mathf.Cos(angleRadians);
		float blipY = normalisedDistanceToTarget * Mathf.Sin(angleRadians);

		// scale blip position according to radar size
		blipX *= radarWidth / 2;
		blipY *= radarHeight / 2;

		// offset blip position relative to radar center
		blipX += radarWidth / 2;
		blipY += radarHeight / 2;

		return new Vector2(blipX, blipY);
	}

	//----------------------------------------------
	// 'pos' the position (relative to radar screen) to draw the blip
	// (as a Vector2 X, Y pair)
	//
	// 'blipPrefab' reference to prefab of image/icon to display at this location
	private void DrawBlip(Vector2 pos, GameObject blipPrefab)
	{

		// A new GameObject is created from the prefab
		GameObject blipGO = (GameObject)Instantiate(blipPrefab);

		// and is parented to the radar GameObject (of which the scripted object is also a component)
		blipGO.transform.SetParent(transform.parent);

		//  A reference is retrieved to the Rect Transform of the new RawImage GameObject that has been created for the 'blip'
		RectTransform rt = blipGO.GetComponent<RectTransform>();

		//  Calls to the Unity RectTransform method SetInsetAndSizeFromParentEdge(...)
		// result in the blip GameObject being positioned at the provided horizontal and vertical locations over the radar image,
		// regardless of where in the Game panel the background radar image has been located.
		rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, pos.x, blipWidth);
		rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, pos.y, blipHeight);
	}
}