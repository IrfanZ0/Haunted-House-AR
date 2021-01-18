using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelLevitation : MonoBehaviour
{
    float thrust;

    // Start is called before the first frame update
    void Start()
    {
        thrust = 20f; 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Treasure"))
        {
            other.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Rigidbody rbJewel = other.GetComponent<Rigidbody>();
            rbJewel.AddForce(Vector3.up * thrust);
           // rbJewel.AddTorque(new Vector3(15f, 30f, 45f));
        }
    }
}
