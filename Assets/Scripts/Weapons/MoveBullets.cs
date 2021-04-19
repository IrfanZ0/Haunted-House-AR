using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullets : MonoBehaviour
{

    private Rigidbody rbBullet;
    private float thrust;

    private void Start ( )
    {
        rbBullet = GetComponent<Rigidbody> ( );
        thrust = 75f;

    }

    private void FixedUpdate ( )
    {
        rbBullet.AddForce ( thrust * Vector3.forward );

    }
}