using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CountdownTimer))]
public class SliderTimerDisplay : MonoBehaviour
{
	private CountdownTimer countdownTimer;
	private Slider sliderUI;

	//----------------------------
	// get a reference to the CountdownTimer object that is a componet of our parent GameObject
	// get a reference to the Slider object that is a componet of our parent GameObject
	void Awake()
    {
        countdownTimer = GetComponent<CountdownTimer>();
		sliderUI = GetComponent<Slider>();
	}

	//----------------------------
    // seet slider for 0.0 - 1.0 decimal values through code
	// start that timer to countdown for 30 seconds
	void Start()
	{
		SetupSlider();
		countdownTimer.ResetTimer( 30 );
	}

	//----------------------------
	// each frame we get the proportion of countdown left as a value from 0.0 - 1.0
	// and set the slider to display that proportion (e.g. 0.5 - slider handle in the center etc.)
	// and display it in console text message
	void Update ()
	{
		sliderUI.value = countdownTimer.GetProportionTimeRemaining();
		print (countdownTimer.GetProportionTimeRemaining());
	}

	//----------------------------
	// set slider to represent values from 0.0 - 1.0
	// which just happens to correspond to the values received from
	// countdown time method: GetProportionTimeRemaining()
	private void SetupSlider ()
	{
		sliderUI.minValue = 0;
		sliderUI.maxValue = 1;
		sliderUI.wholeNumbers = false;
	}

}
