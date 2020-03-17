using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    // array of reference to spawn point GameObjects in the scene
    private GameObject[] spawnPoints;

    /*----------------------------------------------------------
     * find all GameObjects in scene tagged 'Respawn' and store in array 'spawnPoints'
     * fi none found, log an error
     */
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        // log Error if array empty
        if(spawnPoints.Length < 1)
            Debug.LogError ("SpawnPointManagaer - cannot find any objects tagged 'Respawn'!");
    }

    /*----------------------------------------------------------
     * choose and return a reference to one randomly chosen member of array 'spawnPoints'
     */
    public GameObject RandomSpawnPoint ()
    {
        // return current gameObject if array empty
        if( spawnPoints.Length < 1) return null;

        int r = Random.Range(0, spawnPoints.Length);
        return spawnPoints[r];
    }

}
