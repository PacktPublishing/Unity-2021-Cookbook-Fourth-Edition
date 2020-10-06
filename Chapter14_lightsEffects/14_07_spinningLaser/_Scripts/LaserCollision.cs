using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        // create explosion at same location as this Crystal
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        
        // destroy particle system after 1 second
        Destroy(explosion, 1);
        
        // do other logic here - e.g. reduce player health ...
    }
}
