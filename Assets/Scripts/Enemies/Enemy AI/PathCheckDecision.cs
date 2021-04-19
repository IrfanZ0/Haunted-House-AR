using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/PathCheck")]
public class PathCheckDecision : Decision
{
    public override bool Decide ( StateController controller )
    {
        bool pathDecision = PathDecision ( controller );
        return pathDecision;
    }

    private bool PathDecision ( StateController controller )
    {
        NavMeshPath path1 = new NavMeshPath();
        NavMeshPath path2 = new NavMeshPath();
        bool pathFound = false;

        if ( controller.navMeshAgent.remainingDistance < controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending )
        {
            if ( controller.navMeshAgent.CalculatePath ( controller.chaseTarget.position , path1 ) )
            {
                pathFound = true;
                controller.navMeshAgent.SetPath ( path1 );
            }
            else
            {
                pathFound = true;
                controller.navMeshAgent.SetPath ( path2 );
            }
        }

        return pathFound;
    }
}
