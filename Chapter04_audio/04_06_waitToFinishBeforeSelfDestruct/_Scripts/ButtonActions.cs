using UnityEngine;

public class ButtonActions : MonoBehaviour
{
	// reference to AudioSource object
	// public - so set up in Inspector
	public AudioSource audioSource;

	// reference to a script object of class AudioDestructBehaviour
	// public - so setup in Inspector
	public AudioDestructBehaviour audioDestructScriptedObject;

	//----------------------------------
	// if sound in AudioSource not already playing then start playing it
	public void ACTION_PlaySound()
	{
		if( !audioSource.isPlaying )
			audioSource.Play();
	}

	//----------------------------------------
	// when this method run (from UI button click)
	// enable the scripted object audioDestructScriptedObject
	// that that object will now respond to Start() and Update() Monobehaviuour messages etc.
	public void ACTION_DestroyAfterSoundStops()
	{
		audioDestructScriptedObject.enabled = true;
	}
}