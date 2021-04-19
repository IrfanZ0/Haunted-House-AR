using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatMove : MonoBehaviour
{
    private NavMeshAgent batNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform batWayPoint1;
    private Transform batWayPoint2;
    private Transform batWayPoint3;
    private Transform batWayPoint4;
    private Transform batWayPoint5;
    private List<Transform> wayPoints2;
    private Transform batWayPoint6;
    private Transform batWayPoint7;
    private Transform batWayPoint8;
    private Transform batWayPoint9;
    private Transform batWayPoint10;

    private StateController batStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        batStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        batWayPoint1 = GameObject.Find ( "Bat Path 1" ).transform.Find ( "Bat WayPoint 1" );
        wayPoints.Add ( batWayPoint1 );
        batWayPoint2 = GameObject.Find ( "Bat Path 1" ).transform.Find ( "Bat WayPoint 2" );
        wayPoints.Add ( batWayPoint2 );
        batWayPoint3 = GameObject.Find ( "Bat Path 1" ).transform.Find ( "Bat WayPoint 3" );
        wayPoints.Add ( batWayPoint3 );
        batWayPoint4 = GameObject.Find ( "Bat Path 1" ).transform.Find ( "Bat WayPoint 4" );
        wayPoints.Add ( batWayPoint4 );
        batWayPoint5 = GameObject.Find ( "Bat Path 1" ).transform.Find ( "Bat WayPoint 5" );
        wayPoints.Add ( batWayPoint5 );

        wayPoints2 = new List<Transform> ( );
        batWayPoint1 = GameObject.Find ( "Bat Path 2" ).transform.Find ( "Bat WayPoint 1" );
        wayPoints2.Add ( batWayPoint1 );
        batWayPoint2 = GameObject.Find ( "Bat Path 2" ).transform.Find ( "Bat WayPoint 2" );
        wayPoints2.Add ( batWayPoint2 );
        batWayPoint3 = GameObject.Find ( "Bat Path 2" ).transform.Find ( "Bat WayPoint 3" );
        wayPoints2.Add ( batWayPoint3 );
        batWayPoint4 = GameObject.Find ( "Bat Path 2" ).transform.Find ( "Bat WayPoint 4" );
        wayPoints2.Add ( batWayPoint4 );
        batWayPoint5 = GameObject.Find ( "Bat Path 2" ).transform.Find ( "Bat WayPoint 5" );
        wayPoints2.Add ( batWayPoint5 );

        batNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( batNavMeshAgent.gameObject != null && batNavMeshAgent.isOnNavMesh && wayPoints != null )
        {
            navMeshActive = true;
            batStateController.SetupAI ( navMeshActive , wayPoints );

        }
        else if ( batNavMeshAgent.gameObject != null && batNavMeshAgent.isOnNavMesh && wayPoints2 != null )
        {
            navMeshActive = true;
            batStateController.SetupAI ( navMeshActive , wayPoints2 );

        }
        else if ( batNavMeshAgent.gameObject != null && batNavMeshAgent.isOnNavMesh && wayPoints == null && wayPoints2 == null )
        {
            navMeshActive = true;
            GameObject player = GameObject.Find("Maze").transform.Find("MazeHolder").transform.Find("AR Session Origin").gameObject;
            batNavMeshAgent.SetDestination ( player.transform.position );

        }
        else
        {
            navMeshActive = false;
        }

    }

}