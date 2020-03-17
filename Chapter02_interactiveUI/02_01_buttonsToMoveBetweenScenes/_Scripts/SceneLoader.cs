using UnityEngine;

// import the LoadScene method
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
    // public method - so can be listed as an OnClick Button event action
    public void LoadOnClick(int levelNumber){
        // load the scene for the given number
        // (number is array index for Build scenes)
        SceneManager.LoadScene(levelNumber);
    }
}