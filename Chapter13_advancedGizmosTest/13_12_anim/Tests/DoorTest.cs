using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class DoorTest
{
    const int BASE_LAYER = 0;
    private string initialScenePath;
    private Animator doorAnimator;
    private Scene tempTestScene;

    // name of scene being tested by this class
    private string sceneToTest = "doorScene";

    [SetUp]
    public void Setup()
    {
        // setup - load the scene
        tempTestScene = SceneManager.GetActiveScene();
    }

    [UnityTest]
    public IEnumerator TestDoorAnimationStateStartsClosed()
    {
        // load scene to be tested
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        // Arrange
        doorAnimator = GameObject.FindWithTag("Door").GetComponent<Animator>();
        string expectedDoorAnimationState = "DoorClosed";

        // immediate next frame
        yield return null;

        // Act
        AnimatorClipInfo[] currentClipInfo = doorAnimator.GetCurrentAnimatorClipInfo(BASE_LAYER);
        string doorAnimationState = currentClipInfo[0].clip.name;

        // Assert
        Assert.AreEqual(expectedDoorAnimationState, doorAnimationState);

        // teardown - reload original temp test scene
        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }

    [UnityTest]
    public IEnumerator TestIsOpeningStartsFalse()
    {
        // load scene to be tested
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        // Arrange
        doorAnimator = GameObject.FindWithTag("Door").GetComponent<Animator>();

        // immediate next frame
        yield return null;

        // Act
        bool isOpening = doorAnimator.GetBool("Opening");

        // Assert
        Assert.IsFalse(isOpening);

        // teardown - reload original temp test scene
        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }


    [UnityTest]
    public IEnumerator TestDoorAnimationStateOpenAfterAFewSeconds()
    {
        // load scene to be tested
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        // wait a few seconds
        int secondsToWait = 3;
        yield return new WaitForSeconds(secondsToWait);

        // Arrange
        doorAnimator = GameObject.FindWithTag("Door").GetComponent<Animator>();
        string expectedDoorAnimationState = "DoorOpen";


        // Act
        AnimatorClipInfo[] currentClipInfo = doorAnimator.GetCurrentAnimatorClipInfo(BASE_LAYER);
        string doorAnimationState = currentClipInfo[0].clip.name;
        bool isOpening = doorAnimator.GetBool("Opening");

        // Assert
        Assert.AreEqual(expectedDoorAnimationState, doorAnimationState);
        Assert.IsTrue(isOpening);

        // teardown - reload original temp test scene
        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }


}