using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu ( menuName = "PluggableAI/Decisions/Attack" )]
public class AttackStateDecision : Decision
{
    public override bool Decide ( StateController controller )
    {
        bool attackDecision = AttackDecision(controller);
        return attackDecision;
    }

    private bool AttackDecision ( StateController controller )
    {
        bool attack = false;
        NavMeshHit hit;

        //if ( controller.navMeshAgent.remainingDistance < controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending )
        // {
        if ( controller.navMeshAgent.Raycast ( controller.chaseTarget.position , out hit ) )
        {
            if ( hit.distance < 1.0f )
            {
                attack = true;
            }
        }
        // }

        return attack;

    }

}