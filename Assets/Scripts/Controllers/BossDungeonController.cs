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

public class BossDungeonController : MonoBehaviour
{

    public Camera firstPersonCamera;
    public GameObject bossDungeonGO;
    private GameObject bossDungeon;
    public GameObject fireDragonGO;
    private GameObject fireDragon;
    public GameObject lancerGO;
    private GameObject lancer;
    private ARRaycastManager ARRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private List<ARRaycastHit> hitList;
    private LightEstimation lightEstimation;
    private GameObject player;
    public GameObject puzzlePortalGO;
    private GameObject puzzlePortal;
    public GameObject iceDragonGO;
    private GameObject iceDragon;
    public GameObject demonLordGO;
    private GameObject demonLord;
    public GameObject lifePotionGO;
    private GameObject lifePotion;
    public GameObject blueKnightGO;
    private GameObject blueKnight;
    public GameObject redKnightGO;
    private GameObject redKnight;
    private AudioSource hauntedMusic;
    public GameObject treasureChestGO;
    private GameObject treasureChest;
    private RaycastHit hit;
    private GameObject playerCanvas;
    private Image playerLifeFillImage;
    private Slider playerMagicSlider;
    private Text coinText;
    private Image characterImage;
    private PlayerData pData;
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
        hauntedMusic = GetComponent<AudioSource> ( );

        for ( int i = 0 ; i < surfaces.Length ; i++ )
        {
            surfaces [ i ].BuildNavMesh ( );
        }
    }

    private void OnLoadFinished ( AsyncOperationHandle<Sprite> obj )
    {
        characterImage.sprite = obj.Result;
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
                        SpawnBossDungeon ( p );
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
                    SpawnFireDragon ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnTreasureChest ( p );
                }

            }

            if ( arPlane.alignment == PlaneAlignment.HorizontalUp && lightEstimation.brightness.HasValue )
            {
                if ( lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f )
                {
                    SpawnDemonLord ( p );
                }

                if ( lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f )
                {
                    SpawnLancer ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnRedKnight ( p );
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
                    SpawnBlueKnight ( p );
                }

                if ( lightEstimation.brightness.Value > 0.6f )
                {
                    SpawnLifePotion ( p );
                }

            }

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

    private void SpawnIceDragon ( Pose p )
    {
        if ( iceDragon != null )
        {
            Destroy ( iceDragon.gameObject , 2f );
        }

        iceDragon = Instantiate ( iceDragonGO , p.position , p.rotation ) as GameObject;
        iceDragon.SetActive ( true );
    }

    private void SpawnFireDragon ( Pose p )
    {
        if ( fireDragon != null )
        {
            Destroy ( fireDragon.gameObject , 2f );
        }

        fireDragon = Instantiate ( fireDragonGO , p.position , p.rotation ) as GameObject;
        fireDragon.SetActive ( true );
    }

    private void SpawnRedKnight ( Pose p )
    {
        if ( redKnight != null )
        {
            Destroy ( redKnight.gameObject , 2f );
        }

        redKnight = Instantiate ( redKnightGO , p.position , p.rotation ) as GameObject;
        redKnight.SetActive ( true );
    }

    private void SpawnTreasureChest ( Pose p )
    {
        if ( treasureChest != null )
        {
            Destroy ( treasureChest.gameObject , 2f );
        }

        treasureChest = Instantiate ( treasureChestGO , p.position , p.rotation ) as GameObject;
        treasureChest.SetActive ( true );
    }

    private void SpawnDemonLord ( Pose p )
    {
        if ( demonLord != null )
        {
            Destroy ( demonLord.gameObject , 2f );
        }

        demonLord = Instantiate ( demonLordGO , p.position , p.rotation ) as GameObject;
        demonLord.SetActive ( true );
    }

    private void SpawnLancer ( Pose p )
    {
        if ( lancer != null )
        {
            Destroy ( lancer.gameObject , 2f );
        }

        lancer = Instantiate ( lancerGO , p.position , p.rotation ) as GameObject;
        lancer.SetActive ( true );
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

    private void SpawnBlueKnight ( Pose p )
    {
        if ( blueKnight != null )
        {
            Destroy ( blueKnight.gameObject , 2f );
        }

        blueKnight = Instantiate ( blueKnightGO , p.position , p.rotation ) as GameObject;
        blueKnight.SetActive ( true );
    }

    private void SpawnBossDungeon ( Pose p )
    {
        if ( bossDungeon != null )
        {
            Destroy ( bossDungeon.gameObject , 2f );
        }

        bossDungeon = Instantiate ( bossDungeonGO , p.position , p.rotation ) as GameObject;
        bossDungeon.SetActive ( true );

        if ( !hauntedMusic.isPlaying )
        {
            hauntedMusic.Play ( );
        }
    }

}