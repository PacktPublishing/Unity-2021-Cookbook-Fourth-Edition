using UnityEngine;
using System;
using UnityEngine.UI;

public class ScheduledSoundManager : MonoBehaviour 
{
    public Text textScheduledMessage;
    private AudioSource audioSource;
    private bool activated = false;
    private float secondsUntilPlay = 0;
    private DateTime scheduledPlayTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // play sound at specified time (today!)
    public void PlayMusic(int hours, int minutes, int seconds)
    {
        // get today's date, and add the hours+minutes+seconds
        // to get time to play
        scheduledPlayTime = DateTime.Today.Add(new TimeSpan(hours, minutes, seconds));
        UpdateSecondsUntilPlay();
        audioSource.PlayDelayed(secondsUntilPlay);
        activated = true;
    }

    private void Update()
    {
        // default message
        String message = "played!";

        if(activated){
            UpdateSecondsUntilPlay();
            if(secondsUntilPlay > 0){
                message = "scheduled to play in " + secondsUntilPlay + " seconds";
            } else {
                activated = false;
            }
            textScheduledMessage.text = message;
        }
    }

    // update the object variable "secondsUntilPlay" for seconds remaining until sound to be played
    private void UpdateSecondsUntilPlay()
    {
        TimeSpan delayUntilPlay = scheduledPlayTime - DateTime.Now;
        secondsUntilPlay = delayUntilPlay.Seconds;
    }
}