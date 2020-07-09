using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    public GameObject sphereDestination;

    private NavMeshAgent navMeshAgent;    
    private RaycastHit hit;
   
    void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        sphereDestination.transform.position = transform.position;
    }
    
    void Update() 
    {
        Ray rayFromMouseClick = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (FireRayCast(rayFromMouseClick)){
            Vector3 rayPoint = hit.point;
            ProcessRayHit(rayPoint);
        }
    }

    // RayCast hit a surface - do something, depending of whether mouse was clicked ...
    private void ProcessRayHit(Vector3 rayPoint)
    {
        if(Input.GetMouseButtonDown(0)) {
            // (1) set hitPoint as new NavmeshAgent destination
            navMeshAgent.destination = rayPoint;
            
            // (2) move Red sphere to destination point
            sphereDestination.transform.position = rayPoint;
        }
    }

    // return NegativeInfinity if Raycast did not hit a surface
    private bool FireRayCast(Ray rayFromMouseClick)
    {
        // ignore layer "UISpheres"
        return Physics.Raycast(rayFromMouseClick, out hit, 100);
    }
}