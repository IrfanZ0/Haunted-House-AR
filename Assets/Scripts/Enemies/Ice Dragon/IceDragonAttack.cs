using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceDragonAttack : MonoBehaviour
{

    private Animator iDragonAnim;
    public GameObject iceFlameGO;
    private GameObject iceFlame;
    private Transform iceSpot;

    // Use this for initialization
    private void Start ( )
    {
        iDragonAnim = GetComponent<Animator> ( );
        iceSpot = transform.Find ( "Ice Spot" );

    }

    private void Update ( )
    {
        if ( iDragonAnim.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "fly breath ice" ) )
        {
            if ( iceFlame == null )
            {
                iceFlame = Instantiate ( iceFlameGO ) as GameObject;
                iceFlame.transform.parent = iceSpot;
                iceFlame.transform.localPosition = Vector3.zero;
                iceFlame.transform.localRotation = Quaternion.identity;

            }

            if ( iceFlame.CompareTag ( "Ice Blast" ) )
            {
                Breathice ( iceFlame );
            }
        }

    }

    private void Breathice ( GameObject iceFlame )
    {
        ParticleSystem psiceFlame = iceFlame.GetComponent<ParticleSystem> ( );
        ParticleSystem psiceBlast = iceFlame.transform.Find("SubBlast01_ice").GetComponent<ParticleSystem>();

        if ( !psiceFlame.isPlaying )
        {
            psiceFlame.Play ( );
        }

        if ( !psiceBlast.isPlaying )
        {
            psiceBlast.Play ( );
        }
    }

}