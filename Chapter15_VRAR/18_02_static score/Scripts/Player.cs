using UnityEngine;

public class Player : MonoBehaviour
{
	// 2 static variables
	// so no instance of this class needed
	public static int scoreCorrect = 0;
	public static int scoreIncorrect = 0;

	/*-------------------------------------------
	 * reset both scores to zero
	 */
	public static void ZeroAll()
	{
		scoreCorrect = 0;
		scoreIncorrect = 0;
	}
}
