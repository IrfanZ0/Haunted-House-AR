using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonMove : MonoBehaviour
{
    private NavMeshAgent skeletonNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private StateController skeletonStateController;
    private Transform skeletonStop1;
    private Transform skeletonStop2;
    private Transform skeletonStop3;
    private Transform skeletonStop4;
    private Transform skeletonStop5;
    private Transform skeletonStop6;
    private Transform skeletonStop7;

    // Start is called before the first frame update
    private void Start ( )
    {
        skeletonStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        skeletonStop1 = GameObject.Find ( "Skeleton Path" ).transform.Find ( "Skeleton WayPoint 1" );
        wayPoints.Add ( skeletonStop1 );
        skeletonStop2 = GameObject.Find ( "Skeleton Path" ).transform.Find ( "Skeleton WayPoint 2" );
        wayPoints.Add ( skeletonStop2 );
        skeletonStop3 = GameObject.Find ( "Skeleton Path" ).transform.Find ( "Skeleton WayPoint 3" );
        wayPoints.Add ( skeletonStop3 );
        skeletonStop4 = GameObject.Find ( "Skeleton Path" ).transform.Find ( "Skeleton WayPoint 4" );
        wayPoints.Add ( skeletonStop4 );
        skeletonStop5 = GameObject.Find ( "Skeleton Path" ).transform.Find ( "Skeleton WayPoint 5" );
        wayPoints.Add ( skeletonStop5 );
        skeletonStop6 = GameObject.Find ( "Skeleton Path" ).transform.Find ( "Skeleton WayPoint 6" );
        wayPoints.Add ( skeletonStop6 );
        skeletonStop7 = GameObject.Find ( "Skeleton Path" ).transform.Find ( "Skeleton WayPoint 7" );
        wayPoints.Add ( skeletonStop7 );
        skeletonNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( skeletonNavMeshAgent.gameObject != null && skeletonNavMeshAgent.isOnNavMesh )
        {
            navMeshActive = true;
            skeletonStateController.SetupAI ( navMeshActive , wayPoints );

        }

    }
}