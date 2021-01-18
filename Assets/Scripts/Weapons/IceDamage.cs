using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDamage : MonoBehaviour
{
    ParticleSystem psIce;
    List<ParticleCollisionEvent> pCollEvents;
    public GameObject IceGO;
    private GameObject Ice;

    // Start is called before the first frame update
    void Start()
    {
        psIce = GetComponent<ParticleSystem>();
        pCollEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisions = psIce.GetCollisionEvents(other, pCollEvents);

        for (int i = 0; i < numCollisions; i++)
        {
            Vector3 hitPoint = pCollEvents[i].intersection;

            Ice = Instantiate(IceGO, hitPoint, Quaternion.identity) as GameObject;
            ParticleSystem psIce = Ice.transform.Find("FlameStrikeMainColumn").GetComponent<ParticleSystem>();

            if (!psIce.isPlaying)
            {
                psIce.Play();
            }

            AudioSource iceSound = Ice.GetComponent<AudioSource>();

            if (!iceSound.isPlaying)
            {
                iceSound.Play();
            }

        }

        if (other.CompareTag("Player"))
        {
            PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();
            pHealth.Damage(4f);
        }
    }
}
