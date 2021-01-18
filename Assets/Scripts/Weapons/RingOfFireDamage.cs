using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfFireDamage : MonoBehaviour
{
    ParticleSystem psFire;
    AudioSource fireSound;
    List<ParticleCollisionEvent> pCollEvents;
    ParticleSystem.ShapeModule psShape;
    ParticleSystem.MainModule psMain;
    float currentRadius;
    float newRadius;
    float time = 0;
    private float speed;
    float height;
   
   

    // Start is called before the first frame update
    void Start()
    {
        GameObject ringFire = GameObject.Find("Ring of Death").gameObject;
        psFire = ringFire.transform.Find("RingOfFireFlame").GetComponent<ParticleSystem>();
        fireSound = ringFire.transform.Find("RingOfFireSound").GetComponent<AudioSource>();
        pCollEvents = new List<ParticleCollisionEvent>();
        currentRadius = 2f;
       
        speed = 50f;
        
    }

    void Update()
    {
       
        psShape = psFire.shape;
        psShape.radius = currentRadius;

        time += speed * Time.deltaTime;

        if (time > 5f)
        {
            time = 0;
            currentRadius += 1f;
           
           
        }

    }

   

    void OnParticleCollision(GameObject other)
    {

        if (!psFire.isPlaying)
        {
            psFire.Play();
        }

            

        if (!fireSound.isPlaying)
        {
            fireSound.Play();
        }

       

        if (other.CompareTag("Player"))
        {
            PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();
            pHealth.Damage(2f);
        }
    }
}
