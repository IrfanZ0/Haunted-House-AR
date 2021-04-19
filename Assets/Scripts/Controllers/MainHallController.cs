using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AI;

public class MainHallController : MonoBehaviour
{

    public Camera firstPersonCamera;
    private GameObject player;
    private ARRaycastManager arRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private List<ARRaycastHit> hitList;
    private List<ARRaycastHit> touchList;
    private LightEstimation lightEstimation;
    public GameObject ghostGO;
    private GameObject ghost;
    public GameObject batGO;
    private GameObject bat;
    public GameObject spiderGO;
    private GameObject spider;
    public GameObject skeletonGO;
    private GameObject skeleton;
    private GameObject redKnight;
    public GameObject lightningBubaGO;
    private GameObject lightningBuba;
    public GameObject puzzlePortalGO;
    private GameObject puzzlePortal;
    private GameObject blueKnight;
    public GameObject mainHallGO;
    private GameObject mainHall;
    public GameObject treasureBoxGO;
    private GameObject treasureBox;
    private AudioSource hauntedMusic;
    private RaycastHit hit;
    private GameObject playerCanvas;
    private Image playerLifeFillImage;
    private Slider playerMagicSlider;
    private Text coinText;
    private Image characterImage;
    private PlayerData pData;
    private Transform startPosition;
    private GameObject weaponSpot;
    private Transform batStartTransform;
    private Transform spiderStartTransform;
    private Transform ghostStartTransform;
    private Transform lightningBubaStartTransform;
    private Transform skeletonStartTransform;
    public  NavMeshSurface[] surfaces;

    // Use this for initialization
    private void Start ( )
    {
        for ( int i = 0 ; i < surfaces.Length ; i++ )
        {
            surfaces [ i ].BuildNavMesh ( );
        }

        skeletonStartTransform = GameObject.Find ( "Skeleton Path" ).transform.Find ( "Skeleton WayPoint 1" );
        lightningBubaStartTransform = GameObject.Find ( "Lightning Buba Path" ).transform.Find ( "Lightning Buba WayPoint 1" );
        ghostStartTransform = GameObject.Find ( "Ghost WayPoints" ).transform.Find ( "Ghost Stop 1" );
        spiderStartTransform = GameObject.Find ( "Spider Path 1" ).transform.Find ( "Spider WayPoint 1" );
        batStartTransform = GameObject.Find ( "Bat Path 1" ).transform.Find ( "Bat WayPoint 1" );
        playerCanvas = GameObject.FindGameObjectWithTag ( "Player Life" );
        playerLifeFillImage = playerCanvas.transform.Find ( "Player Health Bar" ).transform.Find ( "Fill Area" ).transform.Find ( "Fill" ).GetComponent<Image> ( );
        playerMagicSlider = playerCanvas.transform.Find ( "Magic Bar" ).GetComponent<Slider> ( );
        coinText = playerCanvas.transform.Find ( "Coin Text" ).GetComponent<Text> ( );
        characterImage = playerCanvas.transform.Find ( "Avatar Image" ).GetComponent<Image> ( );
        pData = SaveLoadPlayerData.Load ( );
        playerLifeFillImage.fillAmount = pData.lifeAmount;
        playerMagicSlider.value = pData.magicAmount;
        coinText.text = pData.money.ToString ( );
        Addressables.LoadAssetAsync<Sprite> ( "Assets/SIMPLE Avatars Icons/64X64/" + pData.characterSpriteName + ".png" ).Completed += OnLoadFinished;

        startPosition = GameObject.Find ( "Exit Portal" ).transform;
        player = GameObject.FindGameObjectWithTag ( "Player" );
        player.transform.position = startPosition.position;
        weaponSpot = player.transform.Find ( "AR Camera" ).transform.Find ( "Weapon Spot" ).gameObject;
        hauntedMusic = GetComponent<AudioSource> ( );
        arRaycastManager = player.GetComponent<ARRaycastManager> ( );
        ARPlaneManager = player.GetComponent<ARPlaneManager> ( );
        lightEstimation = player.GetComponent<LightEstimation> ( );
        hitList = new List<ARRaycastHit> ( );
        touchList = new List<ARRaycastHit> ( );
        ActivateWeapon ( pData.characterSpriteName );

    }

    private void ActivateWeapon ( string avatarName )
    {
        switch ( avatarName )
        {
            case "Man_4":
                {
                    GameObject basicSword = weaponSpot.transform.Find("Basic Sword").gameObject;
                    basicSword.SetActive ( true );
                    break;
                }
            case "Girl":
                {
                    GameObject mauler = weaponSpot.transform.Find("mauler").gameObject;
                    mauler.SetActive ( true );
                    break;
                }
        }

    }

    // Update is called once per frame
    private void Update ( )
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

