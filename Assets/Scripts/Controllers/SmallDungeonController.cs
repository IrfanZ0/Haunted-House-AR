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

public class SmallDungeonController : MonoBehaviour
{
    public Camera firstPersonCamera;
    private ARRaycastManager ARRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private List<ARRaycastHit> hitList;
    private LightEstimation lightEstimation;
    private GameObject player;
    public GameObject puzzlePortalGO;
    private GameObject puzzlePortal;
    public GameObject fireBubaGO;
    private GameObject fireBuba;
    public GameObject spiderGO;
    private GameObject spider;
    public GameObject iceDragonGO;
    private GameObject iceDragon;
    public GameObject coinBagGO;
    private GameObject coinBag;
    public GameObject lancerGO;
    private GameObject lancer;
    public GameObject smallDungeonGO;
    private GameObject smallDungeon;
    private GameObject playerCanvas;
    private Image playerLifeFillImage;
    private Slider playerMagicSlider;
    private Text coinText;
    private Image characterImage;
    private PlayerData pData;
    private Transform startPosition;
    private Transform fireBubaStartTransform;
    private Transform lancerStartTransform;
    public NavMeshSurface[] surfaces;

    // Use this for initialization
    private void Start ( )
    {
        fireBubaStartTransform = GameObject.Find ( "Fire Buba WayPoints" ).transform.Find ( "Fire Buba Stop 1" );
        lancerStartTransform = GameObject.Find ( "Lancer Path 1" ).transform.Find ( "Lancer WayPoint 1" );
        playerCanvas = GameObject.FindGameObjectWithTag ( "Player Life" );
        playerLifeFillImage = playerCanvas.transform.Find ( "Player Health Bar" ).transform.Find ( "Fill Area" ).transform.Find ( "Fill" ).GetComponent<Image> ( );
        playerMagicSlider = playerCanvas.transform.Find ( "Magic Bar" ).GetComponent<Slider> ( );
        coinText = playerCanvas.transform.Find ( "Coin Text" ).GetComponent<Text> ( );
        characterImage = playerCanvas.transform.Find ( "Avatar Image" ).GetComponent<Image> ( );
        pData = SaveLoadPlayerData.Load ( );
        playerLifeFillImage.fillAmount = pData.lifeAmount;
        playerMagicSlider.value = pData.magicAmount;
        coinText.text = pData.money.ToString ( );
        const string assetAddress = "Assets/SIMPLE Avatars Icons/64X64/";
        Addressables.LoadAssetAsync<Sprite> ( assetAddress + pData.characterSpriteName + ".png" ).Completed += OnLoadFinished;
        startPosition = GameObject.Find ( "Enter Portal" ).transform;
        player = GameObject.FindGameObjectWithTag ( "Player" );
        player.transform.position = startPosition.position;
        ARRaycastManager = player.GetComponent<ARRaycastManager> ( );
        ARPlaneManager = player.GetComponent<ARPlaneManager> ( );
        lightEstimation = player.GetComponent<LightEstimation> ( );

        for ( int i = 0 ; i < surfaces.Length ; i++ )
        {
            surfaces [ i ].BuildNavMesh ( );
        }
        hitList = new List<ARRaycastHit> ( );
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
                if ( ARRaycastManager.Raycast ( touch.position , hitList , TrackableType.PlaneWithinPolygon ) )
                {
                    ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

                    Pose p = hitList[0].pose;

                    if ( arPlane.alignment == PlaneAlignment.HorizontalUp )
                    {
                        SpawnSmallDungeon ( p );
                    }

                }
            }

        }

        Vector3 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        if ( ARRaycastManager.Raycast ( screenCenter , hitList , TrackableType.PlaneWithinPolygon ) )
        {
            ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

            Pose p = hitList[0].pose;

            if ( arPlane.alignment == PlaneAlignment.HorizontalDown && lightEstimation.brightness.HasValue )
            {
                if ( lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f )
                {
                    SpawnIceDragon ( p );
                }

                if ( lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f )
                {

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
                    SpawnLancer ( p );
                }

                if ( lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f )
                {

                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {

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
                    SpawnFireBuba ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnCoinBag ( p );
                }

            }

        }

    }

    private void OnLoadFinished ( AsyncOperationHandle<Sprite> obj )
    {
        characterImage.sprite = obj.Result;
    }

    private void SpawnSmallDungeon ( Pose p )
    {
        if ( smallDungeon != null )
        {
            Destroy ( smallDungeon.gameObject , 2f );
        }

        smallDungeon = Instantiate ( smallDungeonGO , p.position , p.rotation ) as GameObject;
        smallDungeon.SetActive ( true );
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

    private void SpawnFireBuba ( Pose p )
    {
        if ( fireBuba != null )
        {
            Destroy ( fireBuba.gameObject , 2f );
        }

        fireBuba = Instantiate ( fireBubaGO , p.position , p.rotation ) as GameObject;
        fireBuba.SetActive ( true );

        NavMeshAgent fBubaAgent = fireBuba.GetComponent<NavMeshAgent>();

        if ( fBubaAgent.Warp ( fireBubaStartTransform.position ) )
        {
            fBubaAgent.isStopped = false;
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
    }

    private void SpawnIceDragon ( Pose p )
    {
        if ( iceDragon != null )
        {
            Destroy ( iceDragon.gameObject , 2f );
        }

        iceDragon = Instantiate ( iceDragonGO , p.position , p.rotation ) as GameObject;
        iceDragon.SetActive ( true );
    }

    private void SpawnCoinBag ( Pose p )
    {
        if ( coinBag != null )
        {
            Destroy ( coinBag.gameObject , 2f );
        }

        coinBag = Instantiate ( coinBagGO , p.position , p.rotation ) as GameObject;
        coinBag.SetActive ( true );
    }

    private void SpawnLancer ( Pose p )
    {
        if ( lancer != null )
        {
            Destroy ( lancer.gameObject , 2f );
        }

        lancer = Instantiate ( lancerGO , p.position , p.rotation ) as GameObject;
        lancer.SetActive ( true );

        NavMeshAgent lancerAgent = lancer.GetComponent<NavMeshAgent>();

        if ( lancerAgent.Warp ( lancerStartTransform.position ) )
        {
            lancerAgent.isStopped = false;
        }
    }

}