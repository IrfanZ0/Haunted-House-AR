using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBubaMove : MonoBehaviour
{
    NavMeshAgent fBubaNavMeshAgent;
    private bool navMeshActive = false;
    public List<Transform> wayPoints;
    StateController fBubaStateController;

    // Start is called before the first frame update
    void Start()
    {
        fBubaStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        fBubaNavMeshAgent = GetComponent<NavMeshAgent>();

        if (fBubaNavMeshAgent.gameObject != null && fBubaNavMeshAgent.isOnNavMesh)
        {
            navMeshActive = true;
            fBubaStateController.SetupAI(navMeshActive, wayPoints);

        }

    }
}
