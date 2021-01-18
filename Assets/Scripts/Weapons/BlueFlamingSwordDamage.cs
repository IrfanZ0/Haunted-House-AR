using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFlamingSwordDamage : MonoBehaviour
{
    ParticleSystem psBlueFlame;
    List<ParticleCollisionEvent> collisionEvents;
    public GameObject blueFireGO;
    private GameObject blueFire;

    // Start is called before the first frame update
    void Start()
    {
        psBlueFlame = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        int numColl = psBlueFlame.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numColl; i++)
        {
            Vector3 hitPos = collisionEvents[i].intersection;

            blueFire = Instantiate(blueFireGO, hitPos, Quaternion.identity) as GameObject;

            if (other.CompareTag("Player"))
            {
                PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();

                pHealth.Damage(3f);
            }

        }
        
    }

}
