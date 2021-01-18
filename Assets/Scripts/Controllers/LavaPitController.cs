using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class LavaPitController : MonoBehaviour
{
    GameObject canvas;
    Vector3 touchPos3D;
    public GameObject arCamera;
    RaycastHit hit;
    ARRaycastManager arRaycastManager;
    List<ARRaycastHit> hitList;
    ARPlaneManager arPlaneManager;
    LightEstimation lightEstimation;
    public GameObject skeletonGO;
    GameObject skeleton;
    public GameObject ghostGO;
    GameObject ghost;
    public GameObject spiderGO;
    GameObject spider;
    private int spawnSpiderCount;
    private int spawnGhostCount;
    private int spawnSkeletonCount;

    // Start is called before the first frame update
    void Start()
    {
        spawnGhostCount = 3;
        spawnSpiderCount = 2;
        spawnSkeletonCount = 4;
        lightEstimation = GameObject.Find ( "Directional Light" ).GetComponent<LightEstimation> ( );
        arRaycastManager = arCamera.GetComponent<ARRaycastManager> ( );
        arPlaneManager = arCamera.GetComponent<ARPlaneManager> ( );
        hitList = new List<ARRaycastHit> ( );
        canvas = GameObject.Find ( "Canvas" );
        StartCoroutine ( HideCanvas ( canvas ) );
        
    }

    IEnumerator HideCanvas ( GameObject canvas )
    {
        yield return new WaitForSeconds ( 5f );
        canvas.SetActive ( false );
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

            if ( touch.phase == TouchPhase.Began )
            {
                touchPos3D = arCamera.GetComponent<Camera> ( ).ScreenToWorldPoint ( touch.position );

            }

            if ( touch.phase == TouchPhase.Moved )
            {
                if ( Physics.Raycast ( touchPos3D , Vector3.forward , out hit ) )
                {
                   
                }
            }

        }


        Vector3 screenCenter = arCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));



        if ( arRaycastManager.Raycast ( screenCenter , hitList , TrackableType.PlaneWithinBounds ) )
        {
            ARPlane arPlane = arPlaneManager.GetPlane(hitList[0].trackableId);

            Pose p = hitList[0].pose;

            if (arPlane.alignment == PlaneAlignment.HorizontalUp)
            {
                for ( int i = 0 ; i < spawnSkeletonCount ; i++ )
                {
                    SpawnSkeleton ( p );
                }
              
            }

            if (arPlane.alignment == PlaneAlignment.HorizontalDown)
            {
                for ( int i = 0 ; i < spawnGhostCount ; i++ )
                {
                    SpawnGhost ( p );
                }
               
            }

            if (arPlane.alignment == PlaneAlignment.Vertical)
            {
                for ( int i = 0 ; i < spawnSpiderCount ; i++ )
                {
                    SpawnSpider ( p );
                }
               
            }


        }


        // Exit the app when the 'back' button is pressed.
        if ( Input.GetKey ( KeyCode.Escape ) )
        {
            Application.Quit ( );
        }

    }

    private void SpawnSpider ( Pose p )
    {
        if (spider != null)
        {
            Destroy ( spider.gameObject , 2f );
        }

        spider = Instantiate ( spiderGO , p.position , p.rotation ) as GameObject;
        
    }

    private void SpawnGhost ( Pose p )
    {
        if ( ghost != null )
        {
            Destroy ( ghost.gameObject , 2f );
        }

        ghost = Instantiate ( ghostGO , p.position , p.rotation ) as GameObject;
    }

    private void SpawnSkeleton ( Pose p )
    {
        if ( skeleton != null )
        {
            Destroy ( skeleton.gameObject , 2f );
        }

        skeleton = Instantiate ( skeletonGO , p.position , p.rotation ) as GameObject;
    }
}
