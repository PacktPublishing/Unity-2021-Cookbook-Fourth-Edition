using UnityEngine;
using UnityEngine.InputSystem;

public class BombFeature : MonoBehaviour
{
    public GameObject bombPrefab;

    void Update()
    {
        if (Keyboard.current[Key.B].wasReleasedThisFrame)
        {
            // create bomb at same location as this player
            Instantiate(bombPrefab, transform.position, transform.rotation);
        }
    }
}