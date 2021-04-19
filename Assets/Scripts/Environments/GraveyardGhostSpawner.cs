using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GraveyardGhostSpawner : MonoBehaviour
{
    public GameObject ghostGO;
    private GameObject ghost;

    private void OnTriggerEnter ( Collider other )
    {
        if ( other.CompareTag ( "Player" ) )
        {
            SpawnGhost ( );

        }
    }

    private void OnTriggerExit ( Collider other )
    {
        if ( other.CompareTag ( "Player" ) )
        {
            if ( ghost != null )
            {
                NavMeshAgent ghostAgent = ghost.GetComponent<NavMeshAgent>();
                ghostAgent.destination = other.transform.position;
            }
        }
    }

    private void SpawnGhost ( )
    {
        if ( ghost != null )
        {
            Destroy ( ghost.gameObject , 2f );
        }

        ghost = Instantiate ( ghostGO ) as GameObject;
        ghost.transform.parent = transform;
        ghost.transform.position = transform.position;
        ghost.transform.localScale = new Vector3 ( 0.2f , 0.2f , 0.2f );
        ghost.SetActive ( true );
    }
}