using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBladeRotation : MonoBehaviour
{
    GameObject leftBlade;
    private float speed;
    private float angle;
    GameObject leftWing;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        leftBlade = transform.Find("PA_DroneBladeLeft").gameObject;
        angle = 0f;
        leftWing = GameObject.FindGameObjectWithTag("Air Drone").transform.Find("PA_Drone").transform.Find("PA_DroneWingLeft").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        var rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));


         //transform.localEulerAngles(rotation);
         //transform.RotateAround(transform.position, transform.parent.up, speed * Time.deltaTime);

    }
}
