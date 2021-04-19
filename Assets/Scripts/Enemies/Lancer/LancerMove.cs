using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LancerMove : MonoBehaviour
{
    private NavMeshAgent lancerNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform lancerPoint;
    private Transform lancerWayPoint1;
    private Transform lancerWayPoint2;
    private Transform lancerWayPoint3;
    private Transform lancerWayPoint4;
    private Transform lancerWayPoint5;
    private List<Transform> wayPoints2;
    private Transform lancerWayPoint6;
    private Transform lancerWayPoint7;
    private Transform lancerWayPoint8;
    private Transform lancerWayPoint9;
    private Transform lancerWayPoint10;

    private StateController lancerStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        lancerStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        lancerPoint = GameObject.Find ( "Lancer Path 1" ).transform.Find ( "Lancer Jump Point 1 Right" );
        wayPoints.Add ( lancerPoint );
        lancerWayPoint1 = GameObject.Find ( "Lancer Path 1" ).transform.Find ( "Lancer WayPoint 1" );
        wayPoints.Add ( lancerWayPoint1 );
        lancerWayPoint2 = GameObject.Find ( "Lancer Path 1" ).transform.Find ( "Lancer WayPoint 2" );
        wayPoints.Add ( lancerWayPoint2 );
        lancerWayPoint3 = GameObject.Find ( "Lancer Path 1" ).transform.Find ( "Lancer WayPoint 3" );
        wayPoints.Add ( lancerWayPoint3 );
        lancerWayPoint4 = GameObject.Find ( "Lancer Path 1" ).transform.Find ( "Lancer WayPoint 4" );
        wayPoints.Add ( lancerWayPoint4 );
        lancerWayPoint5 = GameObject.Find ( "Lancer Path 1" ).transform.Find ( "Lancer WayPoint 5" );
        wayPoints.Add ( lancerWayPoint5 );

        wayPoints2 = new List<Transform> ( );
        lancerPoint = GameObject.Find ( "Lancer Path 2" ).transform.Find ( "Lancer Jump Point 1 Right" );
        wayPoints.Add ( lancerPoint );
        lancerWayPoint6 = GameObject.Find ( "Lancer Path 2" ).transform.Find ( "Lancer WayPoint 1" );
        wayPoints2.Add ( lancerWayPoint1 );
        lancerWayPoint7 = GameObject.Find ( "Lancer Path 2" ).transform.Find ( "Lancer WayPoint 2" );
        wayPoints2.Add ( lancerWayPoint2 );
        lancerWayPoint8 = GameObject.Find ( "Lancer Path 2" ).transform.Find ( "Lancer WayPoint 3" );
        wayPoints2.Add ( lancerWayPoint3 );
        lancerWayPoint9 = GameObject.Find ( "Lancer Path 2" ).transform.Find ( "Lancer WayPoint 4" );
        wayPoints2.Add ( lancerWayPoint4 );
        lancerWayPoint10 = GameObject.Find ( "Lancer Path 2" ).transform.Find ( "Lancer WayPoint 5" );
        wayPoints2.Add ( lancerWayPoint5 );

        lancerNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( lancerNavMeshAgent.gameObject != null && lancerNavMeshAgent.isOnNavMesh && wayPoints != null )
        {
            navMeshActive = true;
            lancerStateController.SetupAI ( navMeshActive , wayPoints );

        }
        else if ( lancerNavMeshAgent.gameObject != null && lancerNavMeshAgent.isOnNavMesh && wayPoints2 != null )
        {
            navMeshActive = true;
            lancerStateController.SetupAI ( navMeshActive , wayPoints2 );

        }
        else
        {
            navMeshActive = false;
        }

    }

    // Update is called once per frame
    private void Update ( )
    {

    }
}