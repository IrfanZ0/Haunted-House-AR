using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName = "PluggableAI/Decisions/Look" )]
public class LookDecision : Decision
{

    public override bool Decide ( StateController controller )
    {
        bool  targetVisible = Look(controller);

        return targetVisible;

    }

    private bool Look ( StateController controller )
    {
        RaycastHit hit;
        bool targetFound = false;

        Debug.DrawRay ( controller.eyes.position , controller.eyes.forward.normalized * controller.enemyStats.lookRange , Color.green );

        if ( Physics.SphereCast ( controller.eyes.position , controller.enemyStats.lookSphereCastRadius , controller.eyes.forward , out hit , controller.enemyStats.lookRange ) && hit.collider.CompareTag ( "Player" ) )
        {
            controller.chaseTarget = hit.transform;
            targetFound = true;
        }
        else
        {
            targetFound = false;

            if ( controller.navMeshAgent.gameObject.tag == "Lancer" )
            {
                controller.navMeshAgent.isStopped = false;
                controller.animator.SetFloat ( "Speed_Lancer" , 15f );
                controller.animator.SetFloat ( "Power_Lancer" , 0 );
                controller.navMeshAgent.gameObject.transform.Find ( "magic_ring_green" ).GetComponent<ParticleSystem> ( ).Stop ( true , ParticleSystemStopBehavior.StopEmittingAndClear );
                controller.navMeshAgent.gameObject.transform.Find ( "Green Bullets 9" ).GetComponent<ParticleSystem> ( ).Stop ( true , ParticleSystemStopBehavior.StopEmittingAndClear );
            }

            if ( controller.navMeshAgent.gameObject.tag == "Buba" )
            {
                if ( controller.navMeshAgent.gameObject.name == "Fire Buba" )
                {
                    controller.navMeshAgent.isStopped = false;
                    controller.animator.SetBool ( "Waliking_Fire_Buba" , true );
                }

                if ( controller.navMeshAgent.gameObject.name == "Ice Buba" )
                {
                    controller.navMeshAgent.isStopped = false;
                    controller.animator.SetBool ( "Walking Ice Buba" , true );
                }

                if ( controller.navMeshAgent.gameObject.name == "Lightning Buba" )
                {
                    controller.navMeshAgent.isStopped = false;
                    controller.animator.SetBool ( "Walking_Lightning_Buba" , true );

                }
            }

            if ( controller.navMeshAgent.gameObject.tag == "Bat" )
            {
                controller.navMeshAgent.isStopped = false;
                controller.animator.SetBool ( "Bat Fly" , true );
            }

        }

        return targetFound;

    }
}