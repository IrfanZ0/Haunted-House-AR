using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName = "PluggableAI/Actions/Patrol" )]
public class PatrolAction : Action
{
    private float power;

    public override void Act ( StateController controller )
    {
        Patrol ( controller );

    }

    private void Patrol ( StateController controller )
    {
        controller.navMeshAgent.destination = controller.wayPointList [ controller.nextWayPoint ].position;
        controller.navMeshAgent.isStopped = false;
        Vector3 direction = (  controller.wayPointList [ controller.nextWayPoint ].position - controller.navMeshAgent.gameObject.transform.position).normalized;
        Quaternion lookDirection = Quaternion.LookRotation(direction);
        controller.navMeshAgent.gameObject.transform.rotation = Quaternion.RotateTowards ( controller.navMeshAgent.gameObject.transform.rotation , lookDirection , 360f );

        if ( controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending )
        {

            //controller.animator.SetFloat ( "Speed" , 15.0f );
            controller.nextWayPoint = ( controller.nextWayPoint + 1 ) % controller.wayPointList.Count;

        }
    }

}