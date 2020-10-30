using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
	/*-------------------------------------------
	 * load scores from Player Prefs variables
	 * and display on screen in sibling UI Text component
	 */
    void Start()
    {
        Text scoreText = GetComponent<Text>();

        int scoreCorrect = PlayerPrefs.GetInt("scoreCorrect");
        int scoreIncorrect = PlayerPrefs.GetInt("scoreIncorrect");

        int totalAttempts = scoreCorrect + scoreIncorrect;

        // default is empty string
        string scoreMessage = "";
        if (totalAttempts > 0)
        {
            scoreMessage = "Score = ";
            scoreMessage += scoreCorrect + " / " + totalAttempts;
        }

        scoreText.text = scoreMessage;
    }
}