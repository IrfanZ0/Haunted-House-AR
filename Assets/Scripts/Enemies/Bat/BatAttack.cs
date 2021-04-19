using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttack : MonoBehaviour
{
    public GameObject poisonGO;
    private GameObject poison;
    private Animator animator;
    private Transform poisonSpot;

    // Start is called before the first frame update
    private void Start ( )
    {
        animator = GetComponent<Animator> ( );
        poisonSpot = transform.Find ( "Poison Spot" );
    }

    private void Update ( )
    {

        if ( animator.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "Root|Attack" ) )
        {
            if ( poison == null )
            {
                SpawnPoison ( );

            }

            if ( poison.CompareTag ( "Vampire Bat Poison" ) )
            {
                ShootPoison ( poison );
            }

        }
    }

    private void SpawnPoison ( )
    {
        poison = Instantiate ( poisonGO ) as GameObject;
        poison.SetActive ( true );
        poison.transform.parent = poisonSpot.transform;
        poison.transform.localPosition = Vector3.zero;
        poison.transform.rotation = Quaternion.Euler ( 0 , 270f , 0 );
    }

    private void ShootPoison ( GameObject poison )
    {
        ParticleSystem pspoison = poison.GetComponent<ParticleSystem>();
        ParticleSystem psIceBlast = poison.transform.Find("SubBlast01_ice").GetComponent<ParticleSystem>();
        ParticleSystem psIceFlakes = poison.transform.Find("SubBlast01_ice_flakes").GetComponent<ParticleSystem>();
        ParticleSystem psIceFoam = poison.transform.Find("SubBlast01_ice_foam").GetComponent<ParticleSystem>();
        ParticleSystem psIceLeak = poison.transform.Find("SubBlast01_ice_leak").GetComponent<ParticleSystem>();

        if ( !pspoison.isPlaying )
        {
            pspoison.Play ( );
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