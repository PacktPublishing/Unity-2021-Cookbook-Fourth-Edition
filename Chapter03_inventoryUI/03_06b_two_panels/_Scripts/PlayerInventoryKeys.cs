using UnityEngine;

public class PlayerInventoryKeys : MonoBehaviour
{
	private int starTotal = 0;
	private int keyTotal = 0;

	private PlayerInventoryDisplayKeys playerInventoryDisplay;

	void Awake()
	{
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplayKeys>();
	}

	void Start()
	{
		playerInventoryDisplay.OnChangeStarTotal(starTotal);
		playerInventoryDisplay.OnChangeKeyTotal(keyTotal);
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag("Star"))
		{
			AddStar();
			Destroy(hit.gameObject);
		}

		if (hit.CompareTag("Key"))
		{
			AddKey();
			Destroy(hit.gameObject);
		}
	}

	private void AddStar()
	{
		starTotal++;
		playerInventoryDisplay.OnChangeStarTotal(starTotal);
	}

	private void AddKey()
	{
		keyTotal++;
		playerInventoryDisplay.OnChangeKeyTotal(keyTotal);
	}
}
