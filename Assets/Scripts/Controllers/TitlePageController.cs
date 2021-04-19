using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.IO;

public class TitlePageController : MonoBehaviour
{
    private ARPlaneManager arPlaneManager;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hitList;
    public GameObject skeletonGO;
    private GameObject skeleton;
    public GameObject batGO;
    private GameObject bat;
    public Button loadGameButton;
    public Button newGameButton;
    private string path;
    private PlayerData pData;
    [HideInInspector] public float life;
    [HideInInspector] public float magic;
    [HideInInspector] public int money;
    [HideInInspector] public string levelName;
    [HideInInspector] public string avatarName;

    // Start is called before the first frame update
    private void Start ( )
    {
        arPlaneManager = GameObject.FindGameObjectWithTag ( "Player" ).GetComponent<ARPlaneManager> ( );
        arRaycastManager = GameObject.FindGameObjectWithTag ( "Player" ).GetComponent<ARRaycastManager> ( );
        hitList = new List<ARRaycastHit> ( );

        path = Application.persistentDataPath + "/saveData.txt";

        if ( File.Exists ( path ) )
        {
            loadGameButton.interactable = true;
            newGameButton.interactable = true;
            pData = SaveLoadPlayerData.Load ( );
            life = pData.lifeAmount;
            magic = pData.magicAmount;
            money = pData.money;
            levelName = pData.levelName;
            avatarName = pData.characterSpriteName;

        }
        else
        {
            loadGameButton.interactable = false;
            newGameButton.interactable = true;
            SaveLoadPlayerData.Save ( 1f , 5f , 0 , "Main Hall" , "Man_4" );
        }
    }

    // Update is called once per frame
    private void Update ( )
    {
        Vector3 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        if ( arRaycastManager.Raycast ( screenCenter , hitList , TrackableType.PlaneWithinPolygon ) )
        {
            ARPlane arPlane = arPlaneManager.GetPlane(hitList[0].trackableId);

            Pose p = hitList[0].pose;

            if ( arPlane.alignment == PlaneAlignment.HorizontalUp )
            {
                SpawnBat ( p );
            }

            if ( arPlane.alignment == PlaneAlignment.Vertical )
            {
                SpawnSkeleton ( p );
            }

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

    }

    private void SpawnBat ( Pose p )
    {
        if ( bat != null )
        {
            Destroy ( bat.gameObject , 2f );
        }

        bat = Instantiate ( batGO , p.position , p.rotation ) as GameObject;
        bat.SetActive ( true );

    }
}