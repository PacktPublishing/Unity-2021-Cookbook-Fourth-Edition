using UnityEngine;

public class IncrementIncorrectScore : MonoBehaviour
{
	void Start ()
	{
		// subtract 1 from score
        int newScoreCorrect = 1 + PlayerPrefs.GetInt("scoreCorrect");
        PlayerPrefs.SetInt("scoreCorrect", newScoreCorrect);
	}
}
