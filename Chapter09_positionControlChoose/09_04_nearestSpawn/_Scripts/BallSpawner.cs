using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // reference to GameObject prefab to be crated when player hits fire key
    public GameObject prefabBall;

    // reference to our spawn point manager object
    private SpawnPointManager spawnPointManager;

    // minimum pause between each new object can be created
    private float timeBetweenSpawns = 1;


    /*----------------------------------------------------------
     * cache reference to spawn point manager object
     * and start repeat spawning method call
     */
    void Start ()
    {
        spawnPointManager = GetComponent<SpawnPointManager> ();
        InvokeRepeating("CreateSphere", 0, timeBetweenSpawns);
    }


    /*----------------------------------------------------------
     * retrieve a randome / nearby spawnpoint from the spawn point manager
     * can create clone of prefab object (and store reference to new object in 'newBall')
     * set it to be Destroyed after 'destroyAfterDelay' seconds
     */
    private void CreateSphere()
    {
     GameObject spawnPoint = spawnPointManager.NearestSpawnpoint(transform.position);

        // only try to instantiate prefab if spawnpoint is NOT null
        if(spawnPoint){
            GameObject newBall = (GameObject)Instantiate (prefabBall, spawnPoint.transform.position, Quaternion.identity);
            Destroy(newBall, timeBetweenSpawns/2);
        }
    }
}
