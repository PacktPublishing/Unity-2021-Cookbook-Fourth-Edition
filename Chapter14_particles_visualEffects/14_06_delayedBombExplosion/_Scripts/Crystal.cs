using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        // create explosion at same location as this Crystal
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        
        // destroy particle system after 1 second
        Destroy(explosion, 1);
        
        // remove this Crystal
        Destroy(this.gameObject);
    }
}
