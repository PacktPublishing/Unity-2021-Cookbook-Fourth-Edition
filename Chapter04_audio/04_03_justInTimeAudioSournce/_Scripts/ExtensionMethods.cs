using UnityEngine;

public static class ExtensionMethods
{
    /// <summary>
    /// create a game object with an audio source component
    /// linked to the provided audio clip
    /// </summary>
    /// <returns>The audio source.</returns>
    /// <param name="audioClip">Audio clip the audio source component is to be linked to</param>
    /// <param name="startPlayingImmediately">If set to <c>true</c> start playing immediately.</param>
    public static AudioSource CreateAudioSource(this MonoBehaviour parent, AudioClip audioClip, bool startPlayingImmediately)
    {
        // create new empty GameObject
        GameObject audioSourceGO = new GameObject();

        // position new GO in same posution as parent to this scripted component
        audioSourceGO.transform.position = parent.transform.position;

        // add AudioSource component
        AudioSource newAudioSource = audioSourceGO.AddComponent<AudioSource>() as AudioSource;

        // associate clip with AudioSource
        newAudioSource.clip = audioClip;

        // start playing as soon as created (if parameter was 'true')
        if (startPlayingImmediately)
            newAudioSource.Play();

        // use next line if you want this clip to self-destroy when clip finishes playing
        //        Destroy(instance.gameObject, clip.length);
        return newAudioSource;
    }

}
