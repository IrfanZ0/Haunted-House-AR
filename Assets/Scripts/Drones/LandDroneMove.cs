using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LandDroneMove : MonoBehaviour
{
    NavMeshAgent landDroneNavAgent;
    GameObject[] diamonds;
    Animator landDroneAnim;


    [HideInInspector]
    public int jewelNum;

    // Start is called before the first frame update
    void Start()
    {
        landDroneNavAgent = GetComponent<NavMeshAgent>();
        jewelNum = 0;
        diamonds = GameObject.FindGameObjectsWithTag("Treasure");
        landDroneAnim = GetComponent<Animator>();
        landDroneAnim.SetBool("isWalking", false);
        GoToNextJewel();


    }

    void GoToNextJewel()
    {
        if (diamonds.Length == 0)
            return;

        landDroneNavAgent.velocity = new Vector3(0.1f, 0.3f, 0.1f);
        landDroneNavAgent.destination = diamonds[jewelNum].transform.position;
        landDroneNavAgent.isStopped = false;
        landDroneAnim.SetBool("isWalking", true);

        jewelNum = (jewelNum + 1) % diamonds.Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (landDroneNavAgent.remainingDistance < 0.5f && !landDroneNavAgent.pathPending)
        {
            GoToNextJewel();

        }

    }
}
