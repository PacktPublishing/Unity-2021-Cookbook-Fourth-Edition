using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerInventoryDisplay : MonoBehaviour
{
	// reference to a UI image
	// public - so set in Inspector
	// tiled, so each 100px width it is, will show that many stars
	public Image iconStarsYellow;

	//------------------------------
	public void OnChangeStarTotal(int starTotal)
	{
		// given number of stars, multiple by 100
		// to get width we need for Image 'iconStarsYellow' to show that number of stars
		float newWidth = 100 * starTotal;

		// now resize image given new width
		// - we are changing the image size alng the Horizontal axis
		iconStarsYellow.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
	}
}
