using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMove : MonoBehaviour
{
    NavMeshAgent ghostNavMeshAgent;
    private bool navMeshActive = false;
    public List<Transform> wayPoints;
    StateController ghostStateController;

    // Start is called before the first frame update
    void Start()
    {
        ghostStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        ghostNavMeshAgent = GetComponent<NavMeshAgent>();

        if (ghostNavMeshAgent.gameObject != null && ghostNavMeshAgent.isOnNavMesh)
        {
            navMeshActive = true;
            ghostStateController.SetupAI(navMeshActive, wayPoints);

        }



    }
}
