using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponStoreController : MonoBehaviour
{

    public Camera firstPersonCamera;
    private GameObject player;
    private ARRaycastManager ARRaycastManager;
    private ARPlaneManager ARPlaneManager;
    private List<ARRaycastHit> hitList;
    public GameObject weaponStoreGO;
    private GameObject weaponStore;
    private RaycastHit hit;
    private GameObject targetWeapon;

    // Use this for initialization
    private void Start ( )
    {
        player = GameObject.FindGameObjectWithTag ( "Player" );
        ARRaycastManager = player.GetComponent<ARRaycastManager> ( );
        ARPlaneManager = player.GetComponent<ARPlaneManager> ( );

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
                Vector3 touch3DPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));

                if ( Physics.Raycast ( touch3DPosition , Vector3.forward , out hit ) )
                {
                    targetWeapon = hit.collider.gameObject;

                }
            }

            if ( ARRaycastManager.Raycast ( touch.position , hitList , TrackableType.PlaneWithinBounds ) )
            {
                ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

                Pose p = hitList[0].pose;

                if ( arPlane.alignment == PlaneAlignment.Vertical )
                {
                    SpawnWeapon ( targetWeapon , p );
                }
            }
        }

        Vector3 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        if ( ARRaycastManager.Raycast ( screenCenter , hitList , TrackableType.PlaneWithinBounds ) )
        {
            ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

            Pose p = hitList[0].pose;

            if ( arPlane.alignment == PlaneAlignment.HorizontalUp )
            {
                SpawnWeaponStore ( p );
            }

        }

    }

    private void SpawnWeapon ( GameObject targetWeaponGO , Pose pose )
    {
        if ( targetWeaponGO != null )
        {
            Destroy ( targetWeaponGO.gameObject , 2f );
        }

        GameObject targetWeapon = Instantiate(targetWeaponGO, pose.position, pose.rotation) as GameObject;
        targetWeapon.SetActive ( true );
    }

    private void SpawnWeaponStore ( Pose p )
    {
        if ( weaponStore != null )
        {
            Destroy ( weaponStore.gameObject , 2f );
        }

        weaponStore = Instantiate ( weaponStoreGO , p.position , p.rotation ) as GameObject;
        weaponStore.SetActive ( true );
    }

}