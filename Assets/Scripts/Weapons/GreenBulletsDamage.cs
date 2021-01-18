using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBulletsDamage : MonoBehaviour
{
 
    ParticleSystem psGreenBullet;
    List<ParticleCollisionEvent> pCollEvents;
    public GameObject fireExplosion;
    private GameObject explosion;
   

    // Start is called before the first frame update
    void Start()
    {
        psGreenBullet = GetComponent<ParticleSystem>();
        pCollEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisions = psGreenBullet.GetCollisionEvents(other, pCollEvents);

        for (int i = 0; i < numCollisions; i++)
        {
            Vector3 hitPoint = pCollEvents[i].intersection;

            explosion = Instantiate(fireExplosion, hitPoint, Quaternion.identity) as GameObject;
            ParticleSystem psFireExplosion = explosion.transform.Find("Explosion").GetComponent<ParticleSystem>();

            if (!psFireExplosion.isPlaying)
            {
                psFireExplosion.Play();
            }
            
            AudioSource GreenBulletSound = explosion.GetComponent<AudioSource>();

            if (!GreenBulletSound.isPlaying)
            {
                GreenBulletSound.Play();
            }

        }

        if (other.CompareTag("Player"))
        {
            PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();
            pHealth.Damage(3f);
        }
    }
}


