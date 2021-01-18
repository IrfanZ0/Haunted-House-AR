using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonLordMove : MonoBehaviour
{
    NavMeshAgent dlNavMeshAgent;
    private bool navMeshActive = false;
    public List<Transform> wayPoints;
    StateController dlStateController;

    // Start is called before the first frame update
    void Start()
    {
        dlStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        dlNavMeshAgent = GetComponent<NavMeshAgent>();

        if (dlNavMeshAgent.gameObject != null && dlNavMeshAgent.isOnNavMesh)
        {
            navMeshActive = true;
            dlStateController.SetupAI(navMeshActive, wayPoints);

        }

    }
}
