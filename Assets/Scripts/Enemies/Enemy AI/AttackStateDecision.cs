using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "PluggableAI/Decisions/Attack")]
public class AttackStateDecision : Decision
{
    public override bool Decide ( StateController controller )
    {
        bool attackDecision = AttackDecision(controller);
        return attackDecision;
    }

    private bool AttackDecision ( StateController controller )
    {
        
        float distanceToPlayer = Vector3.Distance(controller.navMeshAgent.transform.position, controller.chaseTarget.position);
       

        if ( distanceToPlayer < 1.0f)
        {
           
            return true;
        }

        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
