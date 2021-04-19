using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceBubaAttack : MonoBehaviour
{
    public GameObject iceFlameGO;
    private GameObject iceFlame;
    private Animator animator;
    private Transform iceSpot;

    // Start is called before the first frame update
    private void Start ( )
    {
        animator = GetComponent<Animator> ( );
        iceSpot = transform.Find ( "Ice Spot" );
    }

    private void Update ( )
    {

        if ( animator.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "Root|Attack" ) )
        {
            if ( iceFlame == null )
            {
                iceFlame = Instantiate ( iceFlameGO ) as GameObject;
                iceFlame.transform.parent = iceSpot.transform;
                iceFlame.transform.localPosition = Vector3.zero;
                iceFlame.transform.rotation = Quaternion.Euler ( 0 , 270f , 0 );

            }

            if ( iceFlame.CompareTag ( "Ice Blast" ) )
            {
                ShootIceFlame ( iceFlame );
            }

        }
    }

    private void ShootIceFlame ( GameObject iceFlame )
    {
        ParticleSystem psIceFlame = iceFlame.GetComponent<ParticleSystem>();
        ParticleSystem psIceBlast = iceFlame.transform.Find("SubBlast01_ice").GetComponent<ParticleSystem>();
        ParticleSystem psIceFlakes = iceFlame.transform.Find("SubBlast01_ice_flakes").GetComponent<ParticleSystem>();
        ParticleSystem psIceFoam = iceFlame.transform.Find("SubBlast01_ice_foam").GetComponent<ParticleSystem>();
        ParticleSystem psIceLeak = iceFlame.transform.Find("SubBlast01_ice_leak").GetComponent<ParticleSystem>();

        if ( !psIceFlame.isPlaying )
        {
            psIceFlame.Play ( );
        }

        if ( !psIceBlast.isPlaying )
        {
            psIceBlast.Play ( );
        }
        if ( !psIceFlakes.isPlaying )
        {
            psIceFlakes.Play ( );
        }
        if ( !psIceFoam.isPlaying )
        {
            psIceFoam.Play ( );
        }
        if ( !psIceLeak.isPlaying )
        {
            psIceLeak.Play ( );
        }

    }
}