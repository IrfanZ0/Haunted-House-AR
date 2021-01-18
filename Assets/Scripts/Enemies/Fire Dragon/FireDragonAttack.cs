using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireDragonAttack : MonoBehaviour
{
    Animator fDragonAnim;
    NavMeshAgent fDragonNavMesh;
    float distance;
    GameObject player;

    // Use this for initialization
    void Start()
    {

        fDragonAnim = GetComponent<Animator>();
        fDragonNavMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Attack()
    {
        fDragonNavMesh.velocity = Vector3.zero;
        fDragonAnim.SetBool("isFlying", true);
        distance = Vector3.Distance(fDragonNavMesh.gameObject.transform.position, player.transform.position);

        if (distance >= 1f)
        {
            BreathFire();
        }

        else if (distance > 0.5f && distance < 1)
        {
            FlyAttack();
        }

        else
        {
            FlyHit();
        }

    }

    private void BreathFire()
    {
        fDragonAnim.SetTrigger("breath Fire");
    }

    private void FlyHit()
    {
        fDragonAnim.SetTrigger("hit");

    }

    private void FlyAttack()
    {
        fDragonAnim.SetTrigger("attack");
    }
}
