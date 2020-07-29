using UnityEngine;
using UnityEngine.Video;

public class RandomUrlDownloadMaterialOverride: MonoBehaviour
{
    public string[] urls =
    {
        "http://mirrors.standaloneinstaller.com/video-sample/grb_2.mov",
        "http://mirrors.standaloneinstaller.com/video-sample/lion-sample.mov"
    };
    
    private VideoPlayer videoPlayer;
    private AudioSource audioSource;

    void Start()
    {
        SetupVideoAudioPlayers();
        
        // register method to invoke AFTER preparation is completed
        videoPlayer.prepareCompleted += PlayVideoWhenPrepared;
        
        // prepare video clip
        videoPlayer.Prepare();
        Debug.Log("A - PREPARING");
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
        string randomUrl = RandomUrl(urls);
        videoPlayer.url = randomUrl;

        // setup AudioSource 
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
        		
        // output video to texture of parent objects Renderer
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";
    }
    
    private void PlayVideoWhenPrepared(VideoPlayer theVideoPlayer)
    {
        Debug.Log("B - IS PREPARED");

        // Play video
        Debug.Log("C - PLAYING");
        theVideoPlayer.Play();
    }
    
    public string RandomUrl(string[] urls)
    {
        int index = Random.Range(0, urls.Length);        
        return urls[index];
    }
}

