using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ghost"))
        {

        }

        if (collision.collider.CompareTag("Appliances")  && collision.collider.name == "fridge")
        {

        }

        if (collision.collider.CompareTag("Skeleton"))
        {

        }

        if (collision.collider.CompareTag("Ghost"))
        {

        }

        if (collision.collider.CompareTag("Appliances") && collision.collider.name == "microwave")
        {

        }

        if (collision.collider.CompareTag("Appliances") && collision.collider.name == "stove")
        {

        }

        if (collision.collider.CompareTag("Buba"))
        {

        }

        if (collision.collider.CompareTag("Demon"))
        {

        }

        if (collision.collider.CompareTag("Dragon"))
        {

        }

        if (collision.collider.CompareTag("Lancer"))
        {

        }

        if (collision.collider.CompareTag("Ghost"))
        {

        }


    }
}
