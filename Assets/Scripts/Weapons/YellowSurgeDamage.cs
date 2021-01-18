using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSurgeDamage : MonoBehaviour
{
 
    ParticleSystem psYellowSurge;
    List<ParticleCollisionEvent> pCollEvents;
    public GameObject yellowFireGO;
    private GameObject yellowFire;

    // Start is called before the first frame update
    void Start()
    {
       psYellowSurge = GetComponent<ParticleSystem>();
        pCollEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisions =psYellowSurge.GetCollisionEvents(other, pCollEvents);

        for (int i = 0; i < numCollisions; i++)
        {
            Vector3 hitPoint = pCollEvents[i].intersection;

            yellowFire = Instantiate(yellowFireGO, hitPoint, Quaternion.identity) as GameObject;
            ParticleSystem psYellowFire = yellowFire.transform.Find("SmallFiresParticleSystem").GetComponent<ParticleSystem>();

            if (!psYellowFire.isPlaying)
            {
               psYellowFire.Play();
            }

            AudioSource yellowFireSound = yellowFire.transform.Find("SmallFiresSound").GetComponent<AudioSource>();

            if (!yellowFireSound.isPlaying)
            {
                yellowFireSound.Play();
            }

        }

        if (other.CompareTag("Player"))
        {
            if ( other.GetComponent<Collider>().CompareTag ( "Power Surge" ) )
            {
                PlayerHealth pHealth = other.GetComponent<PlayerHealth>();
                pHealth.Damage ( 4f );
            }
           
        }
    }
}


