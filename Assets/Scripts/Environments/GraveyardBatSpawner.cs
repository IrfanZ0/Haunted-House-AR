using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardBatSpawner : MonoBehaviour
{
    public GameObject batGO;
    private GameObject bat;

    private void OnTriggerEnter ( Collider other )
    {
        if ( other.CompareTag ( "Player" ) )
        {
            SpawnBat ( );
        }
    }

    private void SpawnBat ( )
    {
        if ( bat != null )
        {
            Destroy ( bat.gameObject , 2f );
        }

        bat = Instantiate ( batGO , transform.position , transform.rotation ) as GameObject;
        bat.SetActive ( true );
    }
}