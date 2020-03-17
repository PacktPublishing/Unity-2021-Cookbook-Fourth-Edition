using UnityEngine;

[RequireComponent(typeof(PlayerInventoryKeys))]
public class PlayerInventoryDisplayKeys : MonoBehaviour
{
	public PickupUI[] slotsStars = new PickupUI[1];
	public PickupUI[] slotsKeys = new PickupUI[1];

	public void OnChangeStarTotal(int starTotal)
	{
		int numInventorySlots = slotsStars.Length;
		for (int i = 0; i < numInventorySlots; i++)
		{
			PickupUI slot = slotsStars[i];
			if (i < starTotal)
				slot.DisplayColorIcon();
			else
				slot.DisplayGreyIcon();
		}
	}

	public void OnChangeKeyTotal(int keyTotal)
	{
		int numInventorySlots = slotsKeys.Length;
		for (int i = 0; i < numInventorySlots; i++)
		{
			PickupUI slot = slotsKeys[i];
			if (i < keyTotal)
				slot.DisplayColorIcon();
			else
				slot.DisplayGreyIcon();
		}
	}
}
