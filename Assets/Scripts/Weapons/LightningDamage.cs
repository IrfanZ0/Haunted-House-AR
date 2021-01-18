using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class LightningDamage : MonoBehaviour
{
    ParticleSystem psLightning;
    List<ParticleCollisionEvent> pCollEvents;
    public GameObject lElectrocutionGO;
    private GameObject lElectrocution;

    // Start is called before the first frame update
    void Start()
    {
        psLightning = GetComponent<ParticleSystem>();
        pCollEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisions = psLightning.GetCollisionEvents(other, pCollEvents);

        for (int i = 0; i < numCollisions; i++)
        {
            Vector3 hitPoint = pCollEvents[i].intersection;

            lElectrocution = Instantiate(lElectrocutionGO, hitPoint, Quaternion.identity) as GameObject;

            LightningBoltScript[] lBoltScripts = lElectrocution.GetComponentsInChildren<LightningBoltScript>();

            foreach (var script in lBoltScripts)
            {
                script.Trigger();

            }

           

            AudioSource lightningSound = lElectrocution.GetComponent<AudioSource>();

            if (!lightningSound.isPlaying)
            {
                lightningSound.Play();
            }

        }

        if (other.CompareTag("Player"))
        {
            PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();
            pHealth.Damage(6f);
        }
    }
}
