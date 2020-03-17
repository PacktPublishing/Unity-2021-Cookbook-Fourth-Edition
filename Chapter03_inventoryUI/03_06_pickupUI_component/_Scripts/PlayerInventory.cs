using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
	private int starTotal = 0;
	private PlayerInventoryDisplay playerInventoryDisplay;

	void Awake()
	{
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
	}

	void Start()
	{
		playerInventoryDisplay.OnChangeStarTotal(starTotal);
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag("Star"))
		{
			AddStar();
			Destroy(hit.gameObject);
		}
	}

	private void AddStar()
	{
		starTotal++;
		playerInventoryDisplay.OnChangeStarTotal(starTotal);
	}
}
