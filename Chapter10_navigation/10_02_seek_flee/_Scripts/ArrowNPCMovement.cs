using UnityEngine;
using UnityEngine.AI;

public class ArrowNPCMovement : MonoBehaviour
{
    public float runAwayDistance = 10;
    public GameObject targetGO;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 targetPosition = targetGO.transform.position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distanceToTarget < runAwayDistance)
            FleeFromTarget(targetPosition);
    }

    private void FleeFromTarget(Vector3 targetPosition)
    {
        Vector3 destination = PositionToFleeTowards(targetPosition);
        HeadForDestintation(destination);
    }

    private void HeadForDestintation(Vector3 destinationPosition)
    {
        navMeshAgent.SetDestination(destinationPosition);
    }

    private Vector3 PositionToFleeTowards(Vector3 targetPosition)
    {
        transform.rotation = Quaternion.LookRotation(transform.position - targetPosition);
        Vector3 runToPosition = targetPosition + (transform.forward * runAwayDistance);
        return runToPosition;
    }
}