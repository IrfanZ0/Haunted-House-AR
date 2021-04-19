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

public class BlueDiamondGraveyardController : MonoBehaviour
{

    public Camera firstPersonCamera;
    private GameObject canvas;
    private ARRaycastManager ARRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private List<ARRaycastHit> hitList;
    private LightEstimation lightEstimation;
    private GameObject player;
    private List<GameObject> redBlocks;
    public GameObject hTree;
    private GameObject hauntedTree;
    private List<GameObject> blueBlocks;
    public GameObject tombStoneGO;
    private GameObject tombStone;
    private GameObject mazeHolder;
    private GameObject blueDiamondMazeHolder;
    private RaycastHit hit;
    private GameObject playerCanvas;
    private Image playerLifeFillImage;
    private Slider playerMagicSlider;
    private Text coinText;
    private Image characterImage;
    private PlayerData pData;
    private Transform startPosition;
    public GameObject graveYardGO;
    private GameObject graveYard;
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

        player = GameObject.FindGameObjectWithTag ( "Player" );
        ARRaycastManager = player.GetComponent<ARRaycastManager> ( );
        ARPlaneManager = player.GetComponent<ARPlaneManager> ( );
        lightEstimation = player.GetComponent<LightEstimation> ( );
        hitList = new List<ARRaycastHit> ( );
        redBlocks = new List<GameObject> ( );
        blueBlocks = new List<GameObject> ( );
        player.transform.parent = mazeHolder.transform;
        startPosition = mazeHolder.transform.Find ( "Exit Portal" );
        player.transform.position = startPosition.position;

        blueDiamondMazeHolder = GameObject.Find ( "Blue Diamond Maze" ).transform.Find ( "MazeHolder" ).gameObject;

