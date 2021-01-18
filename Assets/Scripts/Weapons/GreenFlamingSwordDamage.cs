using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFlamingSwordDamage : MonoBehaviour
{
    ParticleSystem psGreenFlame;
    List<ParticleCollisionEvent> collisionEvents;
    public GameObject greenFireGO;
    private GameObject greenFire;

    // Start is called before the first frame update
    void Start()
    {
        psGreenFlame = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        int numColl = psGreenFlame.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numColl; i++)
        {
            Vector3 hitPos = collisionEvents[i].intersection;

            greenFire = Instantiate(greenFireGO, hitPos, Quaternion.identity) as GameObject;

            if (other.CompareTag("Player"))
            {
                PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();

                pHealth.Damage(4f);
            }

        }
        
    }

}
