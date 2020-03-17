using UnityEngine;

public class CountdownTimer : MonoBehaviour 
{
	private float countdownTimerStartTime;
	private int countdownTimerDuration;

	//-----------------------------
	public int GetTotalSeconds()
	{
		return countdownTimerDuration;
	}

	//-----------------------------
	public void ResetTimer(int seconds)
	{
		countdownTimerStartTime = Time.time;
		countdownTimerDuration = seconds;
	}

	//-----------------------------
	public int GetSecondsRemaining()
	{
		int elapsedSeconds = (int)(Time.time - countdownTimerStartTime);
		int secondsLeft = (countdownTimerDuration - elapsedSeconds);
		return secondsLeft;
	}

	//-----------------------------
	public float GetSecondsRemainingFloat()
	{
		float elapsedSeconds = (Time.time - countdownTimerStartTime);
		float secondsLeft = (countdownTimerDuration - elapsedSeconds);
		return secondsLeft;
	}
	
	//-----------------------------
	public float GetProportionTimeRemaining()
	{
		float proportionLeft = (float)GetSecondsRemainingFloat() / (float)GetTotalSeconds();
		return proportionLeft;
	}

	//---------------------------------
	private string LeadingZero(int n)
	{
		// pad out numbers less than 10 with a leading 0
		// e.g. 1 becomes 01, 4 becomes 04 etc.
		return n.ToString().PadLeft(2, '0');
	}
}
