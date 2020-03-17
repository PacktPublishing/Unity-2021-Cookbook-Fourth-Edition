using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInventoryTotal))]
public class PlayerInventoryDisplayTotal : MonoBehaviour 
{
	// reference to a UI Text object
	// public - so we have to assign via the Inspector
	public Text starText;

	//------------------------------
	// update the text message on screen
	// to indicate how many stars we are carrying
	public void OnChangeStarTotal(int numStars)
	{
		// build our total message
		string starMessage = "total stars = " + numStars;

		// update UI text on screen with whatever is in our messsage string
		starText.text = starMessage;
	}
}