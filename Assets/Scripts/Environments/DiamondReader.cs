using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondReader : MonoBehaviour
{
    public List<GameObject> doors;
    AudioSource doorOpeningMusic;

    // Start is called before the first frame update
    void Start()
    {
        doors = new List<GameObject> ( );
        doorOpeningMusic = GetComponent<AudioSource> ( );
    }

    private void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.CompareTag ( "Treasure" ) )
        {
            string altarName = gameObject.transform.parent.name;
            string diamondName = other.gameObject.name;

            switch ( diamondName )
            {
                case "Blue Diamond":
                    {
                        DoorOpener ( altarName , doors );
                        break;
                    }
                case "Orange Diamond":
                    {
                        DoorOpener ( altarName , doors );
                        break;
                    }
                case "Red Diamond":
                    {
                        DoorOpener ( altarName , doors );
                        break;
                    }
                case "Silver Diamond":
                    {
                        DoorOpener ( altarName , doors );
                        break;
                    }
                case "Yellow Diamond":
                    {
                        DoorOpener ( altarName , doors );
                        break;
                    }

            }
        }

    }

    private void OnTriggerExit ( Collider other )
    {
        if (other.gameObject.CompareTag("Treasure"))
        {
            StartCoroutine ( SelfDestruct ( other.gameObject ) );
        }
    }

    IEnumerator SelfDestruct ( GameObject diamond )
    {
        yield return new WaitForSeconds ( 3f );
        Destroy ( diamond.gameObject , 2f );

    }

    private void DoorOpener ( string altarName , List<GameObject> doors )
    {
        if (!doorOpeningMusic.isPlaying)
        {
            doorOpeningMusic.Play ( );
        }

        if (altarName.Equals("altar"))
        {
            doors [ 0 ].transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );

        }
        else if ( altarName.Equals ( "altar 1" ) )
        {
            doors [ 1 ].transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );
        }
        else if ( altarName.Equals ( "altar 2" ) )
        {
            doors [ 2 ].transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );
        }
        else if ( altarName.Equals ( "altar 3" ) )
        {
            doors [ 3 ].transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );
        }
        else if ( altarName.Equals ( "altar 4" ) )
        {
            doors [ 4 ].transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );
        }
        else if ( altarName.Equals ( "altar 5" ) )
        {
            doors [ 5 ].transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );
        }
    }
}
