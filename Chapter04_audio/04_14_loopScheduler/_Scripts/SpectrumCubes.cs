using UnityEngine;

/// <summary>
/// inspired by the Unity spectrum data smaple code at:
/// https://docs.unity3d.com/ScriptReference/AudioSource.GetSpectrumData.html
/// </summary>
public class SpectrumCubes : MonoBehaviour 
{
    const int NUM_SAMPLES = 512;

    public Color displayColor;
    public float multiplier = 5000;
    public float startY;
    public float maxHeight = 50;

    private AudioSource audioSource;
    private float[] spectrum = new float[NUM_SAMPLES];

    private GameObject[] cubes = new GameObject[NUM_SAMPLES];

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        CreateCubes();
    }


    /// <summary>
    /// each frame - update spectral array, then use the new data to change cube heights
    /// </summary>
    void Update()
    {
        // update spectral array
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        UpdateCubeHeights();
    }


    /// <summary>
    /// Updates the cube heights with updated spectrum array values
    /// </summary>
    private void UpdateCubeHeights()
    {
        for (int i = 0; i < NUM_SAMPLES; i++)
        {
            Vector3 oldScale = cubes[i].transform.localScale;
            Vector3 scaler = new Vector3(oldScale.x, HeightFromSample(spectrum[i]), oldScale.z);

            // scale cube Y-length
            cubes[i].transform.localScale = scaler;

            // position so it looks like it's just getting taller
            Vector3 oldPosition = cubes[i].transform.position;
            float newY = startY + cubes[i].transform.localScale.y / 2;
            Vector3 newPosition = new Vector3(oldPosition.x, newY, oldPosition.z);
            cubes[i].transform.position = newPosition;
        }

    }

    /// <summary>
    /// Heights from audio sample value
    /// </summary>
    /// <returns>The from sample.</returns>
    /// <param name="sample">Sample.</param>
    private float HeightFromSample(float sample)
    {
        float height = 2  + (sample * multiplier);
        return Mathf.Clamp(height, 0, maxHeight);
    }


    /// <summary>
    /// Creates the cubes a cube for each sample
    /// </summary>
    private void CreateCubes()
    {
        for (int i = 0; i < NUM_SAMPLES; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = transform;
            cube.name = "SampleCube" + i;

            // set color of material for cube
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            cubeRenderer.material = new Material(Shader.Find("Specular"));
            cubeRenderer.sharedMaterial.color = displayColor;

            // each cube is a little bit further along the X-axis
            float x = 0.9f * i;
            float y = startY;
            float z = 0;
            cube.transform.position = new Vector3(x, y, z);

            // store reference to this GameObject in our array
            cubes[i] = cube;
        }
    }
}
