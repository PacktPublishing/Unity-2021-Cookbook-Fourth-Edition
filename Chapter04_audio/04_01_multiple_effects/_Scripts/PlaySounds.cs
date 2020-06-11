using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour 
{
    public AudioClip clipEatCherry;
    public AudioClip clipExtraLife;

    private AudioSource audioAudioSource;

    void Awake()
    {
        audioAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            audioAudioSource.PlayOneShot(clipEatCherry);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            audioAudioSource.PlayOneShot(clipExtraLife);
        }
    }

}
