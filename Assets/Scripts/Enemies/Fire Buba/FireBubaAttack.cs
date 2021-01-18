using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBubaAttack : MonoBehaviour
{
    NavMeshAgent fBubaNavMeshAgent;
    FireBlast fireBlast;
    // Start is called before the first frame update
    void Start()
    {
        fireBlast = transform.Find("Fire Spot").gameObject.GetComponent<FireBlast>();
        fBubaNavMeshAgent = GetComponent<NavMeshAgent>();

    }

   
    public void Attack()
    {
        fBubaNavMeshAgent.velocity = Vector3.zero;
        fireBlast.Fire();
        
    }
}
