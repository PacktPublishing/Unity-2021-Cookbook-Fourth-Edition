using UnityEngine;

// adapted from Unity documentation sample (Nov 2017) found at:
// https://docs.unity3d.com/ScriptReference/AudioSettings-dspTime.html

[RequireComponent(typeof(AudioSource))]
public class MetronomeSynthsized : MonoBehaviour
{
// The code example shows how to implement a metronome that procedurally generates the click sounds via the OnAudioFilterRead callback.
// While the game is paused or the suspended, this time will not be updated and sounds playing will be paused. Therefore developers of music scheduling routines do not have to do any rescheduling after the app is unpaused

    public double bpm = 140.0F;
    public float gain = 0.5F;
    public int signatureHi = 4;
    public int signatureLo = 4;
    private double nextTickTime = 0.0F;
    private float amp = 0.0F;
    private float phase = 0.0F;
    private double sampleRate = 0.0F;
    private int beatCount;
    private bool running = false;

    void Start()
    {
        beatCount = signatureHi;
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        nextTickTime = startTick * sampleRate;
        running = true;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!running)
            return;

        double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;
        double sample = AudioSettings.dspTime * sampleRate;
        int samplesPerChannel = data.Length / channels;
        int currentSampleNumber = 0;
        while (currentSampleNumber < samplesPerChannel)
        {
            float x = gain * amp * Mathf.Sin(phase);

            // loop to update vaue for every channel for current sample number
            int currentChannel = 0;
            while (currentChannel < channels)
            {
                data[currentSampleNumber * channels + currentChannel] += x;
                currentChannel++;
            }

            // if time for a TICK then do something !
            if (IsTimeForNextTick(sample, currentSampleNumber)) {
                BeatAction(samplesPerTick);
            }

            phase += amp * 0.3F;
            amp *= 0.993F;
            currentSampleNumber++;
        }
    }

    private void BeatAction(double samplesPerTick)
    {
        beatCount++;
        nextTickTime += samplesPerTick;
        amp = 1.0F;

        // default to no accent
        if (beatCount > signatureHi){
            AccentBeatAction();
        }

        print("Tick: " + beatCount + "/" + signatureHi);
    }

    private void AccentBeatAction()
    {
        beatCount = 1;
        amp *= 2.0F;
        print("-- ACCENT ---");
    }

    private bool IsTimeForNextTick(double sample, int n)
    {
        if ((sample + n) >= nextTickTime)
            return true;
        else
            return false;
    }
}