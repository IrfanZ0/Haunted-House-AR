using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceBubaMove : MonoBehaviour
{
    NavMeshAgent iBubaNavMeshAgent;
    private bool navMeshActive = false;
    public List<Transform> wayPoints;
    StateController iBubaStateController;

    // Start is called before the first frame update
    void Start()
    {
        iBubaStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        iBubaNavMeshAgent = GetComponent<NavMeshAgent>();

        if (iBubaNavMeshAgent.gameObject != null && iBubaNavMeshAgent.isOnNavMesh)
        {
            navMeshActive = true;
            iBubaStateController.SetupAI(navMeshActive, wayPoints);

        }

    }
}
