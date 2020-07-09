using UnityEngine;
using UnityEngine.AI;

public class DebugRaySourceDestination : MonoBehaviour 
{
    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 destination = GetComponent<NavMeshAgent>().destination;
        Vector3 direction = destination - origin;

        // show yellow line from source to target
        Debug.DrawRay(origin, direction, Color.yellow);
    }    
}

