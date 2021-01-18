using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceDragonMove : MonoBehaviour
{
    NavMeshAgent iDragonNavMeshAgent;
    private bool navMeshActive = false;
    public List<Transform> wayPoints;
    StateController iDragonStateController;

    // Start is called before the first frame update
    void Start()
    {
        iDragonStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        iDragonNavMeshAgent = GetComponent<NavMeshAgent>();

        if (iDragonNavMeshAgent.gameObject != null && iDragonNavMeshAgent.isOnNavMesh)
        {
            navMeshActive = true;
            iDragonStateController.SetupAI(navMeshActive, wayPoints);

        }

    }
}
