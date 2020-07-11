using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSourceMedieval;
    public AudioSource audioSourceArcade;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (audioSourceMedieval.time > 0)
                audioSourceMedieval.UnPause();
            else
                audioSourceMedieval.Play();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
            audioSourceMedieval.Pause();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (audioSourceArcade.time > 0)
                audioSourceArcade.UnPause();
            else
                audioSourceArcade.Play();
        }

        if (Input.GetKey(KeyCode.DownArrow))
            audioSourceArcade.Pause();
    }
}