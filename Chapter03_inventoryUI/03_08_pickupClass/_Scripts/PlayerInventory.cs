using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
	// cached reference to instance object of class PlayerInventoryDisplay
	private PlayerInventoryDisplay playerInventoryDisplay;

	// a C# List of PickUp item objects
	// Lists are flexible array type data structures
	private List<PickUp> inventory = new List<PickUp>();

	//---------------------
	// get and store reference to PlayerInventoryDisplay object in parent GameObject
	void Awake()
	{
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
	}

	//---------------------
	// tell inventory dispay system to update display to
	// show user initial state of our 'inventory' List
	void Start()
	{
		playerInventoryDisplay.OnChangeInventory(inventory);
	}

	//----------------------
	// actions for when parent GameObject (Player) has hit a 2D collider inside another object
	void OnTriggerEnter2D(Collider2D hit)
	{
		// IF we hit something taqgged 'Pickup'
		if(hit.CompareTag("Pickup")){
			// THEN do the following:
			// - get reference to PickUp object inside the hit Gameobject
			PickUp item = hit.GetComponent<PickUp>();

			// add this PickUp item to our List 'inventory'
			inventory.Add( item );

			// update the display of inventory contents to the user UI
			playerInventoryDisplay.OnChangeInventory(inventory);

			// destroy the hit GameObject
			Destroy(hit.gameObject);
		}
	}
}
