using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullets : MonoBehaviour {

    Rigidbody rbBullet;
    float thrust;
	void Start()
    {
        rbBullet = GetComponent<Rigidbody>();
        thrust = 2.5f;

    }
	
	
	void FixedUpdate () {

        rbBullet.AddForce(thrust * -1f * transform.forward);

  	
	}
}
