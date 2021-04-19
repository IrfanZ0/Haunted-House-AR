using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelLevitation : MonoBehaviour
{
    private float thrust;

    // Start is called before the first frame update
    private void Start ( )
    {
        thrust = 25f;
    }

    private void OnTriggerStay ( Collider other )
    {
        if ( other.CompareTag ( "Treasure" ) )
        {
            other.gameObject.transform.localScale = new Vector3 ( 0.5f , 0.5f , 0.5f );
            Rigidbody rbJewel = other.GetComponent<Rigidbody>();
            rbJewel.AddForce ( Vector3.up * thrust , ForceMode.Acceleration );
            // rbJewel.AddTorque(new Vector3(15f, 30f, 45f));
        }
    }
}