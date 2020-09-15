using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    private Text _textUITime;
    private float _startTime;
    
    void Awake()
    {
        _textUITime = GetComponent<Text>();
        _startTime = Time.time;
    }

    void Update()
    {
        float elapsedSeconds = (Time.time - _startTime);
        
        // 1 decimal place
        string timeMessage = "Elapsed time = " + elapsedSeconds.ToString ("F");
        _textUITime.text = timeMessage;
    }
}
