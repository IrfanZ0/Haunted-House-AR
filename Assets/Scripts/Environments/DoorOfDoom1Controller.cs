using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.AI;
using System;

public class DoorOfDoom1Controller : MonoBehaviour
{
    private GameObject player;
    private ARRaycastManager ARRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private List<ARRaycastHit> hitList;
    private LightEstimation lightEstimation;
    public GameObject lancerGO;
    private GameObject lancer;
    public GameObject ghostGO;
    private GameObject ghost;
    public GameObject batGO;
    private GameObject bat;
    public GameObject spiderGO;
    private GameObject spider;
    public GameObject skeletonGO;
    private GameObject skeleton;
    public GameObject landDroneGO;
    private GameObject landDrone;
    public GameObject lightningBubaGO;
    private GameObject lightningBuba;
    public GameObject puzzlePortalGO;
    private GameObject puzzlePortal;
    public GameObject robo1GO;
    private GameObject robo1;
    public GameObject treasureBoxGO;
    private GameObject treasureBox;
    public Camera firstPersonCamera;
    private GameObject canvas;
    private AudioSource hauntedMusic;
    private AudioSource successMusic;
    private Transform spiderStartPoint;
    private Transform batStartPoint;
    private Transform ghostStartPoint;
    private Transform lancerStartPoint;
    private GameObject ringOfFire;

    private void Start ( )
    {
        player = GameObject.FindGameObjectWithTag ( "Player" );
        ARRaycastManager = player.GetComponent<ARRaycastManager> ( );
        ARPlaneManager = player.GetComponent<ARPlaneManager> ( );
        lightEstimation = player.GetComponent<LightEstimation> ( );
        hauntedMusic = GetComponent<AudioSource> ( );
        successMusic = GetComponent<AudioSource> ( );
        spiderStartPoint = GameObject.Find ( "Door of Doom 1" ).transform.Find ( "Spider web_3" );
        batStartPoint = GameObject.Find ( "Door of Doom 1" ).transform.Find ( "Bat Start Spot" );
        ghostStartPoint = GameObject.Find ( "Door of Doom 1" ).transform.Find ( "Ghost Start Spot" );
        lancer = GameObject.FindGameObjectWithTag ( "Lancer" );
        lancerStartPoint = GameObject.Find ( "Door of Doom 1" ).transform.Find ( "Lancer Start Spot" );
        ringOfFire = GameObject.Find ( "Door of Doom 1" ).transform.Find ( "chest_close" ).gameObject;
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

            if ( spider != null )
            {
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

        if ( lancer.GetComponent<Animator> ( ).GetCurrentAnimatorStateInfo ( 0 ).IsName ( "isDead_Lancer" ) )
        {
            StartCoroutine ( RevealTreasure ( ringOfFire ) );

        }

    }

    private IEnumerator RevealTreasure ( GameObject ringOfFire )
    {

        ParticleSystem psRingFire = ringOfFire.transform.Find("RingOfFireFlame").GetComponent<ParticleSystem>();
        if ( psRingFire.isPlaying )
        {
            psRingFire.Stop ( );
        }

        ParticleSystem psRingFireSecondary = ringOfFire.transform.Find("RingOfFireSecondaryFlame").GetComponent<ParticleSystem>();
        if ( psRingFireSecondary.isPlaying )
        {
            psRingFireSecondary.Stop ( );
        }

        AudioSource ringFireSound = ringOfFire.transform.Find("RingOfFireSound").GetComponent<AudioSource>();

        if ( ringFireSound.isPlaying )
        {
            ringFireSound.Stop ( );
        }

        ParticleSystem psRingFireSparks = ringOfFire.transform.Find("RingOfFireSparks").GetComponent<ParticleSystem>();

        if ( psRingFireSparks.isPlaying )
        {
            psRingFireSparks.Stop ( );
        }

        ParticleSystem psRingFireSSmoke =  ringOfFire.transform.Find("RingOfFireSmoke").GetComponent<ParticleSystem>();

        if ( psRingFireSSmoke.isPlaying )
        {
            psRingFireSSmoke.Stop ( );
        }

        yield return new WaitForSeconds ( 2f );

        if ( successMusic.clip.name == "SpookyMansionMusic-Success" && !successMusic.isPlaying )
        {
            successMusic.Play ( );
        }

    }

    private void SpawnLancer ( Pose p )
    {
        if ( lancer != null )
        {
            Destroy ( lancer.gameObject , 2f );
        }

        lancer = Instantiate ( lancerGO , p.position , p.rotation ) as GameObject;
        lancer.SetActive ( true );
        lancer.GetComponent<NavMeshAgent> ( ).Warp ( lancerStartPoint.position );
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
        spider.GetComponent<NavMeshAgent> ( ).Warp ( spiderStartPoint.position );
        spider.GetComponent<Animator> ( ).SetBool ( "spiderWalk" , true );
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
        if ( bat != null )
        {
            Destroy ( bat.gameObject , 2f );
        }

        bat = Instantiate ( batGO , p.position , p.rotation ) as GameObject;
        bat.SetActive ( true );
        bat.GetComponent<NavMeshAgent> ( ).Warp ( batStartPoint.position );
        bat.GetComponent<Animator> ( ).SetBool ( "Bat Fly" , true );
    }

    private void SpawnGhost ( Pose p )
    {
        if ( ghost != null )
        {
            Destroy ( ghost.gameObject , 2f );
        }

        ghost = Instantiate ( ghostGO , p.position , p.rotation ) as GameObject;
        ghost.SetActive ( true );
        ghost.GetComponent<NavMeshAgent> ( ).Warp ( ghostStartPoint.position );
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