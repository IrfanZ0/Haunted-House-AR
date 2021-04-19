using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMove : MonoBehaviour
{
    private GameObject altar;
    private Transform starTransform;
    private float thrust;
    private Rigidbody rbDiamond;

    // Start is called before the first frame update
    private void Start ( )
    {
        altar = GameObject.FindGameObjectWithTag ( "Altar" );
        thrust = 10f;
        rbDiamond = GetComponent<Rigidbody> ( );
    }

    // Update is called once per frame
    private void FixedUpdate ( )
    {
        if ( altar != null )
        {
            rbDiamond.AddForce ( ( altar.transform.position - transform.position ) * thrust );
        }

    }
}