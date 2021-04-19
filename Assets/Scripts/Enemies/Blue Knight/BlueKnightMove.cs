using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueKnightMove : MonoBehaviour
{
    private NavMeshAgent blueKnightNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private List<Transform> wayPoints2;
    private Transform blueKnightWayPoint1;
    private Transform blueKnightWayPoint2;
    private Transform blueKnightWayPoint3;
    private Transform blueKnightWayPoint4;
    private Transform blueKnightWayPoint5;
    private Transform blueKnightWayPoint6;
    private StateController blueKnightStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        blueKnightStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        blueKnightWayPoint1 = GameObject.Find ( "Blue Knight Path 1" ).transform.Find ( "Blue Knight WayPoint 1" );
        wayPoints.Add ( blueKnightWayPoint1 );
        blueKnightWayPoint2 = GameObject.Find ( "Blue Knight Path 1" ).transform.Find ( "BlueKnight WayPoint 2" );
        wayPoints.Add ( blueKnightWayPoint2 );
        blueKnightWayPoint3 = GameObject.Find ( "Blue Knight Path 1" ).transform.Find ( "Blue Knight WayPoint 3" );
        wayPoints.Add ( blueKnightWayPoint3 );
        blueKnightWayPoint4 = GameObject.Find ( "Blue Knight Path 1" ).transform.Find ( "Blue Knight WayPoint 4" );
        wayPoints.Add ( blueKnightWayPoint4 );
        blueKnightWayPoint5 = GameObject.Find ( "Blue Knight Path 1" ).transform.Find ( "Blue Knight WayPoint 5" );
        wayPoints.Add ( blueKnightWayPoint5 );
        blueKnightWayPoint6 = GameObject.Find ( "Blue Knight Path 1" ).transform.Find ( "Blue Knight WayPoint 6" );
        wayPoints.Add ( blueKnightWayPoint6 );

        wayPoints2 = new List<Transform> ( );
        blueKnightWayPoint1 = GameObject.Find ( "Blue Knight Path 2" ).transform.Find ( "Blue Knight WayPoint 1" );
        wayPoints2.Add ( blueKnightWayPoint1 );
        blueKnightWayPoint2 = GameObject.Find ( "Blue Knight Path 2" ).transform.Find ( "Blue Knight WayPoint 2" );
        wayPoints2.Add ( blueKnightWayPoint2 );
        blueKnightWayPoint3 = GameObject.Find ( "Blue Knight Path 2" ).transform.Find ( "Blue Knight WayPoint 3" );
        wayPoints2.Add ( blueKnightWayPoint3 );
        blueKnightWayPoint4 = GameObject.Find ( "Blue Knight Path 2" ).transform.Find ( "Blue Knight WayPoint 4" );
        wayPoints2.Add ( blueKnightWayPoint4 );
        blueKnightWayPoint5 = GameObject.Find ( "Blue Knight Path 2" ).transform.Find ( "Blue Knight WayPoint 5" );
        wayPoints2.Add ( blueKnightWayPoint5 );
        blueKnightWayPoint6 = GameObject.Find ( "Blue Knight Path 2" ).transform.Find ( "Blue Knight WayPoint 6" );
        wayPoints2.Add ( blueKnightWayPoint6 );

        blueKnightNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( blueKnightNavMeshAgent.gameObject != null && blueKnightNavMeshAgent.isOnNavMesh && wayPoints != null )
        {
            navMeshActive = true;
            blueKnightStateController.SetupAI ( navMeshActive , wayPoints );

        }
        else if ( blueKnightNavMeshAgent.gameObject != null && blueKnightNavMeshAgent.isOnNavMesh && wayPoints2 != null )
        {
            navMeshActive = true;
            blueKnightStateController.SetupAI ( navMeshActive , wayPoints2 );

        }
        else
        {
            navMeshActive = false;
        }

    }
}