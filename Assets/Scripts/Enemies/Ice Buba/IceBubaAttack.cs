using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceBubaAttack : MonoBehaviour
{
    NavMeshAgent iBubaNavMeshAgent;
    IceBlast iceBlast;

    // Start is called before the first frame update
    void Start()
    {
        iceBlast = transform.Find("Ice Spot").gameObject.GetComponent<IceBlast>();
        iBubaNavMeshAgent = GetComponent<NavMeshAgent>();

    }


    public void Attack()
    {
        iBubaNavMeshAgent.velocity = Vector3.zero;
        iceBlast.Fire();

    }
}
