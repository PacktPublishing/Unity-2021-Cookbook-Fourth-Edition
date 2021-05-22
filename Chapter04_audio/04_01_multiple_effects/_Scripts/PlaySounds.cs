using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySounds : MonoBehaviour 
{
    public AudioClip clipEatCherry;
    public AudioClip clipExtraLife;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            audioSource.PlayOneShot(clipEatCherry);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(clipExtraLife);
        }
    }

}
