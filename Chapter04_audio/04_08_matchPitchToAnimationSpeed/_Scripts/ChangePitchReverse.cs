using UnityEngine;

/* ----------------------------------------
 * class to demonstrate how to change the pitch of an Audio Source according to the 
 * speed of the object's animator component
 */ 
public class ChangePitchReverse : MonoBehaviour
{

	// Float variable for incrementing the Animation speed
	public float acceleration = 0.05f;

	// Float for keeping speed bottom limit;
	public float minSpeed = -2.0f;

	// Float for keeping speed top limit;
	public float maxSpeed = 2.0f;

	// Float for the ratio between animation speed and sound pitch. 
	public float animationSoundRatio = 1.0f;

	// Float for keeping the animation's speed
	private float speed = 0.0f;

	// A variable for accessing the object's Animator component
	private Animator animator;

	// A variable for accessing the object's AudioSource component
	private AudioSource audioSource;

    /// <summary>
    /// get references to sibling components Animator and AudioSource
    /// </summary>
    private void Awake()
    {
        // Set Animator component as 'animator'
        animator = GetComponent<Animator>();

        // Set AudioSource component as 'audioSource'
        audioSource = GetComponent<AudioSource>();
    }


    /* ----------------------------------------
     * At Start, assign the object's Animator component to animator, assign AudioSource component to audioSource,
     * get the animation speed and call the AccelRocket function to adjust the audio pitch without accelerating it
     */
    void Start()
    {
        // Set the current animator's speed as 'speed'
        speed = animator.speed;

        // Call AccelRocket() function to adjust sound to initial Animator's speed
        AccelerateRocket (0f);
    }   

	/* ----------------------------------------
	 * Whenever keys '1' and '2' are pressed on the alphanumeric keyboard, 
	 * call AccelRocket() to readjust speed 
	 */
	void Update(){
		if (Input.GetKey (KeyCode.Alpha1))
			// IF key '1' is pressed, THEN call AccelRocket to increase speed 
			AccelerateRocket(acceleration);
		
		if (Input.GetKey (KeyCode.Alpha2))
			// IF key '2' is pressed, THEN call AccelRocket to decrease speed
			AccelerateRocket(-acceleration);
	}

	/* ----------------------------------------
	 * A function that receives float value to be summed   
	 * to speed 
	 */
    public void AccelerateRocket(float acceleration)
    {
		// Increment 'speed' with 'accel'
		speed += acceleration; 

		// Clamp the new speed value to minimum and maximum allowed.
		speed = Mathf.Clamp(speed,minSpeed,maxSpeed);

        // Update the animator's speed through the "Speed" float variable of the Animator
		// Please, open the 'rocketControllerReverse' Controller and select the 'Spin' state. 
		// In the Inspector view you should be able to see 'Multiplier' checked as 'Parameter', 
		// being driven by the 'Speed' float variable, which was set in the 'Parameters' section of the Animator
		animator.SetFloat("Speed",speed);

		// A variable for keeping the new sound pitch: the 'speed' variable multiplied by the animation/sound ratio
		float soundPitch = speed * animationSoundRatio;

		//Update AudioSource pitch with absolute value of 'soundPitch'
		// (conversion to Absolute value needed in case animation is reversed by negative speed value)
		audioSource.pitch = Mathf.Abs(soundPitch);
	}
}
