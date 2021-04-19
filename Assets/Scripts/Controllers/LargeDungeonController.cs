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

public class LargeDungeonController : MonoBehaviour
{

    public Camera firstPersonCamera;
    private GameObject canvas;
    private Slider loadingBar;
    private Dropdown sceneDD;
    private Text selectedText;
    private ARRaycastManager ARRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private List<ARRaycastHit> hitList;
    private LightEstimation lightEstimation;
    private GameObject player;
    public GameObject puzzlePortalGO;
    private GameObject puzzlePortal;
    public GameObject iceBubaGO;
    private GameObject iceBuba;
    public GameObject robo3GO;
    private GameObject robo3;
    public GameObject robotGuardGO;
    private GameObject robotGuard;
    public GameObject iceDragonGO;
    private GameObject iceDragon;
    public GameObject ghostGO;
    private GameObject ghost;
    public GameObject lifePotionGO;
    private GameObject lifePotion;
    public GameObject attackDroneGO;
    private GameObject attackDrone;
    public GameObject skeletonGO;
    private GameObject skeleton;
    public GameObject largeDungeonGO;
    private GameObject largeDungeon;
    private RaycastHit hit;
    private GameObject playerCanvas;
    private Image playerLifeFillImage;
    private Slider playerMagicSlider;
    private Text coinText;
    private Image characterImage;
    private PlayerData pData;
    private Transform startPosition;
    public NavMeshSurface[] surfaces;

    // Use this for initialization
    private void Start ( )
    {
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
        startPosition = GameObject.Find ( "Large Dungeon" ).transform.transform.Find ( "Exit Portal" );
        player = GameObject.FindGameObjectWithTag ( "Player" );
        player.transform.position = startPosition.position;
        player.transform.rotation = Quaternion.Euler ( 0 , 180f , 0 );
        canvas = player.transform.Find ( "Canvas" ).gameObject;
        loadingBar = canvas.transform.Find ( "ProgressBar" ).GetComponent<Slider> ( );
        sceneDD = canvas.transform.Find ( "Dropdown" ).GetComponent<Dropdown> ( );
        selectedText = canvas.transform.Find ( "Dropdown" ).transform.Find ( "Label" ).GetComponent<Text> ( );
        ARRaycastManager = player.GetComponent<ARRaycastManager> ( );
        ARPlaneManager = player.GetComponent<ARPlaneManager> ( );
        lightEstimation = player.GetComponent<LightEstimation> ( );
        hitList = new List<ARRaycastHit> ( );

        for ( int i = 0 ; i < surfaces.Length ; i++ )
        {
            surfaces [ i ].BuildNavMesh ( );
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
                if ( ARRaycastManager.Raycast ( touch.position , hitList , TrackableType.PlaneWithinPolygon ) )
                {
                    ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

                    Pose p = hitList[0].pose;

                    if ( arPlane.alignment == PlaneAlignment.HorizontalUp )
                    {
                        SpawnLargeDungeon ( p );
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
                    SpawnGhost ( p );
                }

                if ( lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f )
                {
                    SpawnIceDragon ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnAttackDrone ( p );
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
                    SpawnRobotGuard ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnIceBuba ( p );
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
                    SpawnRobotGuard ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnLifePotion ( p );
                }

            }

        }

    }

    private void OnLoadFinished ( AsyncOperationHandle<Sprite> obj )
    {
        characterImage.sprite = obj.Result;
    }

    private void SpawnLargeDungeon ( Pose p )
    {
        if ( largeDungeon != null )
        {
            Destroy ( largeDungeon.gameObject , 2f );
        }

        largeDungeon = Instantiate ( largeDungeonGO , p.position , p.rotation ) as GameObject;
        largeDungeon.SetActive ( true );
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

    private void SpawnIceBuba ( Pose p )
    {
        if ( iceBuba != null )
        {
            Destroy ( iceBubaGO.gameObject , 2f );
        }

        iceBuba = Instantiate ( iceBubaGO , p.position , p.rotation ) as GameObject;
        iceBuba.SetActive ( true );
    }

    private void SpawnRobo3 ( Pose p )
    {
        if ( robo3 != null )
        {
            Destroy ( robo3.gameObject , 2f );
        }

        robo3 = Instantiate ( robo3GO , p.position , p.rotation ) as GameObject;
        robo3.SetActive ( true );
    }

    private void SpawnRobotGuard ( Pose p )
    {
        if ( robotGuard != null )
        {
            Destroy ( robotGuard.gameObject , 2f );
        }

        robotGuard = Instantiate ( robotGuardGO , p.position , p.rotation ) as GameObject;
        robotGuard.SetActive ( true );
    }

    private void SpawnAttackDrone ( Pose p )
    {
        if ( attackDrone != null )
        {
            Destroy ( attackDrone.gameObject , 2f );
        }

        attackDrone = Instantiate ( attackDroneGO , p.position , p.rotation ) as GameObject;
        attackDrone.SetActive ( true );
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

    private void SpawnGhost ( Pose p )
    {
        if ( ghost != null )
        {
            Destroy ( ghost.gameObject , 2f );
        }

        ghost = Instantiate ( ghostGO , p.position , p.rotation ) as GameObject;
        ghost.SetActive ( true );
    }

    private void SpawnLifePotion ( Pose p )
    {
        if ( lifePotion != null )
        {
            Destroy ( lifePotion.gameObject , 2f );
        }

        lifePotion = Instantiate ( lifePotionGO , p.position , p.rotation ) as GameObject;
        lifePotion.SetActive ( true );
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