using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMove : MonoBehaviour
{
    private NavMeshAgent ghostNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform ghostStop1;
    private Transform ghostStop2;
    private Transform ghostStop3;
    private Transform ghostStop4;
    private Transform ghostStop5;
    private Transform ghostStop6;
    private Transform ghostStop7;
    private Transform ghostStop8;
    private StateController ghostStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        ghostStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        ghostStop1 = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 1" );
        wayPoints.Add ( ghostStop1 );
        ghostStop2 = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 2" );
        wayPoints.Add ( ghostStop2 );
        ghostStop3 = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 3" );
        wayPoints.Add ( ghostStop3 );
        ghostStop4 = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 4" );
        wayPoints.Add ( ghostStop4 );
        ghostStop5 = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 5" );
        wayPoints.Add ( ghostStop5 );
        ghostStop6 = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 6" );
        wayPoints.Add ( ghostStop6 );
        ghostStop7 = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 7" );
        wayPoints.Add ( ghostStop7 );
        ghostStop8 = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 8" );
        wayPoints.Add ( ghostStop8 );
        ghostNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( ghostNavMeshAgent.gameObject != null && ghostNavMeshAgent.isOnNavMesh )
        {
            navMeshActive = true;
            ghostStateController.SetupAI ( navMeshActive , wayPoints );

        }

    }
}