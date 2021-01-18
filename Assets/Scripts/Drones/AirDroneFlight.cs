using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDroneFlight : MonoBehaviour
{
   
    GameObject rightBlade;
   

    // Start is called before the first frame update
    void Start()
    {
       
        rightBlade = GameObject.FindGameObjectWithTag("Air Drone").transform.Find("PA_Drone").transform.Find("PA_DroneWingRight").transform.Find("PA_DroneBladeRight").gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
       
      //  rightBlade.transform.localRotation = rotation;
       
        
    }
}
