using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerInventoryDisplay : MonoBehaviour 
{
	// reference to a UI image GameObject on screen
	public Image imageStarGO;

	// reference to image of icon indicating player is NOT carrying a star
	public Sprite iconNoStar;

	// reference to image of icon indicating player IS carrying a star
	public Sprite iconStar;

	//----------------------------
	// if we are carrying star display image 'iconStar'
	// else display image 'iconNoStar'
	public void OnChangeCarryingStar(bool carryingStar)
    {
        if (carryingStar)
            imageStarGO.sprite = iconStar;
        else
            imageStarGO.sprite = iconNoStar;
    }
}
