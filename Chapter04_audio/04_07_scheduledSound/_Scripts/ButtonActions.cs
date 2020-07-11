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

        _scheduledSoundManager.PlayMusic(hours, minutes, seconds);
    }

    private void Update()
    {
        clockText.text = "Time = " + DateTime.Now.ToString("HH:mm:ss");
    }
}