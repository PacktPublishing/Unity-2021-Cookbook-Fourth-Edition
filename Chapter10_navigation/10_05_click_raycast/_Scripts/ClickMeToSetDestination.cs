using UnityEngine;

public class ClickMeToSetDestination : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent playerNavMeshAgent;

    void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerNavMeshAgent = playerGO.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void OnMouseDown()
    {
        playerNavMeshAgent.SetDestination(transform.position);
    }
}
