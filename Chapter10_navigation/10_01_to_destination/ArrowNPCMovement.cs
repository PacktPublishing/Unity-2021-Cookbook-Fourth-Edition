using UnityEngine;
using UnityEngine.AI;
	
public class ArrowNPCMovement : MonoBehaviour {
	public GameObject targetGO;
	private NavMeshAgent navMeshAgent;
	
	void Start()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		HeadForDestintation();
	}

	private void HeadForDestintation ()
	{
		Vector3 destination = targetGO.transform.position;
		navMeshAgent.SetDestination (destination);
	}
}
