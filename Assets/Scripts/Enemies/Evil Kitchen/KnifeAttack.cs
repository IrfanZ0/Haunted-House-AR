using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnifeAttack : MonoBehaviour
{
    NavMeshAgent knifeMeshAgent;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        knifeMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        knifeMeshAgent.SetDestination(player.transform.position);
        
    }
}
