using UnityEngine;

public class Player : MonoBehaviour
{
	private InventoryManager inventoryManager;

    // get reference to InventoryManager sibling component
	void Awake()
	{
		inventoryManager = GetComponent<InventoryManager>();
	}

    //----------------------
	// actions for when parent GameObject (Player) has hit a 2D collider inside another object
	void OnTriggerEnter2D(Collider2D hit)
	{
		// IF we hit something taqgged 'Pickup'
		if(hit.CompareTag("Pickup")){
            // THEN do the following:
            // - get reference to PickUp object inside the hit Gameobject
            PickUp item = hit.GetComponent<PickUp> ();

			// add this PickUp item to our List 'inventory'
			inventoryManager.Add(item);

			// destroy the hit GameObject
			Destroy(hit.gameObject);
		}
	}
}
