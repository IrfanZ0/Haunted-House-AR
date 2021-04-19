using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaunchPotionTest : MonoBehaviour
{
    public GameObject target;
    private float powerFactor;

    //public FireButtonPress fbPress;
    private Rigidbody rbPotion;

    //// Start is called before the first frame update
    //private void Start ( )
    //{

    //    powerFactor = 20f;

    //    rbPotion = GetComponent<Rigidbody> ( );

    //}

    //// Update is called once per frame
    //private void FixedUpdate ( )
    //{
    //    if ( gameObject.activeSelf && gameObject.tag == "Potion" )
    //    {
    //        //Calculate force from velocity using Force = mass * (Velocity / Time)

    //        Vector3 potionVelocity = CalculateVelocity();

    //        if ( fbPress.isPotionLaunched ( ) && potionVelocity != null )
    //        {
    //            Vector3 force = rbPotion.mass * (potionVelocity / Time.time);
    //            rbPotion.AddForce ( force );
    //        }

    //    }

    //}

    public Vector3 CalculateVelocity ( )
    {
        Vector3 potionPosition = transform.position;
        Vector3 targetPosition = target.transform.position;

        float range = Vector3.Distance(potionPosition, targetPosition);
        float gravity = Physics.gravity.y;
        float launchAngle = 135f;
        float angle = Mathf.Tan(launchAngle * Mathf.Deg2Rad);
        float height = target.transform.position.y - transform.position.y;

        float Vy = angle * Mathf.Sqrt(-1 * (gravity * Mathf.Pow(range, 2.0f) / (2.0f * (height - range * angle))));
        float Vz = Mathf.Sqrt(-1 * (gravity * Mathf.Pow(range, 2.0f) / (2.0f * (height - range * angle))));

        Vector3 velocity = transform.TransformDirection(new Vector3(0, Vy, Vz));

        return velocity;

    }
}