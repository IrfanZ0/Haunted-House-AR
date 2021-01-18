using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightningBubaAttack : MonoBehaviour
{
    NavMeshAgent lBubaNavMeshAgent;
    LightningBlast lightningBlast;
    // Start is called before the first frame update
    void Start()
    {
        lightningBlast = transform.Find("Lightning Spot").gameObject.GetComponent<LightningBlast>();
        lBubaNavMeshAgent = GetComponent<NavMeshAgent>();

    }


    public void Attack()
    {
        lBubaNavMeshAgent.velocity = Vector3.zero;
        lightningBlast.Fire();

    }
}
