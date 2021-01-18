using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleFlamingSwordDamage : MonoBehaviour
{
    ParticleSystem psPurpleFlame;
    List<ParticleCollisionEvent> collisionEvents;
    public GameObject purpleFireGO;
    private GameObject purpleFire;

    // Start is called before the first frame update
    void Start()
    {
        psPurpleFlame = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        int numColl = psPurpleFlame.GetCollisionEvents(other, collisionEvents);

        for (int i = 0; i < numColl; i++)
        {
            Vector3 hitPos = collisionEvents[i].intersection;

            purpleFire = Instantiate(purpleFireGO, hitPos, Quaternion.identity) as GameObject;

            if (other.CompareTag("Player"))
            {
                PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();

                pHealth.Damage(3f);
            }

        }
        
    }

}
