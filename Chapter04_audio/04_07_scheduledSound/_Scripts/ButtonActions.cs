using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour 
{
    public Text clockText;
    public Text hoursText;
    public Text minutesText;
    public Text secondsText;

    private ScheduledSoundManager _scheduledSoundManager;

    private void Awake()
    {
        _scheduledSoundManager = GetComponent<ScheduledSoundManager>();
    }

    public void ACTION_PlayMusic()
    {
        int hours = int.Parse(hoursText.text);
        int minutes = int.Parse(minutesText.text);
        int seconds = int.Parse(secondsText.text);

        // pass the hours/minutes/seconds from the inputs on screen to our SoundManager object
        _scheduledSoundManager.PlayMusic(hours, minutes, seconds);
    }

    // every frame update the time on screen
    private void Update()
    {
        clockText.text = "Time = " + DateTime.Now.ToString("HH:mm:ss");
    }
}