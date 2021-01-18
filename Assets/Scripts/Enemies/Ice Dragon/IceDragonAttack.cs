using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceDragonAttack : MonoBehaviour
{
    Animator iDragonAnim;
    NavMeshAgent iDragonNavMesh;
    float distance;
    GameObject player;

    // Use this for initialization
    void Start()
    {

        iDragonAnim = GetComponent<Animator>();
        iDragonNavMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Attack()
    {
        iDragonNavMesh.velocity = Vector3.zero;
        iDragonAnim.SetBool("Flying", true);
        distance = Vector3.Distance(iDragonNavMesh.gameObject.transform.position, player.transform.position);

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
        iDragonAnim.SetTrigger("breath ice");
    }

    private void FlyHit()
    {
        iDragonAnim.SetTrigger("hit");

    }

    private void FlyAttack()
    {
        iDragonAnim.SetTrigger("head butt");
    }
}
