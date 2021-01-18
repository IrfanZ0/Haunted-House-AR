using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class LancerAttack : MonoBehaviour
{
    Animator lancerAnim;
    NavMeshAgent lancerNavMesh;
    LancerHealth lancerHealth;
    ParticleSystem psGreenMagicCircle;
    ParticleSystem psGreenFlamingSword;
    ParticleSystem psGreenBullets;
    ParticleSystem psYellowMagicCircle;
    ParticleSystem psYellowSurge;
    float timer;

    // Use this for initialization
    void Start()
    {
        timer = 5f;
        lancerAnim = GetComponent<Animator>();
        lancerNavMesh = GetComponent<NavMeshAgent>();
        lancerHealth = GetComponent<LancerHealth> ( );

        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.name == "magic_ring_green")
            {
                psGreenMagicCircle = child.GetComponent<ParticleSystem>();

            }

            if (child.name == "magic_ring_yellow")
            {
                psYellowMagicCircle = child.GetComponent<ParticleSystem>();
            }

            if (child.name == "yellow surge")
            {
                psYellowSurge = child.GetComponent<ParticleSystem>();
            }

            if (child.name == "Green Bullets 9")
            {
                psGreenBullets = child.GetComponent<ParticleSystem>();
            }
        }

        


    }



    private void Update ( )
    {
        float power = GetComponent<Animator>().GetFloat("Power");

        if (!psGreenMagicCircle.isPlaying && power >= 25.0f && power < 50.0f)
        {
            psGreenMagicCircle.Play ( );
           
            if ( !psGreenBullets.isPlaying )
            {
                psGreenBullets.Play ( );

            }

         

        }

       

        if ( !psYellowMagicCircle.isPlaying && power >= 50.0f )
        {
            psYellowMagicCircle.Play ( );

            if ( !psYellowSurge.isPlaying )
            {
                psYellowSurge.Play ( );
            }

           
        }

       
    }

    public void Attack(float power)
    {
       
       if (power < 25.0f )
       {
           
           StartCoroutine(Level1Attack ( ));

       }

       else if (power >= 25.0f && power < 50.0f  )
       {
           
            StartCoroutine(Level2Attack ( ));
       }

       else if ( power >= 50.0f  )
       {
           
           StartCoroutine( Level3Attack ( ));
       }

        else
        {
            lancerNavMesh.isStopped = false;
        }



    }

   

    IEnumerator Level1Attack()
    {
        yield return new WaitForSeconds ( 5f );
        lancerAnim.SetTrigger("Attack 1");
        yield return new WaitForSeconds ( 2f );
        lancerAnim.SetFloat ( "Power" , 0 );
    }

    IEnumerator Level2Attack()
    {
        yield return new WaitForSeconds ( 5f );
        lancerAnim.SetTrigger ( "Attack 2" );
        lancerAnim.SetFloat ( "Power" , 30.0f );
               
        yield return new WaitForSeconds ( 2f );
       
        lancerAnim.SetFloat ( "Power" , 0 );

    }

    IEnumerator Level3Attack()
    {
        yield return new WaitForSeconds ( 5f );
        lancerAnim.SetTrigger ( "Attack 3" );
        lancerAnim.SetFloat ( "Power" , 60.0f );

       
       
        yield return new WaitForSeconds ( 2f );
        
        lancerAnim.SetFloat ( "Power" , 0 );


    }

}
