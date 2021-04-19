using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBubaAttack : MonoBehaviour
{
    private Animator animator;
    public GameObject flameStrikeGO;
    private GameObject flameStrike;
    private Transform fireSpot;

    // Start is called before the first frame update
    private void Start ( )
    {
        animator = GetComponent<Animator> ( );
        fireSpot = transform.Find ( "Fire Spot" );

    }

    public void Update ( )
    {

        if ( animator.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "Root|Attack" ) )
        {
            if ( flameStrike == null )
            {
                flameStrike = Instantiate ( flameStrikeGO ) as GameObject;
                flameStrike.transform.parent = fireSpot.transform;
                flameStrike.transform.localPosition = Vector3.zero;
                flameStrike.transform.rotation = Quaternion.Euler ( 0 , 270f , 0 );
            }

            ShootFireBall ( flameStrike );

        }
    }

    private void ShootFireBall ( GameObject flameStrike )
    {
        ParticleSystem psFlameStrikeMainColumn = flameStrike.transform.Find("FlameStrikeMainColumn").GetComponent<ParticleSystem>();
        ParticleSystem psFlameStrikeLightColumn = flameStrike.transform.Find("FlameStrieLightColumn").GetComponent<ParticleSystem>();
        ParticleSystem psFireBallExplosion = flameStrike.transform.Find("FireballExplosion").GetComponent<ParticleSystem>();

        if ( !psFlameStrikeMainColumn.isPlaying )
        {
            psFlameStrikeMainColumn.Play ( );
        }

        if ( !psFlameStrikeLightColumn.isPlaying )
        {
            psFlameStrikeLightColumn.Play ( );
        }

        if ( !psFireBallExplosion.isPlaying )
        {
            psFireBallExplosion.Play ( );
        }

    }
}