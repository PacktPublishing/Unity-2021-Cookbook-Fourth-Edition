using UnityEngine;

// adapted to use AudioSources with clips
// from Unity documentation sample (Nov 2017) found at:
// https://docs.unity3d.com/ScriptReference/AudioSettings-dspTime.html
public class Metronome : MonoBehaviour
{
    public AudioSource audioSourceTickBasic;
    public AudioSource audioSourceTickAccent;

    public double bpm = 140.0F;
    public int beatsPerMeasure = 4;

    private double nextTickTime = 0.0F;
    private int beatCount;
    private double beatDuration;

    /// <summary>
    /// calc duration of each beat (based on 'bpm')
    /// initialise the beat count (so first beat is an accented beat)
    /// set time to next tick is NOW!
    /// </summary>
    void Start()
    {
        // 1 minute = 60 seconds / (numebr of beats per minute)
        beatDuration = 60.0F / bpm;

        beatCount = beatsPerMeasure; // so about to do a beat

        double startTick = AudioSettings.dspTime;
        nextTickTime = startTick;
    }

    /// <summary>
    /// if close to time for next tick invoke BeatAction()
    /// </summary>
    void Update()
    {
        if (IsNearlyTimeForNextTick())
            BeatAction();
    }

    /// <summary>
    /// decide if nearly time for next tick...
    /// </summary>
    /// <returns><c>true</c>, if nearly time for next tick, <c>false</c> otherwise.</returns>
    private bool IsNearlyTimeForNextTick()
    {
        float lookAhead = 0.1F;
        if ((AudioSettings.dspTime + lookAhead) >= nextTickTime)
            return true;
        else
            return false;
    }


    /// <summary>
    /// time to schedule next beat
    /// </summary>
    private void BeatAction()
    {
        // add 1 to number of beats
        beatCount++;

        // default - no accent message to display
        string accentMessage = "";

        // accented beat or not ?
        if (beatCount > beatsPerMeasure)
            accentMessage = AccentBeatAction();
        else
            // basic beat action
            audioSourceTickBasic.PlayScheduled(nextTickTime);

        // next tick in 'beatDuration' seconds
        nextTickTime += beatDuration;

        // display beat count message in Console
        print("Tick: " + beatCount + "/" + beatsPerMeasure + accentMessage);
    }

    /// <summary>
    /// schedule acented beat beat
    /// reset beat count to 1
    /// return message - so user can see this beat was ACCENTed
    /// </summary>
    /// <returns>The beat action message.</returns>
    private string AccentBeatAction()
    {
        audioSourceTickAccent.PlayScheduled(nextTickTime);
        beatCount = 1;
        return " -- ACCENT ---";
    }
}