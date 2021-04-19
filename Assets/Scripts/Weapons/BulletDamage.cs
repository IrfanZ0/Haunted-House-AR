using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{

    private void OnTriggerEnter ( Collider other )
    {
        GameObject enemy = other.gameObject;

        if ( enemy.CompareTag ( "Lancer" ) )
        {
            LancerHealth lHealth =   enemy.GetComponentInChildren<LancerHealth> ( );
            lHealth.TakeDamage ( 3f );
            Animator lancerAnim =  enemy.GetComponent<Animator> ( );
            lancerAnim.SetTrigger ( "Hit Lancer" );

        }

        if ( enemy.CompareTag ( "Dragon" ) )
        {
            if ( enemy.name == "Baby Fire Dragon" )
            {
                FireDragonHealth fDragonHealth =   enemy.GetComponentInChildren<FireDragonHealth> ( );
                fDragonHealth.Damage ( 6f );
                Animator fireDragonAnim =  enemy.GetComponent<Animator> ( );
                fireDragonAnim.SetTrigger ( "hit" );
            }
            if ( enemy.name == "Baby Ice Dragon" )
            {
                IDragonHealth iDragonHealth =   enemy.GetComponentInChildren<IDragonHealth> ( );
                iDragonHealth.Damage ( 7f );
                Animator iceDragonAnim =  enemy.GetComponent<Animator> ( );
                iceDragonAnim.SetTrigger ( "hit" );
            }

        }

        if ( enemy.CompareTag ( "Blue Knight" ) )
        {
            enemy.GetComponentInChildren<BlueKnightHealth> ( ).Damage ( 1f );

        }

        if ( enemy.CompareTag ( "Red Knight" ) )
        {
            enemy.GetComponentInChildren<RedKnightHealth> ( ).Damage ( 1f );

        }

        if ( enemy.CompareTag ( "Bat" ) )
        {
            BatHealth bHealth =   enemy.GetComponentInChildren<BatHealth> ( );
            bHealth.Damage ( 4f );
            Animator batAnim =  enemy.GetComponent<Animator> ( );
            batAnim.SetBool ( "Bat Fly" , false );
            batAnim.SetTrigger ( "Bat Damage" );

        }

        if ( enemy.CompareTag ( "Demon" ) )
        {
            DemonHealth dHealth =   enemy.GetComponentInChildren<DemonHealth> ( );
            dHealth.Damage ( 5f );
            Animator demonAnim =  enemy.GetComponent<Animator> ( );
            demonAnim.SetBool ( "Idle_Demon_Lord" , true );
            demonAnim.SetTrigger ( "Damage Demon Lord" );

        }

        if ( enemy.CompareTag ( "Buba" ) )
        {
            if ( enemy.name == "Fire Buba" )
            {
                FireBubaHealth fBubaHealth =  enemy.GetComponentInChildren<FireBubaHealth> ( );
                fBubaHealth.Damage ( 2f );
                Animator fBubaAnim = enemy.GetComponent<Animator>();

            }
            if ( enemy.name == "Ice Buba" )
            {
                IceBubaHealth iBubaHealth =  enemy.GetComponentInChildren<IceBubaHealth> ( );
                iBubaHealth.Damage ( 2f );
                Animator iBubaAnim = enemy.GetComponent<Animator>();
            }

            if ( enemy.name == "Lightning Buba" )
            {
                LightningBubaHealth lBubaHealth =  enemy.GetComponentInChildren<LightningBubaHealth> ( );
                lBubaHealth.Damage ( 2f );
                Animator lBubaAnim = enemy.GetComponent<Animator>();
            }

        }

        if ( enemy.CompareTag ( "Ghost" ) )
        {
            GhostHealth ghostHealth =   enemy.GetComponentInChildren<GhostHealth> ( );
            ghostHealth.Damage ( 4f );
            Animator ghostAnim =  enemy.GetComponent<Animator> ( );
            ghostAnim.SetBool ( "Visible_Ghost" , false );

        }

        if ( enemy.CompareTag ( "Spider" ) )
        {
            SpiderHealth spiderHealth =   enemy.GetComponentInChildren<SpiderHealth> ( );
            spiderHealth.Damage ( 5f );
            Animator spiderAnim =  enemy.GetComponent<Animator> ( );
            spiderAnim.SetBool ( "spiderWalk" , false );
            spiderAnim.SetTrigger ( "spiderHit" );

        }

        if ( enemy.CompareTag ( "Skeleton" ) )
        {
            SkeletonHealth skeletonHealth =   enemy.GetComponentInChildren<SkeletonHealth> ( );
            skeletonHealth.Damage ( 6f );
            Animator skeletonAnim =  enemy.GetComponent<Animator> ( );
            skeletonAnim.SetBool ( "isWalking_Skeleton" , false );
            skeletonAnim.SetTrigger ( "Damage_Skeleton" );

        }

    }

    private void OnTriggerExit ( Collider coll )
    {
        GameObject enemy = coll.GetComponent<Collider>().gameObject;

        if ( enemy.CompareTag ( "Bat" ) )
        {
            enemy.GetComponent<Animator> ( ).SetBool ( "Bat Fly" , true );
        }
        if ( enemy.CompareTag ( "Lancer" ) )
        {
            enemy.GetComponent<Animator> ( ).SetFloat ( "Speed_Lancer" , 15f );
        }
        if ( enemy.CompareTag ( "Dragon" ) )
        {
            if ( enemy.name == "Baby Fire Dragon" )
            {
                enemy.GetComponent<Animator> ( ).SetBool ( "isFlying" , true );
            }

            if ( enemy.name == "Baby Ice Dragon" )
            {
                enemy.GetComponent<Animator> ( ).SetBool ( "Flying" , true );
            }
        }

        if ( enemy.CompareTag ( "Ghost" ) )
        {
            Animator ghostAnim =  enemy.GetComponent<Animator> ( );
            ghostAnim.SetBool ( "Visible_Ghost" , true );
            ghostAnim.SetFloat ( "Power_Ghost" , 0 );
        }

        if ( enemy.CompareTag ( "Spider" ) )
        {
            Animator spiderAnim =  enemy.GetComponent<Animator> ( );
            spiderAnim.SetBool ( "spiderWalk" , true );
        }

        if ( enemy.CompareTag ( "Skeleton" ) )
        {
            Animator skeletonAnim =  enemy.GetComponent<Animator> ( );
            skeletonAnim.SetBool ( "isWalking_Skeleton" , true );
            skeletonAnim.SetFloat ( "Speed_Skeleton" , 0.5f );
        }

        if ( enemy.CompareTag ( "Demon" ) )
        {
            Animator demonAnim =  enemy.GetComponent<Animator> ( );
            demonAnim.SetBool ( "Idle_Demon_Lord" , false );

        }
    }
}