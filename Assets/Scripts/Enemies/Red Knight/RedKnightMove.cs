using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedKnightMove : MonoBehaviour
{
    private NavMeshAgent redKnightNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private List<Transform> wayPoints2;
    private Transform redKnightWayPoint1;
    private Transform redKnightWayPoint2;
    private Transform redKnightWayPoint3;
    private Transform redKnightWayPoint4;
    private Transform redKnightWayPoint5;
    private Transform redKnightWayPoint6;
    private StateController redKnightStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        redKnightStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        redKnightWayPoint1 = GameObject.Find ( "Red Knight Path 1" ).transform.Find ( "Red Knight WayPoint 1" );
        wayPoints.Add ( redKnightWayPoint1 );
        redKnightWayPoint2 = GameObject.Find ( "Red Knight Path 1" ).transform.Find ( "Red Knight WayPoint 2" );
        wayPoints.Add ( redKnightWayPoint2 );
        redKnightWayPoint3 = GameObject.Find ( "Red Knight Path 1" ).transform.Find ( "Red Knight WayPoint 3" );
        wayPoints.Add ( redKnightWayPoint3 );
        redKnightWayPoint4 = GameObject.Find ( "Red Knight Path 1" ).transform.Find ( "Red Knight WayPoint 4" );
        wayPoints.Add ( redKnightWayPoint4 );
        redKnightWayPoint5 = GameObject.Find ( "Red Knight Path 1" ).transform.Find ( "Red Knight WayPoint 5" );
        wayPoints.Add ( redKnightWayPoint5 );
        redKnightWayPoint6 = GameObject.Find ( "Red Knight Path 1" ).transform.Find ( "Red Knight WayPoint 6" );
        wayPoints.Add ( redKnightWayPoint6 );

        wayPoints2 = new List<Transform> ( );
        redKnightWayPoint1 = GameObject.Find ( "Red Knight Path 2" ).transform.Find ( "Red Knight WayPoint 1" );
        wayPoints2.Add ( redKnightWayPoint1 );
        redKnightWayPoint2 = GameObject.Find ( "Red Knight Path 2" ).transform.Find ( "Red Knight WayPoint 2" );
        wayPoints2.Add ( redKnightWayPoint2 );
        redKnightWayPoint3 = GameObject.Find ( "Red Knight Path 2" ).transform.Find ( "Red Knight WayPoint 3" );
        wayPoints2.Add ( redKnightWayPoint3 );
        redKnightWayPoint4 = GameObject.Find ( "Red Knight Path 2" ).transform.Find ( "Red Knight WayPoint 4" );
        wayPoints2.Add ( redKnightWayPoint4 );
        redKnightWayPoint5 = GameObject.Find ( "Red Knight Path 2" ).transform.Find ( "Red Knight WayPoint 5" );
        wayPoints2.Add ( redKnightWayPoint5 );

        redKnightNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( redKnightNavMeshAgent.gameObject != null && redKnightNavMeshAgent.isOnNavMesh && wayPoints != null )
        {
            navMeshActive = true;
            redKnightStateController.SetupAI ( navMeshActive , wayPoints );

        }
        else if ( redKnightNavMeshAgent.gameObject != null && redKnightNavMeshAgent.isOnNavMesh && wayPoints2 != null )
        {
            navMeshActive = true;
            redKnightStateController.SetupAI ( navMeshActive , wayPoints2 );

        }
        else
        {
            navMeshActive = false;
        }

    }
}