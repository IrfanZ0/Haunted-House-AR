using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu ( menuName = "PluggableAI/Actions/Attack4" )]
public class AttackAction4 : Action
{
    public override void Act ( StateController controller )
    {
        Attack4 ( controller );
    }

    private void Attack4 ( StateController controller )
    {
        RaycastHit hit;

        float distanceToPlayer = Vector3.Distance(controller.navMeshAgent.transform.position, controller.chaseTarget.position);

        Debug.DrawRay ( controller.eyes.position , controller.eyes.forward.normalized * controller.enemyStats.attackRange , Color.red );

        if ( Physics.SphereCast ( controller.eyes.position , controller.enemyStats.lookSphereCastRadius , controller.eyes.forward , out hit , controller.enemyStats.attackRange ) && hit.collider.CompareTag ( "Player" ) )
        {
            string navMeshAgentName = controller.navMeshAgent.gameObject.tag;

            switch ( navMeshAgentName )
            {

                case "Demon":
                    {
                        float currentHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;
                        float totalHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().maxValue;
                        float power = currentHealth / totalHealth;

                        if ( power >= 0.75f && power <= 1.0f && distanceToPlayer > 0.75f && distanceToPlayer <= 1.0f )
                        {
                            controller.navMeshAgent.isStopped = true;
                            controller.animator.SetTrigger ( "Attack4_Demon_Lord" );
                            controller.animator.SetFloat ( "Power_Demon_Lord" , 0.6f );
                        }

                        break;
                    }

            }

        }

    }

}