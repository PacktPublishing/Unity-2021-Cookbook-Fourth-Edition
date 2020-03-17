using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(InventoryManager))]
public class PlayerInventoryDisplay : MonoBehaviour
{
	// reference to UI text object
	public Text inventoryText;

	//-----------------------------
	// when inventory Dictionary changes, let's update the display
	// input param is 'inventory' Dictionary
	public void OnChangeInventory(Dictionary<PickUp.PickUpType, int> inventory)
	{
		// reset UI text to empty string
		inventoryText.text = "";

		// set out text inventory to this word
		string newInventoryText = "carrying: ";

		// loop for each item in Dictionary
		foreach (var item in inventory)
		{
			// get number of this item
			int itemTotal = item.Value;

			// create string description with name of 'key' (inventory type)
			string description = item.Key.ToString();

			// add to inventory summary text name of item and how many being carried
			newInventoryText += " [ " + description + " " + itemTotal + " ]";
		}

		// get the number of items in 'inventory' Dictionary
		int numItems = inventory.Count;

		// if num items is ZERO then set text to say inventory is empty
		if (numItems < 1)
			newInventoryText = "(empty inventory)";

		// update UI display to our text inventory summer
		inventoryText.text = newInventoryText;
	}
}
