using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * class to manage an inventory being carried by player
 * uses a C# Dictionary - key-value pairs
 * where the key is one of the enumerated PickUpTypes
 * and the value is the integer total of how many of that type are being carried
 */
public class InventoryManager : MonoBehaviour
{
	// reference to instance object of PlayerInventoryDisplay
	private PlayerInventoryDisplay playerInventoryDisplay;

	// our inventory Dictionary 'items'
	// e.g. if we are carrying 1 star and 2 hearts then our Dictionary would look as follows:
	// items[Star] = 1
	// items[Heart] = 2
	private Dictionary<PickUp.PickUpType, int> items = new Dictionary<PickUp.PickUpType, int>();

	//-----------------------
	// cache reference to PlayerInventoryDisplay in parent GameObject
	void Awake()
	{
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
	}

	//-----------------------
	// send message to this display object to update the user display for current contents of 'items'
	void Start()
	{
		playerInventoryDisplay.OnChangeInventory(items);
	}

	//--------------------
	// add given 'pickup' objects to our Dictionary
	public void Add(PickUp pickup)
	{
		// get the type of this pickup object
		PickUp.PickUpType type = pickup.type;

		// init total to zerpo
		int oldTotal = 0;

		// IF we can find this type in the Dictionary
		// then set 'oldTotal' to the associated value
		if(items.TryGetValue(type, out oldTotal))
			// add 1 to existing total (since we just picked one up)
			items[type] = oldTotal + 1;
		else
			// if we could not find the type key in the Dictionary
			// then add new item, with total 1 (since we just picked one up)
			items.Add (type, 1);

		// tell the display object to update the UI display with the new totals in 'items' Dictionary
		playerInventoryDisplay.OnChangeInventory(items);
	}
}
