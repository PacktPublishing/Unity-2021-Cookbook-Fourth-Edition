using UnityEngine;
using System;
using UnityEngine.UI;

public class ScheduledSoundManager : MonoBehaviour 
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// play sound at specified time
    /// </summary>
    public void PlayMusic(int hours, int minutes, int seconds)
    {
        DateTime time1147 = DateTime.Today.Add(new TimeSpan(hours, minutes, seconds));
        TimeSpan delayTimeSpan = time1147 - DateTime.Now;
        float delayMilliseconds = delayTimeSpan.Seconds;

        print("delay milliseconds = " + delayMilliseconds);

        audioSource.PlayDelayed(delayMilliseconds);
    }
}