using UnityEngine;
using UnityEngine.UI;

public class RadioButtonManager : MonoBehaviour 
{
    // default to this value
	private string currentDifficulty = "Easy";

	public void PrintNewGroupValue(Toggle sender)
    {
		// only take notice from Toggle just swtiched to On
		if(sender.isOn)
        {
            // retreive the text Tag of the sender GameObject
            // which should match is visual label!
			currentDifficulty = sender.tag;

            // output details of new value to Console
			print ("option changed to = " + currentDifficulty);
		}
	}
}
