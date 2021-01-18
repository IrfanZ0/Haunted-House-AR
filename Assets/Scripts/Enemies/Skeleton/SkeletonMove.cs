using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonMove : MonoBehaviour
{
    NavMeshAgent skeletonNavMeshAgent;
    private bool navMeshActive = false;
    public List<Transform> wayPoints;
    StateController skeletonStateController;

    // Start is called before the first frame update
    void Start()
    {
        skeletonStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        skeletonNavMeshAgent = GetComponent<NavMeshAgent>();

        if (skeletonNavMeshAgent.gameObject != null && skeletonNavMeshAgent.isOnNavMesh)
        {
            navMeshActive = true;
            skeletonStateController.SetupAI(navMeshActive, wayPoints);

        }

    }
}
