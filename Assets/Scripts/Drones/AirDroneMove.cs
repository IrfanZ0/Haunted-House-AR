using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AirDroneMove : MonoBehaviour
{
    NavMeshAgent airDroneNavAgent;
    GameObject[] diamonds;
   

    [HideInInspector]
    public int jewelNum;

    // Start is called before the first frame update
    void Start()
    {
        airDroneNavAgent = GetComponent<NavMeshAgent>();
        jewelNum = 0;
        diamonds = GameObject.FindGameObjectsWithTag("Treasure");

        GoToNextJewel();

        
    }

    void GoToNextJewel()
    {
        if (diamonds.Length == 0)
            return;

        airDroneNavAgent.velocity = new Vector3(0.1f, 0.3f, 0.1f);
        airDroneNavAgent.destination = diamonds[jewelNum].transform.position;
        airDroneNavAgent.isStopped = false;

        jewelNum = (jewelNum + 1) % diamonds.Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (airDroneNavAgent.remainingDistance < 0.5f && !airDroneNavAgent.pathPending)
        {
            GoToNextJewel();

        }

    }
}
