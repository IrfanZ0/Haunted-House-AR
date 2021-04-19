using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMove : MonoBehaviour
{
    private NavMeshAgent spiderNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform spiderWayPoint1;
    private Transform spiderWayPoint2;
    private Transform spiderWayPoint3;
    private Transform spiderWayPoint4;
    private Transform spiderWayPoint5;
    private List<Transform> wayPoints2;
    private Transform spiderWayPoint6;
    private Transform spiderWayPoint7;
    private Transform spiderWayPoint8;
    private Transform spiderWayPoint9;
    private Transform spiderWayPoint10;

    private StateController spiderStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        spiderStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        spiderWayPoint1 = GameObject.Find ( "Spider Path 1" ).transform.Find ( "Spider WayPoint 1" );
        wayPoints.Add ( spiderWayPoint1 );
        spiderWayPoint2 = GameObject.Find ( "Spider Path 1" ).transform.Find ( "Spider WayPoint 2" );
        wayPoints.Add ( spiderWayPoint2 );
        spiderWayPoint3 = GameObject.Find ( "Spider Path 1" ).transform.Find ( "Spider WayPoint 3" );
        wayPoints.Add ( spiderWayPoint3 );
        spiderWayPoint4 = GameObject.Find ( "Spider Path 1" ).transform.Find ( "Spider WayPoint 4" );
        wayPoints.Add ( spiderWayPoint4 );
        spiderWayPoint5 = GameObject.Find ( "Spider Path 1" ).transform.Find ( "Spider WayPoint 5" );
        wayPoints.Add ( spiderWayPoint5 );

        wayPoints2 = new List<Transform> ( );
        spiderWayPoint6 = GameObject.Find ( "Spider Path 2" ).transform.Find ( "Spider WayPoint 1" );
        wayPoints2.Add ( spiderWayPoint1 );
        spiderWayPoint7 = GameObject.Find ( "Spider Path 2" ).transform.Find ( "Spider WayPoint 2" );
        wayPoints2.Add ( spiderWayPoint2 );
        spiderWayPoint8 = GameObject.Find ( "Spider Path 2" ).transform.Find ( "Spider WayPoint 3" );
        wayPoints2.Add ( spiderWayPoint3 );
        spiderWayPoint9 = GameObject.Find ( "Spider Path 2" ).transform.Find ( "Spider WayPoint 4" );
        wayPoints2.Add ( spiderWayPoint4 );
        spiderWayPoint10 = GameObject.Find ( "Spider Path 2" ).transform.Find ( "Spider WayPoint 5" );
        wayPoints2.Add ( spiderWayPoint5 );

        spiderNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( spiderNavMeshAgent.gameObject != null && spiderNavMeshAgent.isOnNavMesh && wayPoints != null )
        {
            navMeshActive = true;
            spiderStateController.SetupAI ( navMeshActive , wayPoints );

        }
        else if ( spiderNavMeshAgent.gameObject != null && spiderNavMeshAgent.isOnNavMesh && wayPoints2 != null )
        {
            navMeshActive = true;
            spiderStateController.SetupAI ( navMeshActive , wayPoints2 );

        }
        else
        {
            navMeshActive = false;
        }

    }

}