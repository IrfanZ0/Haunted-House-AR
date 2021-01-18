using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LargeDungeonController : MonoBehaviour
{

    public Camera firstPersonCamera;
    private bool isQuitting = false;
    GameObject canvas;
    Slider loadingBar;
    Dropdown sceneDD;
    Text selectedText;
    ARRaycastManager ARRaycastManager;
    ARPlaneManager ARPlaneManager;
    List<ARRaycastHit> hitList;
    LightEstimation lightEstimation;
    GameObject player;
    public GameObject puzzlePortalGO;
    GameObject puzzlePortal;
    public GameObject iceBubaGO;
    GameObject iceBuba;
    public GameObject robo3GO;
    GameObject robo3;
    public GameObject robotGuardGO;
    GameObject robotGuard;
    public GameObject iceDragonGO;
    GameObject iceDragon;
    public GameObject ghostGO;
    GameObject ghost;
    public GameObject lifePotionGO;
    GameObject lifePotion;
    public GameObject attackDroneGO;
    GameObject attackDrone;
    public GameObject skeletonGO;
    GameObject skeleton;




    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = player.transform.Find("Canvas").gameObject;
        loadingBar = canvas.transform.Find("ProgressBar").GetComponent<Slider>();
        sceneDD = canvas.transform.Find("Dropdown").GetComponent<Dropdown>();
        selectedText = canvas.transform.Find("Dropdown").transform.Find("Label").GetComponent<Text>();
        ARRaycastManager = player.GetComponent<ARRaycastManager>();
        ARPlaneManager = player.GetComponent<ARPlaneManager>();
        lightEstimation = player.GetComponent<LightEstimation>();
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
            if (ARRaycastManager.Raycast(screenCenter, hitList, TrackableType.PlaneWithinBounds))
            {
                ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

                Pose p = hitList[0].pose;

                if (arPlane.alignment == PlaneAlignment.HorizontalDown && lightEstimation.brightness.HasValue)
                {
                    if (lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f)
                    {
                        SpawnGhost(p);
                    }

                    if (lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f)
                    {
                        SpawnIceDragon(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnAttackDrone(p);
                    }

                }

                if (arPlane.alignment == PlaneAlignment.HorizontalUp && lightEstimation.brightness.HasValue)
                {
                    if (lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f)
                    {
                        SpawnSkeleton(p);
                    }

                    if (lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f)
                    {
                        SpawnRobotGuard(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnIceBuba(p);
                    }

                }

                if (arPlane.alignment == PlaneAlignment.Vertical && lightEstimation.brightness.HasValue)
                {
                    if (lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f)
                    {
                        SpawnPuzzlePortal(p);
                    }

                    if (lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f)
                    {
                        SpawnRobotGuard(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnLifePotion(p);
                    }

                }

            }



            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Get updated augmented images for this frame.



        


    }

    private void SpawnPuzzlePortal(Pose p)
    {
        if (puzzlePortal != null)
        {
            Destroy(puzzlePortal.gameObject, 2f);
        }

        puzzlePortal = Instantiate(puzzlePortalGO, p.position, p.rotation) as GameObject;
        puzzlePortal.SetActive(true);
    }

    private void SpawnIceBuba(Pose p)
    {
        if (iceBuba != null)
        {
            Destroy(iceBubaGO.gameObject, 2f);
        }

        iceBuba = Instantiate(iceBubaGO, p.position, p.rotation) as GameObject;
        iceBuba.SetActive(true);
    }

    private void SpawnRobo3(Pose p)
    {
        if (robo3 != null)
        {
            Destroy(robo3.gameObject, 2f);
        }

        robo3 = Instantiate(robo3GO, p.position, p.rotation) as GameObject;
        robo3.SetActive(true);
    }

    private void SpawnRobotGuard(Pose p)
    {
        if (robotGuard != null)
        {
            Destroy(robotGuard.gameObject, 2f);
        }

        robotGuard = Instantiate(robotGuardGO, p.position, p.rotation) as GameObject;
        robotGuard.SetActive(true);
    }

    private void SpawnAttackDrone(Pose p)
    {
        if (attackDrone != null)
        {
            Destroy(attackDrone.gameObject, 2f);
        }

        attackDrone = Instantiate(attackDroneGO, p.position, p.rotation) as GameObject;
        attackDrone.SetActive(true);
    }

    private void SpawnIceDragon(Pose p)
    {
        if (iceDragon != null)
        {
            Destroy(iceDragon.gameObject, 2f);
        }

        iceDragon = Instantiate(iceDragonGO, p.position, p.rotation) as GameObject;
        iceDragon.SetActive(true);
    }

    private void SpawnGhost(Pose p)
    {
        if (ghost != null)
        {
            Destroy(ghost.gameObject, 2f);
        }

        ghost = Instantiate(ghostGO, p.position, p.rotation) as GameObject;
        ghost.SetActive(true);
    }

    private void SpawnLifePotion(Pose p)
    {
        if (lifePotion != null)
        {
            Destroy(lifePotion.gameObject, 2f);
        }

        lifePotion = Instantiate(lifePotionGO, p.position, p.rotation) as GameObject;
        lifePotion.SetActive(true);
    }

    private void SpawnSkeleton(Pose p)
    {
        if (skeleton != null)
        {
            Destroy(skeleton.gameObject, 2f);
        }

        skeleton = Instantiate(skeletonGO, p.position, p.rotation) as GameObject;
        skeleton.SetActive(true);
    }

  
    
}

