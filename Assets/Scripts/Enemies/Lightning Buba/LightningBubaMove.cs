using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightningBubaMove : MonoBehaviour
{
    private NavMeshAgent lBubaNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform lightningBubaStop1;
    private Transform lightningBubaStop2;
    private Transform lightningBubaStop3;
    private Transform lightningBubaStop4;
    private Transform lightningBubaStop5;
    private StateController lBubaStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        lBubaStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        lightningBubaStop1 = GameObject.Find ( "Lightning Buba WayPoints" ).transform.Find ( "Lightning Buba Stop 1" );
        wayPoints.Add ( lightningBubaStop1 );
        lightningBubaStop2 = GameObject.Find ( "Lightning Buba WayPoints" ).transform.Find ( "Lightning Buba Stop 2" );
        wayPoints.Add ( lightningBubaStop2 );
        lightningBubaStop3 = GameObject.Find ( "Lightning Buba WayPoints" ).transform.Find ( "Lightning Buba Stop 3" );
        wayPoints.Add ( lightningBubaStop3 );
        lightningBubaStop4 = GameObject.Find ( "Lightning Buba WayPoints" ).transform.Find ( "Lightning Buba Stop 4" );
        wayPoints.Add ( lightningBubaStop4 );
        lightningBubaStop5 = GameObject.Find ( "Lightning Buba WayPoints" ).transform.Find ( "Lightning Buba Stop 5" );
        wayPoints.Add ( lightningBubaStop5 );
        lBubaNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( lBubaNavMeshAgent.gameObject != null && lBubaNavMeshAgent.isOnNavMesh )
        {
            navMeshActive = true;
            lBubaStateController.SetupAI ( navMeshActive , wayPoints );

        }

    }
}