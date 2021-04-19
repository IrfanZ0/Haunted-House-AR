using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceBubaMove : MonoBehaviour
{
    private NavMeshAgent iBubaNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform iceBubaStop1;
    private Transform iceBubaStop2;
    private Transform iceBubaStop3;
    private Transform iceBubaStop4;
    private Transform iceBubaStop5;
    private StateController iBubaStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        iBubaStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );

        iceBubaStop1 = GameObject.Find ( "Ice Buba WayPoints" ).transform.Find ( "Ice Buba Stop 1" );
        wayPoints.Add ( iceBubaStop1 );
        iceBubaStop2 = GameObject.Find ( "Ice Buba WayPoints" ).transform.Find ( "Ice Buba Stop 2" );
        wayPoints.Add ( iceBubaStop2 );
        iceBubaStop3 = GameObject.Find ( "Ice Buba WayPoints" ).transform.Find ( "Ice Buba Stop 3" );
        wayPoints.Add ( iceBubaStop3 );
        iceBubaStop4 = GameObject.Find ( "Ice Buba WayPoints" ).transform.Find ( "Ice Buba Stop 4" );
        wayPoints.Add ( iceBubaStop4 );
        iceBubaStop5 = GameObject.Find ( "Ice Buba WayPoints" ).transform.Find ( "Ice Buba Stop 5" );
        wayPoints.Add ( iceBubaStop5 );
        iBubaNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( iBubaNavMeshAgent.gameObject != null && iBubaNavMeshAgent.isOnNavMesh )
        {
            navMeshActive = true;
            iBubaStateController.SetupAI ( navMeshActive , wayPoints );

        }

    }
}