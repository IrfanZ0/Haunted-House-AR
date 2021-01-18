using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GraveyardController : MonoBehaviour
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
    public GameObject fireBubaGO;
    GameObject fireBuba;
    public GameObject iceBubaGO;
    GameObject iceBuba;
    public GameObject ghostGO;
    GameObject ghost;
    public GameObject skeletonGO;
    GameObject skeleton;
    public GameObject treasureBoxGO;
    GameObject treasureBox;
    public GameObject batGO;
    GameObject bat;
    public GameObject spiderGO;
    GameObject spider;


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
                        SpawnBat(p);
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
                        SpawnSkeleton(p);
                    }

                    if (lightEstimation.brightness.Value > 0.3f && lightEstimation.brightness.Value <= 0.6f)
                    {
                        SpawnFireBuba(p);
                    }

                    if (lightEstimation.brightness.Value > 0.6f)
                    {
                        SpawnLightningBuba(p);
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
                        SpawnIceBuba(p);
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

    private void SpawnFireBuba(Pose p)
    {
        if (fireBuba != null)
        {
            Destroy (fireBuba.gameObject, 2f);
        }

        fireBuba = Instantiate(fireBubaGO, p.position, p.rotation) as GameObject;
        fireBuba.SetActive(true);
    }

    private void SpawnIceBuba(Pose p)
    {
        if (iceBuba != null)
        {
            Destroy(iceBuba.gameObject, 2f);
        }

        iceBuba = Instantiate(iceBubaGO, p.position, p.rotation) as GameObject;
        iceBuba.SetActive(true);
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

    private void SpawnBat(Pose p)
    {
        if (bat != null)
        {
            Destroy(bat.gameObject, 2f);
        }

        bat = Instantiate(batGO, p.position, p.rotation) as GameObject;
        bat.SetActive(true);
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

    private void SpawnTreasureBox(Pose p)
    {
        if (treasureBox != null)
        {
            Destroy(treasureBox.gameObject, 2f);
        }

        treasureBox = Instantiate(treasureBoxGO, p.position, p.rotation) as GameObject;
        treasureBox.SetActive(true);
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







