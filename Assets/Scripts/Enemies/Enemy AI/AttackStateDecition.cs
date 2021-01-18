using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "PluggableAI/Decisions/Attack")]
public class AttackStateDecition : Decision
{
    public override bool Decide ( StateController controller )
    {
        bool attackDecision = AttackDecision(controller);
        return attackDecision;
    }

    private bool AttackDecision ( StateController controller )
    {
        throw new NotImplementedException ( );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
