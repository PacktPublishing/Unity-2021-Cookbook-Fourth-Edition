using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour
{
	public PickupUI[] slots = new PickupUI[1];

	public void OnChangeStarTotal(int starTotal)
	{
		int numInventorySlots = slots.Length;
		for (int i = 0; i < numInventorySlots; i++)
		{
			PickupUI slot = slots[i];
			if (i < starTotal)
				slot.DisplayColorIcon();
			else
				slot.DisplayGreyIcon();
		}
	}
}
