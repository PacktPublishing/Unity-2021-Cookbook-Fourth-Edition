using UnityEngine;
using UnityEngine.UI;

public class WaitToFinishBeforePlaying : MonoBehaviour 
{
	public AudioSource audioSource;
	public Text buttonText;

    /// <summary>
    /// each frame ensure buttoin text tells user whether sound is playing, or ready to play again
    /// </summary>
	void Update()
    {
		string statusMessage = "Play sound";
		if(audioSource.isPlaying )
			statusMessage = "(sound playing)";

		buttonText.text = statusMessage;
	}

	/// <summary>
    /// BUTTON click action
    /// if not still playing, then send audio source a Play() message
    /// </summary>
	public void ACTION_PlaySoundIfNotPlaying()
    {
		if( !audioSource.isPlaying )
			audioSource.Play();
	}
}