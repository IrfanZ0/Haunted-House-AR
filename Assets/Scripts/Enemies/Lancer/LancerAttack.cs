using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LancerAttack : MonoBehaviour
{
    private Animator lancerAnim;
    private NavMeshAgent lancerNavMesh;
    private LancerHealth lancerHealth;
    private ParticleSystem psGreenMagicCircle;
    private ParticleSystem psGreenFlamingSword;
    private ParticleSystem psGreenBullets;
    private ParticleSystem psYellowMagicCircle;
    private ParticleSystem psYellowSurge;

    // Use this for initialization
    private void Start ( )
    {

        lancerAnim = GetComponent<Animator> ( );
        lancerNavMesh = GetComponent<NavMeshAgent> ( );
        lancerHealth = GetComponent<LancerHealth> ( );

        foreach ( Transform child in gameObject.GetComponentsInChildren<Transform> ( ) )
        {
            if ( child.name == "magic_ring_green" )
            {
                psGreenMagicCircle = child.GetComponent<ParticleSystem> ( );

            }

            if ( child.name == "magic_ring_yellow" )
            {
                psYellowMagicCircle = child.GetComponent<ParticleSystem> ( );
            }

            if ( child.name == "yellow surge" )
            {
                psYellowSurge = child.GetComponent<ParticleSystem> ( );
            }

            if ( child.name == "Green Bullets 9" )
            {
                psGreenBullets = child.GetComponent<ParticleSystem> ( );
            }
        }

    }

    // private void Update ( )
    //{
    //    float power = GetComponent<Animator>().GetFloat("Power_Lancer");

    //    if ( !psGreenMagicCircle.isPlaying && power >= 25.0f && power < 50.0f )
    //    {
    //        lancerNavMesh.isStopped = true;

    //        psGreenMagicCircle.Play ( );

    //        if ( !psGreenBullets.isPlaying )
    //        {
    //            psGreenBullets.Play ( );
    //        }

    //        StartCoroutine ( GreenPowerOff ( power ) );
    //        lancerNavMesh.isStopped = false;
    //    }

    //    if ( !psYellowMagicCircle.isPlaying && power >= 50.0f )
    //    {
    //        psYellowMagicCircle.Play ( );

    //        if ( !psYellowSurge.isPlaying )
    //        {
    //            psYellowSurge.Play ( );
    //        }

    //        StartCoroutine ( YellowPowerOff ( power ) );

    //    }

    //}

    //private IEnumerator YellowPowerOff ( float power )
    //{
    //    yield return new WaitForSeconds ( 5f );

    //    power = 0;
    //    lancerNavMesh.GetComponent<Animator> ( ).SetFloat ( "Power" , power );

    //    if ( psYellowSurge.isPlaying )
    //    {
    //        psYellowSurge.Stop ( );
    //    }

    //    yield return new WaitForSeconds ( 2f );

    //    if ( psYellowMagicCircle.isPlaying )
    //    {
    //        psYellowMagicCircle.Stop ( );
    //    }
    //}

    //private IEnumerator GreenPowerOff ( float power )
    //{
    //    yield return new WaitForSeconds ( 5f );

    //    power = 0;
    //    lancerNavMesh.GetComponent<Animator> ( ).SetFloat ( "Power" , power );

    //    if ( psGreenBullets.isPlaying )
    //    {
    //        psGreenBullets.Stop ( );
    //    }

    //    yield return new WaitForSeconds ( 2f );

    //    if ( psGreenMagicCircle.isPlaying )
    //    {
    //        psGreenMagicCircle.Stop ( );
    //    }

    //}

    //public void Attack ( float power )
    //{

    //    if ( power < 25.0f )
    //    {

    //        StartCoroutine ( Level1Attack ( ) );
    //        Debug.Log ( "Attack 1 started" );

    //    }

    //}

    //public void Attack2 ( float power )
    //{
    //    if ( power >= 25.0f && power < 50.0f )
    //    {
    //        StartCoroutine ( Level2Attack ( ) );
    //        Debug.Log ( "Attack 2 started" );
    //    }
    //}

    //public void Attack3 ( float power )
    //{
    //    if ( power >= 50.0f )
    //    {

    //        StartCoroutine ( Level3Attack ( ) );
    //        Debug.Log ( "Attack 3 started" );
    //    }
    //}

    //private IEnumerator Level1Attack ( )
    //{
    //    lancerAnim.SetFloat ( "Speed" , 5f );
    //    yield return new WaitForSeconds ( 5f );
    //    lancerAnim.SetTrigger ( "Attack 1" );
    //    yield return new WaitForSeconds ( 10f );
    //    lancerAnim.SetFloat ( "Power" , 0 );
    //}

    //private IEnumerator Level2Attack ( )
    //{
    //    lancerAnim.SetFloat ( "Speed" , 5f );
    //    yield return new WaitForSeconds ( 5f );
    //    lancerAnim.SetTrigger ( "Attack 2" );
    //    lancerAnim.SetFloat ( "Power" , 30.0f );
    //    if ( !psGreenBullets.isPlaying )
    //    {
    //        psGreenBullets.Play ( true );

    //    }
    //    yield return new WaitForSeconds ( 10f );
    //    lancerAnim.SetFloat ( "Power" , 0 );

    //}

    //private IEnumerator Level3Attack ( )
    //{
    //    lancerAnim.SetFloat ( "Speed" , 5f );
    //    yield return new WaitForSeconds ( 5f );
    //    lancerAnim.SetTrigger ( "Attack 3" );
    //    lancerAnim.SetFloat ( "Power" , 60.0f );
    //    if ( !psYellowSurge.isPlaying )
    //    {
    //        psYellowSurge.Play ( true );
    //    }
    //    yield return new WaitForSeconds ( 10f );
    //    lancerAnim.SetFloat ( "Power" , 0 );

    //}

}