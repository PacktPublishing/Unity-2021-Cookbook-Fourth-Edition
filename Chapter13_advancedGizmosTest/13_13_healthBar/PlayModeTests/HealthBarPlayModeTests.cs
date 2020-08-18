using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

[TestFixture]
public class PlayerPlayModeTest
{
    private Scene tempTestScene;
    // name of scene being tested by this class
    private string sceneToTest = "HealthBar";

    [SetUp]
    public void Setup()
    {
               // setup - load the scene
               tempTestScene = SceneManager.GetActiveScene();
    } 

    [UnityTest]
    public IEnumerator TestHealthBarImageMatchesPlayerHealth()
    {
        // load scene to be tested
        yield return SceneManager.LoadSceneAsync(sceneToTest, LoadSceneMode.Additive); SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToTest));

        // wait for one frame
        yield return null;

        // Arrange
        Image healthBarFiller = GameObject.Find("image-health-bar-filler").GetComponent<Image>();
        PlayerManager playerManager = GameObject.FindWithTag("PlayerManager").GetComponent<PlayerManager>();
        float expectedResult = 0.9f;

        // Act
        playerManager.ReduceHealth();

        // Assert
        Assert.AreEqual(expectedResult, healthBarFiller.fillAmount);

        // teardown - reload original temp test scene
        SceneManager.SetActiveScene(tempTestScene);
        yield return SceneManager.UnloadSceneAsync(sceneToTest);
    }
}