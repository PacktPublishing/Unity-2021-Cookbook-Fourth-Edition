using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
	/*-------------------------------------------
	 * load scores from Player static variables
	 * and display on screen in sibling UI Text component
	 */

    /*
	void Start()
	{
		Text scoreText = GetComponent<Text>();
		int totalAttempts = Player.scoreCorrect + Player.scoreIncorrect;
		string scoreMessage = "Score = ";
		scoreMessage += Player.scoreCorrect + " / " + totalAttempts;

		scoreText.text = scoreMessage;
	}
	*/

    // version 2 - hide score (empty string) if no attempts yet
    void Start()
    {
        Text scoreText = GetComponent<Text>();
        int totalAttempts = Player.scoreCorrect + Player.scoreIncorrect;

        // default is empty string
        string scoreMessage = "";
        if (totalAttempts > 0)
        {
            scoreMessage = "Score = ";
            scoreMessage += Player.scoreCorrect + " / " + totalAttempts;
        }

        scoreText.text = scoreMessage;
    }
}