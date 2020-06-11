using UnityEngine;

public class MusicManager : MonoBehaviour 
{
    // sound file clip 1
    public AudioClip clipMedieval;

    // sound file clip 2
    public AudioClip clipArcade;

    // audio source component 1
    private AudioSource audioSourceMedieval;

    // audio source component 2
    private AudioSource audioSourceArcade;

    /// <summary>
    /// create gameobjects containing audio source components linked to the 2 sound clip files
    /// </summary>
    void Awake()
    {
        audioSourceMedieval = this.CreateAudioSource(clipMedieval, true);
        audioSourceArcade = this.CreateAudioSource(clipArcade, false);
    }



    // every frame pause/resume music clip if correct key is pressed
    void Update()
    {
        // Music 1
        // if already started, resume playing
        // else start playing
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (audioSourceMedieval.time > 0)
                audioSourceMedieval.UnPause();
            else
                audioSourceMedieval.Play();
        }

        // pause playing
        if (Input.GetKey(KeyCode.LeftArrow))
            audioSourceMedieval.Pause();
        
        // Music 2
        // if already started, resume playing
        // else start playing
        if (Input.GetKey(KeyCode.UpArrow)){
            if (audioSourceArcade.time > 0)
                audioSourceArcade.UnPause();
            else
                audioSourceArcade.Play();            
        }

        // pause playing
        if (Input.GetKey(KeyCode.DownArrow))
            audioSourceArcade.Pause();

    }
}