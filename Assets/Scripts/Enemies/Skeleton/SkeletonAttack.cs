using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAttack : MonoBehaviour {
    
    Animator skeletonAnim;
    NavMeshAgent skeletonNavMesh;

	// Use this for initialization
	void Start () {

        skeletonAnim = GetComponent<Animator>();
        skeletonNavMesh = GetComponent<NavMeshAgent>();
		
	}

    public void Attack()
    {
        skeletonNavMesh.velocity = Vector3.zero;
        skeletonAnim.SetTrigger("Attack");
    }
	
	
}
