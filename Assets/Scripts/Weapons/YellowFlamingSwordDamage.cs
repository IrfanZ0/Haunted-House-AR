using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFlamingSwordDamage : MonoBehaviour
{
    ParticleSystem psYellowFlame;
    List<ParticleCollisionEvent> collisionEvents;
    public GameObject yellowFireGO;
    private GameObject yellowFire;

    // Start is called before the first frame update
    void Start()
    {
        psYellowFlame = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        int numColl = psYellowFlame.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numColl; i++)
        {
            Vector3 hitPos = collisionEvents[i].intersection;

            yellowFire = Instantiate(yellowFireGO, hitPos, Quaternion.identity) as GameObject;

            if (other.CompareTag("Player"))
            {
                PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();

                pHealth.Damage(3f);
            }

        }
        
    }

}
