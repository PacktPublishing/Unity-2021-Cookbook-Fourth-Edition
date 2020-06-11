using UnityEngine;

// source: adapted from sample code on the Unity script reference pages
// https://docs.unity3d.com/ScriptReference/AudioSource.PlayScheduled.html

public class LoopScheduler : MonoBehaviour
{
    // assume 140 bpm
    public float bpm = 140.0F;

    // assume 16 beats per bar
    public int numBeatsPerSegment = 16;

    public AudioSource[] audioSources = new AudioSource[4];

    private double nextEventTime;

    private int nextLoopIndex = 0;

    private int numLoops;

    // 60 seconds in a minute
    private float numSecondsPerMinute = 60F;

    // the time before the next clip starts to pl;ay
    private float timeBetweenPlays;


    void Start()
    {
        numLoops = audioSources.Length;
        nextEventTime = AudioSettings.dspTime;
        timeBetweenPlays = numSecondsPerMinute / bpm * numBeatsPerSegment;
    }

    void Update()
    {
        double lookAhead = AudioSettings.dspTime + 1.0F;
        if (lookAhead > nextEventTime)
        {
            StartNextLoop();
        }

        PrintLoopPlayingStatus();
    }

    private void StartNextLoop()
    {
        audioSources[nextLoopIndex].PlayScheduled(nextEventTime);
        nextEventTime += timeBetweenPlays;

        nextLoopIndex++;
        if (nextLoopIndex >= numLoops)
        {
            nextLoopIndex = 0;
        }
    }

    private void PrintLoopPlayingStatus()
    {
        string statusMessage = "Sounds playing: ";
        int i = 0;
        while (i < numLoops)
        {
            statusMessage += audioSources[i].isPlaying + " ";
            i++;
        }

        print(statusMessage);
    }
}