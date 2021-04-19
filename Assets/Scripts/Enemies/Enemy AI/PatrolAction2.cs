using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu ( menuName = "PluggableAI/Actions/Patrol2" )]
public class PatrolAction2 : Action
{
    public override void Act ( StateController controller )
    {
        Patrol2 ( controller );
    }

    private void Patrol2 ( StateController controller )
    {
        if ( controller.navMeshAgent.remainingDistance < controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending )
        {

            controller.animator.SetFloat ( "Speed" , 15.0f );
            controller.nextWayPoint = ( controller.nextWayPoint + 1 ) % controller.wayPointList2.Count;
            controller.navMeshAgent.SetDestination ( controller.wayPointList2 [ controller.nextWayPoint + 1 ].position );

        }
    }
}
