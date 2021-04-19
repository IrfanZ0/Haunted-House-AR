using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireDragonMove : MonoBehaviour
{
    private NavMeshAgent fDragonNavMeshAgent;
    private bool navMeshActive = false;
    private List<Transform> wayPoints;
    private Transform fireDragonStop1;
    private Transform fireDragonStop2;
    private Transform fireDragonStop3;
    private Transform fireDragonStop4;
    private Transform fireDragonStop5;
    private StateController fDragonStateController;

    // Start is called before the first frame update
    private void Start ( )
    {
        fDragonStateController = GetComponent<StateController> ( );
        wayPoints = new List<Transform> ( );
        fireDragonStop1 = GameObject.Find ( "Fire Dragon WayPoints" ).transform.Find ( "Fire Dragon Stop 1" );
        wayPoints.Add ( fireDragonStop1 );
        fireDragonStop2 = GameObject.Find ( "Fire Dragon WayPoints" ).transform.Find ( "Fire Dragon Stop 2" );
        wayPoints.Add ( fireDragonStop2 );
        fireDragonStop3 = GameObject.Find ( "Fire Dragon WayPoints" ).transform.Find ( "Fire Dragon Stop 3" );
        wayPoints.Add ( fireDragonStop3 );
        fireDragonStop4 = GameObject.Find ( "Fire Dragon WayPoints" ).transform.Find ( "Fire Dragon Stop 4" );
        wayPoints.Add ( fireDragonStop4 );
        fireDragonStop5 = GameObject.Find ( "Fire Dragon WayPoints" ).transform.Find ( "Fire Dragon Stop 5" );
        wayPoints.Add ( fireDragonStop5 );

        fDragonNavMeshAgent = GetComponent<NavMeshAgent> ( );

        if ( fDragonNavMeshAgent.gameObject != null && fDragonNavMeshAgent.isOnNavMesh )
        {
            navMeshActive = true;
            fDragonStateController.SetupAI ( navMeshActive , wayPoints );

        }

    }
}