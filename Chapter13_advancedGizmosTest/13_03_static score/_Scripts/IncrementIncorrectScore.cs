using UnityEngine;

public class IncrementIncorrectScore : MonoBehaviour
{
	void Start ()
	{
		// subtract 1 from score
		Player.scoreIncorrect++;	
	}
}
