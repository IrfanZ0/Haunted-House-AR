using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KitchenController : MonoBehaviour
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
    public GameObject lightningBubaGO;
    GameObject lightningBuba;
    public GameObject steakGO;
    GameObject steak;
    public GameObject lancerGO;
    GameObject lancer;
    public GameObject cookieGO;
    GameObject cookie;
    public GameObject bigBottleGO;
    GameObject bigBottle;
    public GameObject knifeHandGO;
    GameObject knifeHand;
    public GameObject treasureBoxGO;
    GameObject treasureBox;
    public GameObject evilFridgeGO;
    GameObject evilFridge;
    public GameObject evilMicrowaveGO;
    GameObject evilMicrowave;

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
                        SpawnLightningBuba(p);
                    }

                    if (lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f)
                    {
                        SpawnHandKnife(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnLancer(p);
                    }

                }

                if (arPlane.alignment == PlaneAlignment.HorizontalUp && lightEstimation.brightness.HasValue)
                {
                    if (lightEstimation.brightness.Value > 0 && lightEstimation.brightness.Value <= 0.3f)
                    {
                        SpawnEvilFridge(p);
                    }

                    if (lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f)
                    {
                        SpawnEvilMicrowave(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnSteak(p);
                        SpawnCookie(p);
                        SpawnBigBottle(p);
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
                        SpawnHandKnife(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnTreasureBox(p);
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

    private void SpawnLightningBuba(Pose p)
    {
        if (lightningBuba != null)
        {
            Destroy(lightningBuba.gameObject, 2f);
        }

        lightningBuba = Instantiate(lightningBubaGO, p.position, p.rotation) as GameObject;
        lightningBuba.SetActive(true);
    }

    private void SpawnSteak(Pose p)
    {
        if (steak != null)
        {
            Destroy(steak.gameObject, 2f);
        }

        steak = Instantiate(steakGO, p.position, p.rotation) as GameObject;
        steak.SetActive(true);
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

    private void SpawnCookie(Pose p)
    {
        if (cookie != null)
        {
            Destroy(cookie.gameObject, 2f);
        }

        cookie = Instantiate(cookieGO, p.position, p.rotation) as GameObject;
        cookie.SetActive(true);
    }

    private void SpawnBigBottle(Pose p)
    {
        if (bigBottle != null)
        {
            Destroy(bigBottle.gameObject, 2f);
        }

        bigBottle = Instantiate(bigBottleGO, p.position, p.rotation) as GameObject;
        bigBottle.SetActive(true);
    }

    private void SpawnHandKnife(Pose p)
    {
        if (knifeHand != null)
        {
            Destroy(knifeHand.gameObject, 2f);
        }

        knifeHand = Instantiate(knifeHandGO, p.position, p.rotation) as GameObject;
        knifeHand.SetActive(true);
    }

    private void SpawnTreasureBox(Pose p)
    {
        if (treasureBox != null)
        {
            Destroy(treasureBox.gameObject, 2f);
        }

        treasureBox = Instantiate(treasureBoxGO, p.position, p.rotation) as GameObject;
        treasureBox.SetActive(true);
    }

    private void SpawnEvilFridge(Pose p)
    {
        if (evilFridge != null)
        {
            Destroy(evilFridge.gameObject, 2f);
        }

        evilFridge = Instantiate(evilFridgeGO, p.position, p.rotation) as GameObject;
        evilFridge.SetActive(true);
    }

    private void SpawnEvilMicrowave(Pose p)
    {
        if (evilMicrowave != null)
        {
            Destroy(evilMicrowave.gameObject, 2f);
        }

        evilMicrowave = Instantiate(evilMicrowaveGO, p.position, p.rotation) as GameObject;
        evilMicrowave.SetActive(true);
    }
     
  
}



