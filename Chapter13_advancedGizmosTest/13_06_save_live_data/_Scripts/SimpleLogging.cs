using UnityEngine;

public class SimpleLogging : MonoBehaviour
{
    void Start() {
        AddToLogFile.LogLine("Scene has started");
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Space)) {
            AddToLogFile.LogLine("SPACE key was pressed");            
        }
    }
}
