using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    float power;
    public override void Act(StateController controller)
    {
            Patrol ( controller );
         
    }


    private void Patrol(StateController controller)
    {
        controller.navMeshAgent.SetDestination(controller.wayPointList [ controller.nextWayPoint ].position);

       

        if (controller.navMeshAgent.remainingDistance < controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            controller.navMeshAgent.isStopped = true;
            controller.animator.SetFloat ( "Speed" , 5.0f );
            controller.navMeshAgent.autoBraking = true;
            LancerAttack lancerAttack = controller.navMeshAgent.gameObject.GetComponent<LancerAttack>();
            power = 20f;
            lancerAttack.Attack ( power );
            controller.navMeshAgent.ResetPath ( );
            power = 0;
            lancerAttack.Attack ( power );
            controller.animator.SetFloat ( "Power" , power );
            controller.navMeshAgent.isStopped = false;
            controller.animator.SetFloat ( "Speed" , 15.0f );
            controller.nextWayPoint = ( controller.nextWayPoint + 1 ) % controller.wayPointList.Count;
            controller.navMeshAgent.SetDestination ( controller.wayPointList [ controller.nextWayPoint + 1 ].position );



        }
    }

}
