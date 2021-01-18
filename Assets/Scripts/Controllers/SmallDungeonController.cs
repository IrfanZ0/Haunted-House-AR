using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SmallDungeonController : MonoBehaviour {

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
    public GameObject fireBubaGO;
    GameObject fireBuba;
    public GameObject spiderGO;
    GameObject spider;
    public GameObject robo2GO;
    GameObject robo2;
    public GameObject airDroneGO;
    GameObject airDrone;
    public GameObject evilHandGO;
    GameObject evilHand;
    public GameObject iceDragonGO;
    GameObject iceDragon;
    public GameObject coinBagGO;
    GameObject coinBag;
    public GameObject lancerGO;
    GameObject lancer;



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
                        SpawnIceDragon(p);
                    }

                    if (lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f)
                    {
                        SpawnAirDrone(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnSpider(p);
                    }

                }

                if (arPlane.alignment == PlaneAlignment.HorizontalUp && lightEstimation.brightness.HasValue)
                {
                    if (lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f)
                    {
                        SpawnLancer(p);
                    }

                    if (lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f)
                    {
                        SpawnHand(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnRobo2(p);
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
                        SpawnFireBuba(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnCoinBag(p);
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

    private void SpawnFireBuba(Pose p)
    {
        if (fireBuba != null)
        {
            Destroy(fireBuba.gameObject, 2f);
        }

        fireBuba = Instantiate(fireBubaGO, p.position, p.rotation) as GameObject;
        fireBuba.SetActive(true);
    }

    private void SpawnSpider(Pose p)
    {
        if (spider != null)
        {
            Destroy(spider.gameObject, 2f);
        }

        spider = Instantiate(spiderGO, p.position, p.rotation) as GameObject;
        spider.SetActive(true);
    }

    private void SpawnRobo2(Pose p)
    {
        if (robo2 != null)
        {
            Destroy(robo2.gameObject, 2f);
        }

        robo2 = Instantiate(robo2GO, p.position, p.rotation) as GameObject;
        robo2.SetActive(true);
    }

    private void SpawnAirDrone(Pose p)
    {
        if (airDrone != null)
        {
            Destroy(airDrone.gameObject, 2f);
        }

        airDrone = Instantiate(airDroneGO, p.position, p.rotation) as GameObject;
        airDrone.SetActive(true);
    }

    private void SpawnHand(Pose p)
    {
        if (evilHand != null)
        {
            Destroy(evilHand.gameObject, 2f);
        }

        evilHand = Instantiate(evilHandGO, p.position, p.rotation) as GameObject;
        evilHand.SetActive(true);
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

    private void SpawnCoinBag(Pose p)
    {
        if (coinBag != null)
        {
            Destroy(coinBag.gameObject, 2f);
        }

        coinBag = Instantiate(coinBagGO, p.position, p.rotation) as GameObject;
        coinBag.SetActive(true);
    }

    private void SpawnLancer(Pose p)
    {
        if (lancer != null)
        {
            Destroy(lancer.gameObject, 2f);
        }

        lancer = Instantiate(lancerGO, p.position, p.rotation) as GameObject;
        lancer.SetActive(true);
    }

    
	
}
