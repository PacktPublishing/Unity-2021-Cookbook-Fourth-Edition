using UnityEngine;

public class BombFeature : MonoBehaviour
{
    public GameObject bombPrefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // create bomb at same location as this player
            Instantiate(bombPrefab, transform.position, transform.rotation);            
        }
    }
    
}
