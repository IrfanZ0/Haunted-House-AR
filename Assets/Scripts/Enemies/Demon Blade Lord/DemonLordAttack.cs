using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DemonLordAttack : MonoBehaviour
{
    Animator demonLordAnim;
    NavMeshAgent demonLordNavMesh;
    float lightIntensity;
    ParticleSystem redMagicCircle;
    ParticleSystem blueMagicCircle;
    ParticleSystem purpleMagicCircle;
    ParticleSystem fireCircle;
    ParticleSystem psPurpleFlamingSword;
    ParticleSystem psPurpleBullets;
    ParticleSystem psBlueFlamingSword;
    ParticleSystem psBlueSnake;
    ParticleSystem psRedFlamingSword;
    ParticleSystem psRedPowerSurge;
    AudioSource fireCircleSound;

    // Use this for initialization
    void Start()
    {

        demonLordAnim = GetComponent<Animator>();
        demonLordNavMesh = GetComponent<NavMeshAgent>();

        foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
        {
            if (child.name == "magic_ring_purple")
            {
                purpleMagicCircle = child.GetComponent<ParticleSystem>();
            }

            if (child.name == "Purple Flaming Sword")
            {
                psPurpleFlamingSword = child.GetComponent<ParticleSystem>();

            }

            if (child.name == "Purple Bullets")
            {
                psPurpleBullets = child.GetComponent<ParticleSystem>();
            }

            if (child.name == "magic_ring_blue")
            {
                blueMagicCircle = child.GetComponent<ParticleSystem>();
            }

            if (child.name == "Blue Flaming Sword")
            {
                psBlueFlamingSword = child.GetComponent<ParticleSystem>();

            }

            if (child.name == "Blue Snake")
            {
                psBlueSnake = child.GetComponent<ParticleSystem>();
            }

            if (child.name == "magic_ring_red")
            {
                redMagicCircle = child.GetComponent<ParticleSystem>();
            }

            if (child.name == "Red Flaming Sword")
            {
                psRedFlamingSword = child.GetComponent<ParticleSystem>();

            }

            if (child.name == "power_surge_red")
            {
                psRedPowerSurge = child.GetComponent<ParticleSystem>();
            }

          
            if (child.name == "Ring of Death")
            {
                fireCircle = child.transform.Find("RingofFireFlame").GetComponent<ParticleSystem>();
                fireCircleSound = child.transform.Find("RingofFireSound").GetComponent<AudioSource>();
            }

           
        }


    }

    public void Attack()
    {
        demonLordNavMesh.velocity = Vector3.zero;

        //lightIntensity = Frame.LightEstimate.PixelIntensity;

        //if (lightIntensity < 0.5f)
        //{
            
        //    ParticleSystem psPurpleMagicCircle = purpleMagicCircle.GetComponent<ParticleSystem>();

        //    if (!psPurpleMagicCircle.isPlaying)
        //    {
        //        psPurpleMagicCircle.Play();
        //    }

        //  //  StartCoroutine(Level4Attack());
        //}

        //else if (lightIntensity >= 0.5f && lightIntensity < 1.0f)
        //{
            
        //    ParticleSystem psBlueMagicCircle = blueMagicCircle.GetComponent<ParticleSystem>();

        //    if (!psBlueMagicCircle.isPlaying)
        //    {
        //        psBlueMagicCircle.Play();
        //    }

        //   StartCoroutine(Level3Attack());
        //}

        //else if (lightIntensity >= 1.0f && lightIntensity < 1.5f)
        //{

        //    ParticleSystem psRedMagicCircle = redMagicCircle.GetComponent<ParticleSystem>();

        //    if (!psRedMagicCircle.isPlaying)
        //    {
        //        psRedMagicCircle.Play();
        //    }

        //  StartCoroutine(Level2Attack());
        //}


        //else
        //{
        //    Level1Attack();
        //}


    }

    private void Level1Attack()
    {
        demonLordAnim.SetFloat("Power", 20.0f);
    }

    IEnumerator Level2Attack()
    {
        if (!psRedFlamingSword.isPlaying)
        {
            psRedFlamingSword.Play();
        }

        yield return new WaitForSeconds(2f);

        demonLordAnim.SetFloat("Power", 40.0f);

        if (!psRedPowerSurge.isPlaying)
        {
            psRedPowerSurge.Play();
        }
    }

    IEnumerator Level3Attack()
    {
        if (!psBlueFlamingSword.isPlaying)
        {
            psBlueFlamingSword.Play();
        }

        yield return new WaitForSeconds(2f);

        demonLordAnim.SetFloat("Power", 75.0f);

        if (!psBlueSnake.isPlaying)
        {
            psBlueSnake.Play();
        }
    }

}

