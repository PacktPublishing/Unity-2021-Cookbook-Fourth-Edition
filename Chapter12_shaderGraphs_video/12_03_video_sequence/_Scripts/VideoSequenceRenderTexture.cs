using UnityEngine;
using UnityEngine.Video;

/**
 * inspired from couroutine array loop example posted by 'Programmer' at Stackoverflow November 2017
 * https://stackoverflow.com/questions/47401759/play-different-videos-back-to-back-seamlessly-using-unity-video-player
 */

public class VideoSequenceRenderTexture : MonoBehaviour
{
    // Render Texture to output currently playing video into
    public RenderTexture renderTexture;

    // video clip array
    public VideoClip[] videoClips;

    // video player components array
    private VideoPlayer[] videoPlayers;
    
    // int index of current video clip/player
    private int currentVideoIndex;

    void Start()
    {
        SetupObjectArrays();

        //Prepare first video
        currentVideoIndex = 0;
        
        // register method to invoke AFTER preparation is completed
        videoPlayers[currentVideoIndex].prepareCompleted += PlayNextVideo;
        
        // prepare video clip
        videoPlayers[currentVideoIndex].Prepare();
        Debug.Log("A - PREPARING video: " + currentVideoIndex);  
    }
        
    private void SetupObjectArrays()
    {
        videoPlayers = new VideoPlayer[videoClips.Length];
        for (int i = 0; i < videoClips.Length; i++)
            SetupVideoAudioPlayers(i);
    }
    
    private void SetupVideoAudioPlayers(int i)
    {
        string newGameObjectName = "videoPlayer_" + i;

        //Create new Object to hold the Video and the sound then make it a child of this object
        GameObject containerGo = new GameObject(newGameObjectName);
        containerGo.transform.SetParent(transform);

        // add video player and audio source components
        VideoPlayer videoPlayer = containerGo.AddComponent<VideoPlayer>();
        AudioSource audioSource = containerGo.AddComponent<AudioSource>();

        // add reference to new video player to array
        videoPlayers[i] = videoPlayer;

        // disable Play on Awake for both vide and audio
        videoPlayer.playOnAwake = false;
        audioSource.playOnAwake = false;

        // assign video clip
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClips[i];

        // setup AudioSource 
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
        
        // output video to RenderTexture
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;
    }

        
    private void PlayNextVideo(VideoPlayer theVideoPlayer)
    {
        VideoPlayer currentVideoPlayer = videoPlayers[currentVideoIndex];

        // Play video
        Debug.Log("B - PLAYING Index: " + currentVideoIndex);
        currentVideoPlayer.Play();
        
        // IF more clips remaining THEN prepare then and play when current clip finished
        currentVideoIndex++;
        bool someVideosLeft = currentVideoIndex < videoPlayers.Length;

        if (someVideosLeft) {
            // start Preparing next clip
            VideoPlayer nextVideoPlayer = videoPlayers[currentVideoIndex];
            nextVideoPlayer.Prepare();
            Debug.Log("A - PREPARING video: " + currentVideoIndex);        
        
            // register to play next video once current one has finished
            currentVideoPlayer.loopPointReached += PlayNextVideo;            
        }
        else {
            Debug.Log("(no videos left)");
        }

    }


}