        if ( blueDiamondMazeHolder.activeSelf )
        {
            Transform blueStartPosition = blueDiamondMazeHolder.transform.Find("Exit Portal");
            player.transform.position = blueStartPosition.position;

        }

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
                if ( ARRaycastManager.Raycast ( touch.position , hitList , TrackableType.PlaneWithinBounds ) )
                {
                    ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

                    Pose p = hitList[0].pose;

                    if ( arPlane.alignment == PlaneAlignment.HorizontalUp )
                    {
                        SpawnGraveYard ( p );
                    }
                }
            }

        }

        Vector3 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        if ( ARRaycastManager.Raycast ( screenCenter , hitList , TrackableType.PlaneWithinPolygon ) )
        {
            ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

            Pose p = hitList[0].pose;

            if ( arPlane.alignment == PlaneAlignment.HorizontalUp )
            {
                SpawnHauntedTrees ( p );
                SpawnTombStone ( p );

            }

        }

    }

    private void SpawnGraveYard ( Pose p )
    {
        if ( graveYard != null )
        {
            Destroy ( graveYard.gameObject , 2f );
        }

        graveYard = Instantiate ( graveYardGO , p.position , p.rotation ) as GameObject;
        graveYard.SetActive ( true );

    }

    private void OnLoadFinished ( AsyncOperationHandle<Sprite> obj )
    {
        characterImage.sprite = obj.Result;
    }

    private void SpawnTombStone ( Pose p )
    {
        foreach ( var blueBlock in blueBlocks )
        {
            blueBlock.SetActive ( false );
            tombStone = Instantiate ( tombStoneGO ) as GameObject;
            p.position = blueBlock.transform.position;
            tombStone.transform.position = p.position;
            tombStone.transform.rotation = Quaternion.identity;
            tombStone.SetActive ( true );
        }

    }

    private void SpawnHauntedTrees ( Pose p )
    {

        foreach ( var block in redBlocks )
        {
            block.SetActive ( false );
            hauntedTree = Instantiate ( hTree ) as GameObject;
            p.position = block.transform.position;
            hauntedTree.transform.position = p.position;
            hauntedTree.transform.rotation = Quaternion.identity;
            hauntedTree.SetActive ( true );

        }

    }

    private void SpawnTombStone ( )
    {
        foreach ( var blueBlock in blueBlocks )
        {
            blueBlock.SetActive ( false );
            tombStone = Instantiate ( tombStoneGO , blueBlock.transform.position , Quaternion.identity ) as GameObject;
            //p.position = blueBlock.transform.position;
            //tombStone.transform.position = p.position;
            //tombStone.transform.rotation = Quaternion.identity;
            tombStone.SetActive ( true );
        }

    }

    private void SpawnHauntedTrees ( )
    {

        foreach ( var block in redBlocks )
        {
            block.SetActive ( false );
            hauntedTree = Instantiate ( hTree , block.transform.position , Quaternion.identity ) as GameObject;
            //p.position = block.transform.position;
            //hauntedTree.transform.position = p.position;
            //hauntedTree.transform.rotation = Quaternion.identity;
            hauntedTree.SetActive ( true );

        }

    }

    //private void SpawnPuzzlePortal ( Pose p )
    //{
    //    if ( puzzlePortal != null )
    //    {
    //        Destroy ( puzzlePortal.gameObject , 2f );
    //    }

    //    puzzlePortal = Instantiate ( puzzlePortalGO , p.position , p.rotation ) as GameObject;
    //    puzzlePortal.SetActive ( true );
    //}

    //private void SpawnLightningBuba ( Pose p )
    //{
    //    if ( lightningBuba != null )
    //    {
    //        Destroy ( lightningBuba.gameObject , 2f );
    //    }

    //    lightningBuba = Instantiate ( lightningBubaGO , p.position , p.rotation ) as GameObject;
    //    lightningBuba.SetActive ( true );
    //}

    //private void SpawnFireBuba ( Pose p )
    //{
    //    if ( fireBuba != null )
    //    {
    //        Destroy ( fireBuba.gameObject , 2f );
    //    }

    //    fireBuba = Instantiate ( fireBubaGO , p.position , p.rotation ) as GameObject;
    //    fireBuba.SetActive ( true );
    //}

    //private void SpawnIceBuba ( Pose p )
    //{
    //    if ( iceBuba != null )
    //    {
    //        Destroy ( iceBuba.gameObject , 2f );
    //    }

    //    iceBuba = Instantiate ( iceBubaGO , p.position , p.rotation ) as GameObject;
    //    iceBuba.SetActive ( true );
    //}

    //private void SpawnSpider ( Pose p )
    //{
    //    if ( spider != null )
    //    {
    //        Destroy ( spider.gameObject , 2f );
    //    }

    //    spider = Instantiate ( spiderGO , p.position , p.rotation ) as GameObject;
    //    spider.SetActive ( true );
    //}

    //private void SpawnBat ( Pose p )
    //{
    //    if ( bat != null )
    //    {
    //        Destroy ( bat.gameObject , 2f );
    //    }

    //    bat = Instantiate ( batGO , p.position , p.rotation ) as GameObject;
    //    bat.SetActive ( true );
    //}

    //private void SpawnGhost ( Pose p )
    //{
    //    if ( ghost != null )
    //    {
    //        Destroy ( ghost.gameObject , 2f );
    //    }

    //    ghost = Instantiate ( ghostGO , p.position , p.rotation ) as GameObject;
    //    ghost.SetActive ( true );
    //}

    //private void SpawnTreasureBox ( Pose p )
    //{
    //    if ( treasureBox != null )
    //    {
    //        Destroy ( treasureBox.gameObject , 2f );
    //    }

    //    treasureBox = Instantiate ( treasureBoxGO , p.position , p.rotation ) as GameObject;
    //    treasureBox.SetActive ( true );
    //}

    //private void SpawnSkeleton ( Pose p )
    //{
    //    if ( skeleton != null )
    //    {
    //        Destroy ( skeleton.gameObject , 2f );
    //    }

    //    skeleton = Instantiate ( skeletonGO , p.position , p.rotation ) as GameObject;
    //    skeleton.SetActive ( true );
    //}

}