            if ( touch.phase == TouchPhase.Began )
            {

                if ( arRaycastManager.Raycast ( touch.position , touchList , TrackableType.PlaneWithinPolygon ) )
                {
                    ARPlane arPlane = ARPlaneManager.GetPlane(touchList[0].trackableId);
                    Vector2 area = arPlane.size;

                    Pose p = touchList[0].pose;

                    //if ( arPlane.alignment == PlaneAlignment.HorizontalUp )
                    //{
                    //    SpawnMainHall ( p );
                    //}

                    if ( arPlane.alignment == PlaneAlignment.Vertical && area.x >= 0.20f && area.x <= 0.28f && area.y >= 0.25f && area.y <= 0.36f )
                    {
                        SpawnTreasureBox ( p );
                    }
                }
            }

        }

        Ray screenCenter = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));

        if ( arRaycastManager.Raycast ( screenCenter , hitList , TrackableType.PlaneWithinPolygon ) )
        {
            ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

            Pose p = hitList[0].pose;

            if ( arPlane.alignment == PlaneAlignment.HorizontalUp && lightEstimation.brightness.HasValue )
            {

                if ( lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f )
                {
                    SpawnSkeleton ( p );
                }

                if ( lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f )
                {

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

        }

    }

    private void SpawnTreasureBox ( Pose p )
    {
        if ( treasureBox != null )
        {
            Destroy ( treasureBox.gameObject , 2f );
        }

        treasureBox = Instantiate ( treasureBoxGO , p.position , p.rotation ) as GameObject;
        treasureBox.transform.localRotation = Quaternion.Euler ( 270f , 0 , 0 );
        treasureBox.SetActive ( true );
    }

    private void OnLoadFinished ( AsyncOperationHandle<Sprite> obj )
    {
        characterImage.sprite = obj.Result;
    }

    private void SpawnMainHall ( Pose p )
    {
        if ( mainHall != null )
        {
            Destroy ( mainHall.gameObject , 2f );
        }

        mainHall = Instantiate ( mainHallGO , p.position , p.rotation ) as GameObject;
        mainHall.SetActive ( true );

        if ( !hauntedMusic.isPlaying )
        {
            hauntedMusic.Play ( );
        }
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
        NavMeshAgent lBubaAgent = lightningBuba.GetComponent<NavMeshAgent> ( );
        lBubaAgent.transform.parent = surfaces [ 0 ].transform;

        if ( lBubaAgent.Warp ( lightningBubaStartTransform.position ) )
        {
            lBubaAgent.isStopped = false;
        }
    }

    private void SpawnSpider ( Pose p )
    {
        if ( spider != null )
        {
            Destroy ( spider.gameObject , 2f );
        }

        spider = Instantiate ( spiderGO , p.position , p.rotation ) as GameObject;
        spider.SetActive ( true );

        NavMeshAgent spiderAgent = spider.GetComponent<NavMeshAgent> ( );
        spiderAgent.transform.parent = surfaces [ 2 ].transform;

        if ( spiderAgent.Warp ( spiderStartTransform.position ) )
        {
            spiderAgent.isStopped = false;
            spiderAgent.destination = spiderStartTransform.position;

        }
    }

    private void SpawnBat ( Pose p )
    {
        if ( bat != null )
        {
            Destroy ( bat.gameObject , 2f );
        }

        bat = Instantiate ( batGO , p.position , p.rotation ) as GameObject;
        bat.SetActive ( true );

        NavMeshAgent batAgent = bat.GetComponent<NavMeshAgent> ( );

        batAgent.transform.parent = surfaces [ 0 ].transform;

        if ( batAgent.Warp ( batStartTransform.position ) )
        {
            batAgent.isStopped = false;

        }

    }

    private void SpawnGhost ( Pose p )
    {
        if ( ghost != null )
        {
            Destroy ( ghost.gameObject , 2f );
        }

        ghost = Instantiate ( ghostGO , p.position , p.rotation ) as GameObject;
        ghost.SetActive ( true );

        NavMeshAgent ghostAgent = ghost.GetComponent<NavMeshAgent> ( );
        ghostAgent.transform.parent = surfaces [ 1 ].transform;

        if ( ghostAgent.Warp ( ghostStartTransform.position ) )
        {
            ghostAgent.isStopped = false;

        }
    }

    private void SpawnSkeleton ( Pose p )
    {
        if ( skeleton != null )
        {
            Destroy ( skeleton.gameObject , 2f );
        }

        skeleton = Instantiate ( skeletonGO , p.position , p.rotation ) as GameObject;
        skeleton.SetActive ( true );

        NavMeshAgent skeletonAgent = skeleton.GetComponent<NavMeshAgent> ( );
        skeletonAgent.transform.parent = surfaces [ 2 ].transform;

        if ( skeletonAgent.Warp ( skeletonStartTransform.position ) )
        {
            skeletonAgent.isStopped = false;

        }
    }

}