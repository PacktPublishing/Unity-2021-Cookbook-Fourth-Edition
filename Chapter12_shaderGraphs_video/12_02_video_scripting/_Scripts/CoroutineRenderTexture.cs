using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class CoroutineRenderTexture : MonoBehaviour
{
	public RenderTexture renderTexture;
	public VideoClip videoClip;

	private VideoPlayer videoPlayer;
	private AudioSource audioSource;

	private IEnumerator Start()
	{
		SetupVideoAudioPlayers();
		
		videoPlayer.Prepare();

		while (!videoPlayer.isPrepared)
			yield return null;

		videoPlayer.Play();		
	}
	
	private void SetupVideoAudioPlayers()
	{
		// add video player and audio source components
		videoPlayer = gameObject.AddComponent<VideoPlayer>();
		audioSource = gameObject.AddComponent<AudioSource>();

		// disable Play on Awake for both vide and audio
		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;

		// assign video clip
		videoPlayer.source = VideoSource.VideoClip;
		videoPlayer.clip = videoClip;

		// setup AudioSource 
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		videoPlayer.SetTargetAudioSource(0, audioSource);
		
		// output video to RenderTexture
		videoPlayer.renderMode = VideoRenderMode.RenderTexture;
		videoPlayer.targetTexture = renderTexture;
	}
}