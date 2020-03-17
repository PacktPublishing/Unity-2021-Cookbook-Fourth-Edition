using UnityEngine;

/**
 * value of 'type' must be one of the 3 PickUpTypes
 */
public class PickUp : MonoBehaviour
{
	public enum PickUpType
	{
		Star, Key, Heart
	}

	public PickUpType type;
}
