using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightningBubaMove : MonoBehaviour
{
    NavMeshAgent lBubaNavMeshAgent;
    private bool navMeshActive = false;
    public List<Transform> wayPoints;
    StateController lBubaStateController;

    // Start is called before the first frame update
    void Start()
    {
        lBubaStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        lBubaNavMeshAgent = GetComponent<NavMeshAgent>();

        if (lBubaNavMeshAgent.gameObject != null && lBubaNavMeshAgent.isOnNavMesh)
        {
            navMeshActive = true;
            lBubaStateController.SetupAI(navMeshActive, wayPoints);

        }

    }
}
