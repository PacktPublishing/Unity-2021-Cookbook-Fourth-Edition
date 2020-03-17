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

    /*----------------------------------------------------------
     * loop through array 'spawnPoints' to find and reutnr reference to
     * object closest to (x,y,z) position parameter 'source'
     */
    public GameObject NearestSpawnpoint (Vector3 source)
    {
      // return current gameObject if array empty
      if( spawnPoints.Length < 1) return null;

      // default is first pne
      GameObject nearestSpawnPoint = spawnPoints[0];
      Vector3 spawnPointPos = spawnPoints[0].transform.position;
      float shortestDistance = Vector3.Distance(source, spawnPointPos);

      // see if any remaining objects in array are nearer than first one ...
      for (int i = 1; i < spawnPoints.Length; i++){
        spawnPointPos = spawnPoints[i].transform.position;
        float newDist = Vector3.Distance(source, spawnPointPos);
        if (newDist < shortestDistance){
          shortestDistance = newDist;
          nearestSpawnPoint = spawnPoints[i];
        }
      }

      return nearestSpawnPoint;
    }

}
