using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.LightningBolt;

[CreateAssetMenu ( menuName = "PluggableAI/Actions/Attack3" )]
public class AttackAction3 : Action
{
    public override void Act ( StateController controller )
    {
        Attack3 ( controller );
    }

    private void Attack3 ( StateController controller )
    {
        RaycastHit hit;

        float distanceToPlayer = Vector3.Distance(controller.navMeshAgent.transform.position, controller.chaseTarget.position);

        Debug.DrawRay ( controller.eyes.position , controller.eyes.forward.normalized * controller.enemyStats.attackRange , Color.red );

        if ( Physics.SphereCast ( controller.eyes.position , controller.enemyStats.lookSphereCastRadius , controller.eyes.forward , out hit , controller.enemyStats.attackRange ) && hit.collider.CompareTag ( "Player" ) )
        {
            string navMeshAgentName = controller.navMeshAgent.gameObject.tag;

            switch ( navMeshAgentName )
            {
                case "Lancer":
                    {
                        float lancerHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;

                        if ( distanceToPlayer >= 0.6f && lancerHealth >= 0 && lancerHealth < 30f )
                        {
                            controller.navMeshAgent.isStopped = true;
                            controller.animator.SetFloat ( "Speed_Lancer" , 0 );
                            controller.animator.SetFloat ( "Power_Lancer" , lancerHealth );
                            controller.navMeshAgent.gameObject.transform.Find ( "magic_ring_yellow" ).GetComponent<ParticleSystem> ( ).Play ( true );
                            controller.animator.SetTrigger ( "Attack3_Lancer" );
                            controller.navMeshAgent.gameObject.transform.Find ( "yellow surge" ).GetComponent<ParticleSystem> ( ).Play ( true );
                        }

                        break;
                    }

                case "Buba":
                    {
                        if ( controller.navMeshAgent.gameObject.name == "Fire Buba" )
                        {
                            controller.animator.SetBool ( "Walking_Fire_Buba" , false );
                            controller.animator.SetTrigger ( "Attack_Fire_Buba" );

                        }

                        if ( controller.navMeshAgent.gameObject.name == "Ice Buba" )
                        {
                            controller.animator.SetBool ( "Walking_Ice_Buba" , false );
                            controller.animator.SetTrigger ( "Attack_Ice_Buba" );
                        }

                        if ( controller.navMeshAgent.gameObject.name == "Lightning Buba" )
                        {
                            controller.animator.SetBool ( "Walking_Lightning_Buba" , false );
                            controller.animator.SetTrigger ( "Attack_Lightning_Buba" );
                            LightningBoltScript lBoltScript = controller.navMeshAgent.gameObject.transform.Find("Lightning Spot").transform.Find("SimpleLightningBoltPrefab").GetComponent<LightningBoltScript>();
                            lBoltScript.Trigger ( );

                        }

                        break;
                    }
                case "Ghost":
                    {
                        float currentHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;
                        float totalHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().maxValue;
                        float power = currentHealth / totalHealth;

                        if ( power >= 0.6f && power <= 1f )
                        {
                            controller.navMeshAgent.isStopped = true;
                            controller.animator.SetFloat ( "Power_Ghost" , 1f );
                            controller.animator.SetTrigger ( "Attack3_Ghost" );
                            ParticleSystem psPrismatic = controller.navMeshAgent.gameObject.transform.Find ( "Proj01_prismatic" ).GetComponent<ParticleSystem> ( );
                            if ( !psPrismatic.isPlaying )
                            {
                                psPrismatic.Play ( );
                            }

                        }

                        break;
                    }

                case "Demon":
                    {
                        float currentHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().value;
                        float totalHealth = controller.navMeshAgent.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>().maxValue;
                        float power = currentHealth / totalHealth;

                        if ( power >= 0.5f && power < 0.75f && distanceToPlayer > 0.5f && distanceToPlayer <= 0.75f )
                        {
                            controller.navMeshAgent.isStopped = true;
                            controller.animator.SetTrigger ( "Attack3_Demon_Lord" );
                            controller.animator.SetFloat ( "Power_Demon_Lord" , 0.6f );
                        }

                        break;
                    }

            }

        }

    }
}