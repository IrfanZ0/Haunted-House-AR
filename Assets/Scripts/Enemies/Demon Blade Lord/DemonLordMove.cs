using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonLordMove : MonoBehaviour
{
    private NavMeshAgent dlNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform demonLordPoint1;
    private Transform demonLordPoint2;
    private Transform demonLordPoint3;
    private Transform demonLordPoint4;
    private Transform demonLordPoint5;
    private StateController dlStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        dlStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        demonLordPoint1 = GameObject.Find ( "Demon Lord Path" ).transform.Find ( "Demon Lord WayPoint 1" );
        wayPoints.Add ( demonLordPoint1 );
        demonLordPoint2 = GameObject.Find ( "Demon Lord Path" ).transform.Find ( "Demon Lord WayPoint 2" );
        wayPoints.Add ( demonLordPoint2 );
        demonLordPoint3 = GameObject.Find ( "Demon Lord Path" ).transform.Find ( "Demon Lord WayPoint 3" );
        wayPoints.Add ( demonLordPoint3 );
        demonLordPoint4 = GameObject.Find ( "Demon Lord Path" ).transform.Find ( "Demon Lord WayPoint 4" );
        wayPoints.Add ( demonLordPoint4 );
        demonLordPoint5 = GameObject.Find ( "Demon Lord Path" ).transform.Find ( "Demon Lord WayPoint 5" );
        wayPoints.Add ( demonLordPoint5 );
        dlNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( dlNavMeshAgent.gameObject != null && dlNavMeshAgent.isOnNavMesh )
        {
            navMeshActive = true;
            dlStateController.SetupAI ( navMeshActive , wayPoints );

        }

    }
}