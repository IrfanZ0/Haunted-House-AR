using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallKyle : MonoBehaviour
{
    public GameObject kyleGO;
    private GameObject kyle;
    // Image kyleImage;
    Transform kyleSpawnSpot;
    

    private void Start()
    {
        // kyleImage = GameObject.FindGameObjectWithTag("Player").transform.Find("Canvas").transform.Find("Status Panel").transform.Find("Kyle Help").transform.Find("Kyle").GetComponent<Image>();
        kyleSpawnSpot = GameObject.Find("Kyle Spawn Spot").transform;
    }



    public void Appear()
   {
        kyle = Instantiate(kyleGO, kyleSpawnSpot.position, kyleSpawnSpot.rotation) as GameObject;
        //kyleImage.gameObject.SetActive(false);

   }
}
