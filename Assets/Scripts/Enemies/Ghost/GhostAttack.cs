using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAttack : MonoBehaviour
{
    Animator ghostAnim;
    NavMeshAgent ghostNavMesh;

    // Use this for initialization
    void Start()
    {

        ghostAnim = GetComponent<Animator>();
        ghostNavMesh = GetComponent<NavMeshAgent>();

    }

    public void Attack()
    {
        ghostNavMesh.velocity = Vector3.zero;
        ghostAnim.SetFloat("Speed", 0.3f);
        ghostAnim.SetBool("Visible", false);
        ghostAnim.SetBool("Visible", true);
        ghostAnim.SetTrigger("Steal Magic");
    }
}
