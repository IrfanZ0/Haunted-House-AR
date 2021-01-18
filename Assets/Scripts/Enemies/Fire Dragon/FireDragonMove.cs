using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireDragonMove : MonoBehaviour
{
    NavMeshAgent fDragonNavMeshAgent;
    private bool navMeshActive = false;
    public List<Transform> wayPoints;
    StateController fDragonStateController;

    // Start is called before the first frame update
    void Start()
    {
        fDragonStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        fDragonNavMeshAgent = GetComponent<NavMeshAgent>();

        if (fDragonNavMeshAgent.gameObject != null && fDragonNavMeshAgent.isOnNavMesh)
        {
            navMeshActive = true;
            fDragonStateController.SetupAI(navMeshActive, wayPoints);

        }

    }
}
