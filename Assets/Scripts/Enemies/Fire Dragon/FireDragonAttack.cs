using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireDragonAttack : MonoBehaviour
{
    private Animator fDragonAnim;
    public GameObject fireFlameGO;
    private GameObject fireFlame;
    private Transform fireSpot;

    // Use this for initialization
    private void Start ( )
    {
        fDragonAnim = GetComponent<Animator> ( );
        fireSpot = transform.Find ( "Fire Spot" );

    }

    private void Update ( )
    {
        if ( fDragonAnim.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "fly breath fire" ) )
        {
            if ( fireFlame == null )
            {
                fireFlame = Instantiate ( fireFlameGO ) as GameObject;
                fireFlame.transform.parent = fireSpot;
                fireFlame.transform.localPosition = Vector3.zero;

            }

            if ( fireFlame.CompareTag ( "Fire Blast" ) )
            {
                BreathFire ( fireFlame );
            }
        }

    }

    private void BreathFire ( GameObject fireFlame )
    {
        ParticleSystem psFireFlame = fireFlame.GetComponent<ParticleSystem> ( );
        ParticleSystem psFireBlast = fireFlame.transform.Find("SubBlast01_fire").GetComponent<ParticleSystem>();

        if ( !psFireFlame.isPlaying )
        {
            psFireFlame.Play ( );
        }

        if ( !psFireBlast.isPlaying )
        {
            psFireBlast.Play ( );
        }
    }

    private void FlyHit ( )
    {
        fDragonAnim.SetTrigger ( "hit" );

    }

    private void FlyAttack ( )
    {
        fDragonAnim.SetTrigger ( "attack" );
    }
}