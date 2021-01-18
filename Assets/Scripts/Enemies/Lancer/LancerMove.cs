using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LancerMove : MonoBehaviour
{
    NavMeshAgent lancerNavMeshAgent;
    private bool navMeshActive = false;
    List<Transform> wayPoints;
    Transform lancerWayPoint1;
    Transform lancerWayPoint2;
    Transform lancerWayPoint3;
    Transform lancerWayPoint4;
    Transform lancerWayPoint5;
    StateController lancerStateController;
  

    // Start is called before the first frame update
    void Start()
    {
        lancerStateController = GetComponent<StateController>();
        wayPoints = new List<Transform>();
        lancerWayPoint1 = GameObject.Find ( "Door Of Doom 1" ).transform.Find ( "Enemy WayPoint 1" );
        wayPoints.Add ( lancerWayPoint1 );
        lancerWayPoint2 = GameObject.Find ( "Door Of Doom 1" ).transform.Find ( "Enemy WayPoint 2" );
        wayPoints.Add ( lancerWayPoint2 );
        lancerWayPoint3 = GameObject.Find ( "Door Of Doom 1" ).transform.Find ( "Enemy WayPoint 3" );
        wayPoints.Add ( lancerWayPoint3 );
        lancerWayPoint4 = GameObject.Find ( "Door Of Doom 1" ).transform.Find ( "Enemy WayPoint 4" );
        wayPoints.Add ( lancerWayPoint4 );
        lancerWayPoint5 = GameObject.Find ( "Door Of Doom 1" ).transform.Find ( "Enemy WayPoint 5" );
        wayPoints.Add ( lancerWayPoint5 );
    

        lancerNavMeshAgent = GetComponent<NavMeshAgent>();

        if (lancerNavMeshAgent.gameObject != null && lancerNavMeshAgent.isOnNavMesh && wayPoints != null)
        {
            navMeshActive = true;
            lancerStateController.SetupAI(navMeshActive, wayPoints);
            

        }

    
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
