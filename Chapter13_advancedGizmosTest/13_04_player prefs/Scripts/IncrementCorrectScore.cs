using UnityEngine;

public class IncrementCorrectScore : MonoBehaviour
{
	void Start ()
	{
		// add 1 to score
        int newScoreIncorrect = 1 + PlayerPrefs.GetInt("scoreIncorrect");
        PlayerPrefs.SetInt("scoreIncorrect", newScoreIncorrect);
	}
}