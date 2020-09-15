using UnityEngine;
using System;


public class Snapshot : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            print("taking snapshot");
            string timeStamp = DateTime.Now.ToString("HH_mm_ss");
            ScreenCapture.CaptureScreenshot("snapshot_" + timeStamp + ".png");            
        }
    }
}
