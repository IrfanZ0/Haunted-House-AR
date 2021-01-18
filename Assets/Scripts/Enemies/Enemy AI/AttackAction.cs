using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act (StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {
        RaycastHit hit;
        LancerAttack lancerAttack = controller.gameObject.GetComponent<LancerAttack> ( ); ;

        float distanceToPlayer = Vector3.Distance(controller.navMeshAgent.transform.position, controller.chaseTarget.position);
      

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.attackRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.attackRange) && hit.collider.CompareTag("Player"))
        {
            if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate))
            {
                float power;

                if (distanceToPlayer > 0 && distanceToPlayer < 1f)
                {
                    power = 20f;
                    lancerAttack.Attack ( power);
                  
                }

                else if ( distanceToPlayer >= 1f && distanceToPlayer < 2f)
                {
                    power = 40f;
                    lancerAttack.Attack ( power);
                   
                }

                else if ( distanceToPlayer > 2f && distanceToPlayer < 3f)
                {
                    power = 60f;
                    lancerAttack.Attack ( power);
                }

               else
               {
                    power = 0;
                    
               }

            }
        }
    }
}
