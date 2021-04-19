using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu ( menuName = "PluggableAI/Actions/Attack2" )]
public class AttackAction2 : Action
{
    public override void Act ( StateController controller )
    {
        Attack2 ( controller );
    }

    private void Attack2 ( StateController controller )
    {
        RaycastHit hit;

        float distanceToPlayer = Vector3.Distance(controller.navMeshAgent.transform.position, controller.chaseTarget.position);

        Debug.DrawRay ( controller.eyes.position , controller.eyes.forward.normalized * controller.enemyStats.attackRange , Color.red );

        if ( Physics.SphereCast ( controller.eyes.position , controller.enemyStats.lookSphereCastRadius , controller.eyes.forward , out hit , controller.enemyStats.attackRange ) && hit.collider.CompareTag ( "Player" ) )
        {

            if ( controller.CheckIfCountDownElapsed ( controller.enemyStats.attackRate ) )
            {
                string navMeshAgentName = controller.navMeshAgent.gameObject.tag;

                switch ( navMeshAgentName )
                {
                    case "Lancer":
                        {
                            float lancerHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;

                            if ( distanceToPlayer >= 0.3f && distanceToPlayer < 0.6f && lancerHealth >= 30f && lancerHealth < 60f )
                            {
                                controller.navMeshAgent.isStopped = true;
                                controller.animator.SetFloat ( "Speed_Lancer" , 0 );
                                controller.animator.SetFloat ( "Power_Lancer" , lancerHealth );
                                controller.navMeshAgent.gameObject.transform.Find ( "magic_ring_green" ).GetComponent<ParticleSystem> ( ).Play ( true );
                                controller.animator.SetTrigger ( "Attack2_Lancer" );
                                controller.navMeshAgent.gameObject.transform.Find ( "Green Bullets 9" ).GetComponent<ParticleSystem> ( ).Play ( true );
                            }

                            break;
                        }
                    case "Ghost":
                        {
                            float currentHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;
                            float totalHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().maxValue;
                            float power = currentHealth / totalHealth;

                            if ( power >= 0.3f && power < 0.6f )
                            {
                                controller.navMeshAgent.isStopped = true;
                                controller.animator.SetFloat ( "Power_Ghost" , 0.5f );
                                controller.animator.SetTrigger ( "Attack2_Ghost" );
                                ParticleSystem psSonic = controller.navMeshAgent.gameObject.transform.Find ( "Proj01_sonic" ).GetComponent<ParticleSystem> ( );
                                if ( !psSonic.isPlaying )
                                {
                                    psSonic.Play ( );
                                }
                            }

                            break;
                        }
                    case "Dragon":
                        {
                            if ( controller.navMeshAgent.gameObject.name == "Baby Ice Dragon" )
                            {
                                if ( distanceToPlayer >= 0.5f )
                                {
                                    controller.animator.SetBool ( "Flying" , true );
                                    controller.animator.SetTrigger ( "breath ice" );
                                }

                            }
                            if ( controller.navMeshAgent.gameObject.name == "Baby Fire Dragon" )
                            {
                                if ( distanceToPlayer >= 0.5f )
                                {
                                    controller.animator.SetBool ( "isFlying" , true );
                                    controller.animator.SetTrigger ( "breath Fire" );
                                }

                            }
                            break;
                        }
                    case "Demon":
                        {
                            float currentHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;
                            float totalHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().maxValue;
                            float power = currentHealth / totalHealth;

                            if ( power >= 0.25f && power < 0.5f && distanceToPlayer > 0.25f && distanceToPlayer <= 0.5f )
                            {
                                controller.navMeshAgent.isStopped = true;
                                controller.animator.SetTrigger ( "Attack2_Demon_Lord" );
                                controller.animator.SetFloat ( "Power_Demon_Lord" , 0.3f );
                            }

                            break;
                        }

                    case "Bat":
                        {
                            if ( distanceToPlayer >= 0.5f && distanceToPlayer <= 1.0f )
                            {
                                controller.navMeshAgent.isStopped = true;
                                controller.animator.SetBool ( "Bat Fly" , false );
                                controller.animator.SetTrigger ( "Bat Attack 2" );
                            }
                            break;

                        }

                }
            }

        }
    }

}