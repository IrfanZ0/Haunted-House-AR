﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu ( menuName = "PluggableAI/Actions/Attack" )]
public class AttackAction : Action
{
    public override void Act ( StateController controller )
    {
        Attack ( controller );
    }

    private void Attack ( StateController controller )
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

                            if ( distanceToPlayer < 0.3f && lancerHealth >= 60f && lancerHealth < 90f )
                            {
                                controller.navMeshAgent.isStopped = true;
                                controller.animator.SetFloat ( "Speed_Lancer" , 0 );
                                controller.animator.SetFloat ( "Power_Lancer" , lancerHealth );
                                controller.animator.SetTrigger ( "Attack1_Lancer" );
                            }

                            break;
                        }
                    case "Ghost":
                        {
                            float currentHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;
                            float totalHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().maxValue;
                            float power = currentHealth / totalHealth;

                            if ( power > 0 && power < 0.3f )
                            {
                                controller.navMeshAgent.isStopped = true;
                                controller.animator.SetFloat ( "Power_Ghost" , 0.1f );
                                controller.animator.SetTrigger ( "Attack1_Ghost" );
                                ParticleSystem psVoid = controller.navMeshAgent.gameObject.transform.Find ( "Proj01_void" ).GetComponent<ParticleSystem> ( );
                                if ( !psVoid.isPlaying )
                                {
                                    psVoid.Play ( );
                                }
                            }

                            break;
                        }
                    case "Dragon":
                        {

                            if ( controller.navMeshAgent.gameObject.name == "Baby Ice Dragon" )
                            {
                                if ( distanceToPlayer < 0.5f )
                                {
                                    controller.animator.SetBool ( "Flying" , true );
                                    controller.animator.SetTrigger ( "head butt" );
                                }

                            }
                            if ( controller.navMeshAgent.gameObject.name == "Baby Fire Dragon" )
                            {
                                if ( distanceToPlayer < 0.5f )
                                {
                                    controller.animator.SetBool ( "isFlying" , true );
                                    controller.animator.SetTrigger ( "attack" );
                                }

                            }

                            break;
                        }
                    case "Demon":
                        {
                            float currentHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;
                            float totalHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().maxValue;
                            float power = currentHealth / totalHealth;

                            if ( power > 0 && power < 0.25f && distanceToPlayer <= 0.25f )
                            {
                                controller.navMeshAgent.isStopped = true;
                                controller.animator.SetTrigger ( "Attack1_Demon_Lord" );
                                controller.animator.SetFloat ( "Power_Demon_Lord" , 0.1f );
                            }

                            break;
                        }

                    case "Skeleton":
                        {
                            controller.navMeshAgent.isStopped = true;
                            controller.animator.SetBool ( "isWalking_Skeleton" , false );
                            controller.animator.SetFloat ( "Speed_Skeleton" , 0 );
                            controller.animator.SetTrigger ( "Attack_Skeleton" );

                            break;
                        }

                    case "Bat":
                        {
                            if ( distanceToPlayer < 0.5f )
                            {
                                controller.navMeshAgent.isStopped = true;
                                controller.animator.SetBool ( "Bat Fly" , false );
                                controller.animator.SetTrigger ( "Bat Attack 1" );
                            }
                            break;

                        }
                }

            }
        }

    }

}