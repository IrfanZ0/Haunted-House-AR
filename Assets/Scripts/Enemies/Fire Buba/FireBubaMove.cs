using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBubaMove : MonoBehaviour
{
    private NavMeshAgent fBubaNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform fireBubaStop1;
    private Transform fireBubaStop2;
    private Transform fireBubaStop3;
    private Transform fireBubaStop4;
    private Transform fireBubaStop5;
    private StateController fBubaStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        fBubaStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        fireBubaStop1 = GameObject.Find ( "Fire Buba WayPoints" ).transform.Find ( "Fire Buba Stop 1" );
        wayPoints.Add ( fireBubaStop1 );
        fireBubaStop2 = GameObject.Find ( "Fire Buba WayPoints" ).transform.Find ( "Fire Buba Stop 2" );
        wayPoints.Add ( fireBubaStop2 );
        fireBubaStop3 = GameObject.Find ( "Fire Buba WayPoints" ).transform.Find ( "Fire Buba Stop 3" );
        wayPoints.Add ( fireBubaStop3 );
        fireBubaStop4 = GameObject.Find ( "Fire Buba WayPoints" ).transform.Find ( "Fire Buba Stop 4" );
        wayPoints.Add ( fireBubaStop4 );
        fireBubaStop5 = GameObject.Find ( "Fire Buba WayPoints" ).transform.Find ( "Fire Buba Stop 5" );
        wayPoints.Add ( fireBubaStop5 );

        fBubaNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( fBubaNavMeshAgent.gameObject != null && fBubaNavMeshAgent.isOnNavMesh )
        {
            navMeshActive = true;
            fBubaStateController.SetupAI ( navMeshActive , wayPoints );

        }

    }
}