using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondReader : MonoBehaviour
{
    private GameObject doorOfDoomRoom;
    private GameObject door0;
    private GameObject door1;
    private GameObject door2;
    private GameObject door3;
    private GameObject door4;
    private GameObject door5;
    private List<GameObject> doors;
    private AudioSource doorOpeningMusic;
    private string altarName;
    private bool hasScanned;
    public GameObject ghostGO;
    private GameObject ghost;
    public GameObject batGO;
    private GameObject bat;
    public GameObject spiderGO;
    private GameObject spider;
    public GameObject skeletonGO;
    private GameObject skeleton;
    public GameObject lightningBubaGO;
    private GameObject lightningBuba;
    public GameObject puzzlePortalGO;
    private GameObject puzzlePortal;
    public GameObject treasureBoxGO;
    private GameObject treasureBox;
    private List<GameObject> doorItems;
    private Transform arCameraTransform;
    private Transform [ ] secretRoomSpots;
    private Transform door1Spot;
    private Transform door2Spot;
    private Transform door3Spot;
    private Transform door4Spot;
    private Transform door5Spot;

    // Start is called before the first frame update
    private void Start ( )
    {
        door1Spot = GameObject.Find ( "Door 0 Spot" ).transform;
        door2Spot = GameObject.Find ( "Door 1 Spot" ).transform;
        door3Spot = GameObject.Find ( "Door 2 Spot" ).transform;
        door4Spot = GameObject.Find ( "Door 3 Spot" ).transform;
        door5Spot = GameObject.Find ( "Door 4 Spot" ).transform;
        secretRoomSpots = new Transform [ ] { door1Spot , door2Spot , door3Spot , door4Spot , door5Spot };
        arCameraTransform = GameObject.FindGameObjectWithTag ( "Player" ).transform;
        hasScanned = false;
        doors = new List<GameObject> ( );
        doorOfDoomRoom = GameObject.Find ( "Door Of Doom" );
        door0 = doorOfDoomRoom.transform.Find ( "door00" ).gameObject;
        doors.Add ( door0 );
        door1 = doorOfDoomRoom.transform.Find ( "door01" ).gameObject;
        doors.Add ( door1 );
        door2 = doorOfDoomRoom.transform.Find ( "door02" ).gameObject;
        doors.Add ( door2 );
        door3 = doorOfDoomRoom.transform.Find ( "door03" ).gameObject;
        doors.Add ( door3 );
        door4 = doorOfDoomRoom.transform.Find ( "door04" ).gameObject;
        doors.Add ( door4 );
        door5 = doorOfDoomRoom.transform.Find ( "door05" ).gameObject;
        doors.Add ( door5 );
        doorOpeningMusic = GetComponent<AudioSource> ( );
        DoorCloser ( );

        doorItems = new List<GameObject> ( );

        doorItems.Add ( SpawnBat ( arCameraTransform ) );
        doorItems.Add ( SpawnGhost ( arCameraTransform ) );
        doorItems.Add ( SpawnLightningBuba ( arCameraTransform ) );
        doorItems.Add ( SpawnPuzzlePortal ( arCameraTransform ) );
        doorItems.Add ( SpawnSkeleton ( arCameraTransform ) );
        doorItems.Add ( SpawnSpider ( arCameraTransform ) );
        doorItems.Add ( SpawnTreasureBox ( arCameraTransform ) );
    }

    private void DoorItemPlacer ( GameObject doorItem , Transform [ ] secretRoomSpots )
    {
        foreach ( var secretSpot in secretRoomSpots )
        {
            if ( secretSpot == null )
            {
                doorItem.transform.position = secretSpot.position;
            }

        }
    }

    private void OnTriggerExit ( Collider other )
    {
        if ( other.gameObject.CompareTag ( "Treasure" ) )
        {
            StartCoroutine ( SelfDestruct ( other.gameObject ) );
        }
    }

    private GameObject SpawnPuzzlePortal ( Transform puzzlePortalSpot )
    {
        if ( puzzlePortal != null )
        {
            Destroy ( puzzlePortal.gameObject , 2f );
        }

        puzzlePortal = Instantiate ( puzzlePortalGO , puzzlePortalSpot.position , puzzlePortalSpot.rotation ) as GameObject;
        puzzlePortal.SetActive ( false );

        return puzzlePortal;

    }

    private GameObject SpawnLightningBuba ( Transform lightningBubaSpot )
    {
        if ( lightningBuba != null )
        {
            Destroy ( lightningBuba.gameObject , 2f );
        }

        lightningBuba = Instantiate ( lightningBubaGO , lightningBubaSpot.position , lightningBubaSpot.rotation ) as GameObject;
        lightningBuba.SetActive ( false );

        return lightningBuba;

    }

    private GameObject SpawnSpider ( Transform spiderSpot )
    {
        if ( spider != null )
        {
            Destroy ( spider.gameObject , 2f );
        }

        spider = Instantiate ( spiderGO , spiderSpot.position , spiderSpot.rotation ) as GameObject;
        spider.SetActive ( false );

        return spider;

    }

    private GameObject SpawnBat ( Transform batSpot )
    {
        if ( bat != null )
        {
            Destroy ( bat.gameObject , 2f );
        }

        bat = Instantiate ( batGO , batSpot.position , batSpot.rotation ) as GameObject;
        bat.SetActive ( false );

        return bat;
    }

    private GameObject SpawnGhost ( Transform ghostSpot )
    {
        if ( ghost != null )
        {
            Destroy ( ghost.gameObject , 2f );
        }

        ghost = Instantiate ( ghostGO , ghostSpot.position , ghostSpot.rotation ) as GameObject;
        ghost.SetActive ( false );

        return ghost;
    }

    private GameObject SpawnTreasureBox ( Transform treasureBoxSpot )
    {
        if ( treasureBox != null )
        {
            Destroy ( treasureBox.gameObject , 2f );
        }

        treasureBox = Instantiate ( treasureBoxGO , treasureBoxSpot.position , treasureBoxSpot.rotation ) as GameObject;
        treasureBox.SetActive ( false );

        return treasureBox;
    }

    private GameObject SpawnSkeleton ( Transform skeletonSpot )
    {
        if ( skeleton != null )
        {
            Destroy ( skeleton.gameObject , 2f );
        }

        skeleton = Instantiate ( skeletonGO , skeletonSpot.position , skeletonSpot.rotation ) as GameObject;
        skeleton.SetActive ( false );

        return skeleton;
    }

    private void DoorCloser ( )
    {
        doors [ 0 ].GetComponent<Animator> ( ).SetBool ( "Door00_isOpen" , false );
        doors [ 1 ].GetComponent<Animator> ( ).SetBool ( "Door01_isOpen" , false );
        doors [ 2 ].GetComponent<Animator> ( ).SetBool ( "Door02_isOpen" , false );
        doors [ 3 ].GetComponent<Animator> ( ).SetBool ( "Door03_isOpen" , false );
        doors [ 4 ].GetComponent<Animator> ( ).SetBool ( "Door04_isOpen" , false );
        doors [ 5 ].GetComponent<Animator> ( ).SetBool ( "Door05_isOpen" , false );
    }

    private IEnumerator SelfDestruct ( GameObject diamond )
    {
        yield return new WaitForSeconds ( 15f );
        Destroy ( diamond.gameObject , 2f );
        DoorCloser ( );

    }

    private void DoorOpener ( string altarName , List<GameObject> doors )
    {
        int randomItemNumber = 0;

        if ( !doorOpeningMusic.isPlaying )
        {
            doorOpeningMusic.Play ( );
        }

        if ( altarName == "altar 0" && hasScanned && gameObject.transform.childCount > 0 )
        {
            doors [ 0 ].GetComponent<Animator> ( ).SetBool ( "Door00_isOpen" , true );
        }
        else
        {
            doors [ 0 ].GetComponent<Animator> ( ).SetBool ( "Door00_isOpen" , false );
            randomItemNumber = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , doorItems.Count - 1 ) );

            DoorItemPlacer ( doorItems [ randomItemNumber ] , secretRoomSpots );

        }

        if ( altarName.Equals ( "altar 1" ) && hasScanned && gameObject.transform.childCount > 0 )
        {
            doors [ 1 ].GetComponent<Animator> ( ).SetBool ( "Door01_isOpen" , true );

        }
        else
        {
            doors [ 1 ].GetComponent<Animator> ( ).SetBool ( "Door01_isOpen" , false );
            randomItemNumber = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , doorItems.Count - 1 ) );
            DoorItemPlacer ( doorItems [ randomItemNumber ] , secretRoomSpots );
        }

        if ( altarName.Equals ( "altar 2" ) && hasScanned && gameObject.transform.childCount > 0 )
        {
            doors [ 2 ].GetComponent<Animator> ( ).SetBool ( "Door02_isOpen" , true );
        }
        else
        {
            doors [ 2 ].GetComponent<Animator> ( ).SetBool ( "Door02_isOpen" , false );
            randomItemNumber = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , doorItems.Count - 1 ) );
            DoorItemPlacer ( doorItems [ randomItemNumber ] , secretRoomSpots );
        }

        if ( altarName.Equals ( "altar 3" ) && hasScanned && gameObject.transform.childCount > 0 )
        {
            doors [ 3 ].GetComponent<Animator> ( ).SetBool ( "Door03_isOpen" , true );
        }
        else
        {
            doors [ 3 ].GetComponent<Animator> ( ).SetBool ( "Door03_isOpen" , false );
            randomItemNumber = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , doorItems.Count - 1 ) );
            DoorItemPlacer ( doorItems [ randomItemNumber ] , secretRoomSpots );
        }

        if ( altarName.Equals ( "altar 4" ) && hasScanned && gameObject.transform.childCount > 0 )
        {
            doors [ 4 ].GetComponent<Animator> ( ).SetBool ( "Door04_isOpen" , true );
        }
        else
        {
            doors [ 4 ].GetComponent<Animator> ( ).SetBool ( "Door04_isOpen" , false );
            randomItemNumber = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , doorItems.Count - 1 ) );
            DoorItemPlacer ( doorItems [ randomItemNumber ] , secretRoomSpots );
        }

        if ( altarName.Equals ( "altar 5" ) && hasScanned && gameObject.transform.childCount > 0 )
        {
            doors [ 5 ].GetComponent<Animator> ( ).SetBool ( "Door05_isOpen" , true );
        }
        else
        {
            doors [ 5 ].GetComponent<Animator> ( ).SetBool ( "Door05_isOpen" , false );
            randomItemNumber = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , doorItems.Count - 1 ) );
            DoorItemPlacer ( doorItems [ randomItemNumber ] , secretRoomSpots );
        }
    }

}