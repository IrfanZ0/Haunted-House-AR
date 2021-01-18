using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class WeaponStoreSpawn : MonoBehaviour {

    private GameObject weaponStore;
    public GameObject weaponStoreSpawn;
    GameObject player;
    List<ARRaycastHit> hitList;
    ARRaycastManager arRaycastManager;
    ARPlaneManager arPlaneManager;
    
    void Start()
    {
        hitList = new List<ARRaycastHit> ( );
        player = GameObject.FindGameObjectWithTag ( "Player" );
        arRaycastManager = player.GetComponent<ARRaycastManager> ( );
        arPlaneManager = player.GetComponent<ARPlaneManager> ( );
    }

    
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

            if (arRaycastManager.Raycast(touch.position, hitList, TrackableType.Planes))
            {
                ARPlane arPlane = arPlaneManager.GetPlane(hitList[0].trackableId);

                Pose p = hitList[0].pose;

                if (arPlane.alignment == PlaneAlignment.HorizontalUp)
                {
                    SpawnWeaponStore ( p);
                }

            }

        }

                
   }

    private void SpawnWeaponStore(Pose p)
    {
        if (weaponStoreSpawn != null)
        {
            Destroy ( weaponStoreSpawn.gameObject , 2f );
        }

        weaponStore = Instantiate ( weaponStoreSpawn , p.position , p.rotation ) as GameObject;
        weaponStore.SetActive ( true );
    }
}
