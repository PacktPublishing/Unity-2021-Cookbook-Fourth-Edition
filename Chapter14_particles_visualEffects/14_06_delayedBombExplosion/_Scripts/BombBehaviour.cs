using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public GameObject explosionPrefab;

    void Start()
    {
        // after 3 seconds instantiate the explosion
        float delay = 3;
        Invoke(nameof(Explode), delay);

    }

    private void Explode()
    {        
        // create explosion at same location as this player
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        
        // destroy particle system after 1 second
        Destroy(explosion, 1);
        
        // --- do any collision logic for bomb here -----
        //  Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        
        // destroy this bomb GameObject
        Destroy(gameObject);
    }
}
