using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DoorOfDoomController : MonoBehaviour
{
    public Transform[] secretRoomSpots;
    public GameObject warpEnterPointGO;
    GameObject warpEnterPoint;
    List<GameObject> warpPoints;
    GameObject canvas;
    AudioSource hauntedMusic;
    GameObject player;
    ARRaycastManager ARRaycastManager;
    ARPlaneManager ARPlaneManager;
    List<ARRaycastHit> hitList;
    LightEstimation lightEstimation;
    public GameObject ghostGO;
    GameObject ghost;
    public GameObject batGO;
    GameObject bat;
    public GameObject spiderGO;
    GameObject spider;
    public GameObject skeletonGO;
    GameObject skeleton;
    public GameObject landDroneGO;
    GameObject landDrone;
    public GameObject lightningBubaGO;
    GameObject lightningBuba;
    public GameObject puzzlePortalGO;
    GameObject puzzlePortal;
    public GameObject robo1GO;
    GameObject robo1;
    public GameObject treasureBoxGO;
    GameObject treasureBox;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ( "Player" );
        canvas = player.transform.Find ( "Canvas" ).gameObject;
        ARRaycastManager = player.GetComponent<ARRaycastManager> ( );
        ARPlaneManager = player.GetComponent<ARPlaneManager> ( );
        lightEstimation = player.GetComponent<LightEstimation> ( );

        hauntedMusic = GetComponent<AudioSource> ( );

        if (!hauntedMusic.isPlaying)
        {
            hauntedMusic.Play ( );
        }

       
        secretRoomSpots = new Transform [ 6 ];
        warpPoints = new List<GameObject> ( );

        foreach (  var room in secretRoomSpots )
        {
            warpEnterPoint = Instantiate ( warpEnterPointGO , room.position , room.rotation ) as GameObject;
        }
        
    }

    IEnumerator HideCanvas(GameObject canvas)
    {
        yield return new WaitForSeconds ( 5f );
        canvas.gameObject.SetActive ( false );
    }
    // Update is called once per frame
    void Update()
    {
        if ( Input.touchCount > 0 )
        {

            Touch touch = Input.GetTouch(0);

            if ( Input.touchCount < 1 || ( touch.phase != TouchPhase.Began ) )
            {
                return;
            }

            if ( EventSystem.current.IsPointerOverGameObject ( touch.fingerId ) )
            {
                return;

            }
        }


        Vector3 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        if ( ARRaycastManager.Raycast ( screenCenter , hitList , TrackableType.PlaneWithinBounds ) )
        {
            ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

            Pose p = hitList[0].pose;

            if ( arPlane.alignment == PlaneAlignment.HorizontalDown && lightEstimation.brightness.HasValue )
            {
                if ( lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f )
                {
                    SpawnGhost ( p );
                }

                if ( lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f )
                {
                    SpawnBat ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnSpider ( p );
                }

            }

            if ( arPlane.alignment == PlaneAlignment.HorizontalUp && lightEstimation.brightness.HasValue )
            {
                if ( lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f )
                {
                    SpawnSkeleton ( p );
                }

                if ( lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f )
                {
                    SpawnLandDrone ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnLightningBuba ( p );
                }

            }

            if ( arPlane.alignment == PlaneAlignment.Vertical && lightEstimation.brightness.HasValue )
            {
                if ( lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f )
                {
                    SpawnPuzzlePortal ( p );
                }

                if ( lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f )
                {
                    SpawnRobo1 ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnTreasureBox ( p );
                }

            }

        }



        // Exit the app when the 'back' button is pressed.
        if ( Input.GetKey ( KeyCode.Escape ) )
        {
            Application.Quit ( );
        }

        // Get updated augmented images for this frame.

    }


    private void SpawnPuzzlePortal ( Pose p )
    {
        if ( puzzlePortal != null )
        {
            Destroy ( puzzlePortal.gameObject , 2f );
        }

        puzzlePortal = Instantiate ( puzzlePortalGO , p.position , p.rotation ) as GameObject;
        puzzlePortal.SetActive ( true );
    }

    private void SpawnLightningBuba ( Pose p )
    {
        if ( lightningBuba != null )
        {
            Destroy ( lightningBuba.gameObject , 2f );
        }

        lightningBuba = Instantiate ( lightningBubaGO , p.position , p.rotation ) as GameObject;
        lightningBuba.SetActive ( true );
    }

    private void SpawnSpider ( Pose p )
    {
        if ( spider != null )
        {
            Destroy ( spider.gameObject , 2f );
        }

        spider = Instantiate ( spiderGO , p.position , p.rotation ) as GameObject;
        spider.SetActive ( true );
    }

    private void SpawnRobo1 ( Pose p )
    {
        if ( robo1 != null )
        {
            Destroy ( robo1.gameObject , 2f );
        }

        robo1 = Instantiate ( robo1GO , p.position , p.rotation ) as GameObject;
        robo1.SetActive ( true );
    }

    private void SpawnLandDrone ( Pose p )
    {
        if ( landDrone != null )
        {
            Destroy ( landDrone.gameObject , 2f );
        }

        landDrone = Instantiate ( landDroneGO , p.position , p.rotation ) as GameObject;
        landDrone.SetActive ( true );
    }

    private void SpawnBat ( Pose p )
    {
        if ( puzzlePortal != null )
        {
            Destroy ( puzzlePortal.gameObject , 2f );
        }

        puzzlePortal = Instantiate ( puzzlePortalGO , p.position , p.rotation ) as GameObject;
        puzzlePortal.SetActive ( true );
    }

    private void SpawnGhost ( Pose p )
    {
        if ( ghost != null )
        {
            Destroy ( ghost.gameObject , 2f );
        }

        ghost = Instantiate ( ghostGO , p.position , p.rotation ) as GameObject;
        ghost.SetActive ( true );
    }

    private void SpawnTreasureBox ( Pose p )
    {
        if ( treasureBox != null )
        {
            Destroy ( treasureBox.gameObject , 2f );
        }

        treasureBox = Instantiate ( treasureBoxGO , p.position , p.rotation ) as GameObject;
        treasureBox.SetActive ( true );
    }

    private void SpawnSkeleton ( Pose p )
    {
        if ( skeleton != null )
        {
            Destroy ( skeleton.gameObject , 2f );
        }

        skeleton = Instantiate ( skeletonGO , p.position , p.rotation ) as GameObject;
        skeleton.SetActive ( true );
    }

}
