using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceDragonMove : MonoBehaviour
{
    private NavMeshAgent iDragonNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform iceDragonStop1;
    private Transform iceDragonStop2;
    private Transform iceDragonStop3;
    private Transform iceDragonStop4;
    private Transform iceDragonStop5;
    private Transform iceDragonStop6;
    private Transform iceDragonStop7;
    private StateController iDragonStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        iDragonStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        iceDragonStop1 = GameObject.Find ( "IceDragon Path" ).transform.Find ( "IceDragon WayPoint 1" );
        wayPoints.Add ( iceDragonStop1 );
        iceDragonStop2 = GameObject.Find ( "IceDragon Path" ).transform.Find ( "IceDragon WayPoint 2" );
        wayPoints.Add ( iceDragonStop2 );
        iceDragonStop3 = GameObject.Find ( "IceDragon Path" ).transform.Find ( "IceDragon WayPoint 3" );
        wayPoints.Add ( iceDragonStop3 );
        iceDragonStop4 = GameObject.Find ( "IceDragon Path" ).transform.Find ( "IceDragon WayPoint 4" );
        wayPoints.Add ( iceDragonStop4 );
        iceDragonStop5 = GameObject.Find ( "IceDragon Path" ).transform.Find ( "IceDragon WayPoint 5" );
        wayPoints.Add ( iceDragonStop5 );
        iceDragonStop6 = GameObject.Find ( "IceDragon Path" ).transform.Find ( "IceDragon WayPoint 6" );
        wayPoints.Add ( iceDragonStop6 );
        iceDragonStop7 = GameObject.Find ( "IceDragon Path" ).transform.Find ( "IceDragon WayPoint 7" );
        wayPoints.Add ( iceDragonStop7 );
        iDragonNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( iDragonNavMeshAgent.gameObject != null && iDragonNavMeshAgent.isOnNavMesh )
        {
            navMeshActive = true;
            iDragonStateController.SetupAI ( navMeshActive , wayPoints );

        }

    }
}