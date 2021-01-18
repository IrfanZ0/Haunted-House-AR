using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlamingSwordDamage : MonoBehaviour
{
    ParticleSystem psRedFlame;
    List<ParticleCollisionEvent> collisionEvents;
    public GameObject redFireGO;
    private GameObject redFire;

    // Start is called before the first frame update
    void Start()
    {
        psRedFlame = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        int numColl = psRedFlame.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numColl; i++)
        {
            Vector3 hitPos = collisionEvents[i].intersection;

            redFire = Instantiate(redFireGO, hitPos, Quaternion.identity) as GameObject;

            if (other.CompareTag("Player"))
            {
                PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();

                pHealth.Damage(3f);
            }

        }
        
    }

}
