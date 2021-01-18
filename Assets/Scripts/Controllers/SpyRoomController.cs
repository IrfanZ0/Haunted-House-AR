using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpyRoomController : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject knightsGO;
    GameObject knights;
    Vector3 [,] knightGroupPositions;
    GameObject[] knightList;
    GameObject player;
    ARRaycastManager arRaycastManager;
    ARPlaneManager ARPlaneManager;
    List<ARRaycastHit> hitList;
    private LightEstimation lightEstimation;
    int height = 10;
    int width = 10;
    RaycastHit hit;
    SkinnedMeshRenderer knightSkinMeshRenderer;
    Vector3 touchPos3D;
    float speed = 1.5f;
    GameObject spyRoom;
    List<GameObject> magicRingList;
    GameObject forceField;
   

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        arRaycastManager = player.GetComponent<ARRaycastManager>();
        ARPlaneManager = player.GetComponent<ARPlaneManager>();
        lightEstimation = player.GetComponent<LightEstimation>();
        hitList = new List<ARRaycastHit>();

    }
    // Start is called before the first frame update
    void Start()
    {
        knightGroupPositions = new Vector3[width, height];
        knightList = new GameObject[20];
        spyRoom = GameObject.Find("Spy Room");
        magicRingList = new List<GameObject>();

        foreach (var child in spyRoom.transform.GetComponentsInChildren<Transform>())
        {
            if (child.name.Contains("magic_ring"))
            {
                magicRingList.Add(child.gameObject);
            }

            if (child.name == "Force Field")
            {
                forceField = child.gameObject;
            }
        }

       
        for (int y = 0; y < height; y++)
        {           
            for (int x = 0; x < width; x++)
            {
                knights = Instantiate(knightsGO) as GameObject;                
                knights.transform.position = transform.position + new Vector3(3 * x - 5f, 0, 6 * y - 3f);
                knights.transform.rotation = Quaternion.identity;
            }
           

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in magicRingList)
        {
            if (item.gameObject.activeSelf == false)
            {
                ParticleSystem forceFieldPS = forceField.transform.GetComponent<ParticleSystem>();
                
                if (forceFieldPS.isPlaying)
                {
                    forceFieldPS.Stop();
                }
            }
        }
       
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            if (Input.touchCount < 1 || (touch.phase != TouchPhase.Began))
            {
                return;
            }

            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;

            }

            if (touch.phase == TouchPhase.Began)
            {
                touchPos3D = arCamera.GetComponent<Camera>().ScreenToWorldPoint(touch.position);

            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (Physics.Raycast(touchPos3D, Vector3.forward, out hit))
                {
                    if (hit.collider.CompareTag("Knight"))
                    {
                        Vector3 knightPosition = hit.collider.gameObject.transform.position;
                        knightPosition = Vector3.Lerp(knightPosition, knightPosition, speed * Time.deltaTime);
                    }
                }
            }

        }


        Vector3 screenCenter = arCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        
        

        if (arRaycastManager.Raycast(screenCenter, hitList, TrackableType.PlaneWithinBounds))
        {
            ARPlane arPlane = ARPlaneManager.GetPlane(hitList[0].trackableId);

            Pose p = hitList[0].pose;

           

                if (lightEstimation.brightness.Value > 0.6f)
                {
                    Ray detector = new Ray(arPlane.transform.position, Vector3.up);

                    if (arPlane.GetComponent<MeshCollider>().Raycast(detector, out hit, 10f))
                    {
                        if (hit.collider.gameObject.CompareTag("Knight"))
                        {
                            knightSkinMeshRenderer = hit.collider.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
                            MaterialExtensions.ToFadeMode(knightSkinMeshRenderer.sharedMaterial);
                        }

                        else
                        {
                            MaterialExtensions.ToOpaqueMode(knightSkinMeshRenderer.sharedMaterial);
                        }

                    }
                    
                }

        }

         
        // Exit the app when the 'back' button is pressed.
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
}
