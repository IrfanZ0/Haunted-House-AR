using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallCollision : MonoBehaviour
{
   void OnCollisionEnter(Collision other)
   {
        if (other.collider.name == "Snow Balls")
        {
            other.collider.gameObject.transform.localScale = new Vector3(0.3f, 0.2f, 0.3f);
        }
   }
}
