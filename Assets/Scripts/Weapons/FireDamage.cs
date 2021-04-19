using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    private ParticleSystem psSmallFire;
    private List<ParticleCollisionEvent> pCollEvents;
    private AudioSource fireSound;

    // Start is called before the first frame update
    private void Start ( )
    {
        fireSound = transform.root.transform.Find ( "SmallFiresSound" ).GetComponent<AudioSource> ( );
        psSmallFire = GetComponent<ParticleSystem> ( );
        pCollEvents = new List<ParticleCollisionEvent> ( );
    }

    private void OnParticleCollision ( GameObject other )
    {

        int numCollisions = psSmallFire.GetCollisionEvents(other, pCollEvents);

        for ( int i = 0 ; i < numCollisions ; i++ )
        {
            if ( !fireSound.isPlaying )
            {
                fireSound.Play ( );
            }

        }

        if ( other.tag == "Player" )
        {
            PlayerHealth pHealth = GameObject.FindGameObjectWithTag("Player Life").transform.Find("Player Health Bar").GetComponent<PlayerHealth>();
            pHealth.Damage ( 4f );
        }

        if ( other.tag == "Buba" )
        {
            if ( other.name == "Fire Buba" )
            {
                FireBubaHealth fbHealth = other.GetComponent<FireBubaHealth>();
                fbHealth.Damage ( 1f );
            }
            if ( other.name == "Lightning Buba" )
            {
                LightningBubaHealth lHealth = other.GetComponent<LightningBubaHealth>();
                lHealth.Damage ( 2f );
            }
            if ( other.name == "Ice Buba" )
            {
                IceBubaHealth fbHealth = other.GetComponent<IceBubaHealth>();
                fbHealth.Damage ( 6f );
            }

        }

        if ( other.tag == "Dragon" )
        {
            if ( other.name == "Baby Fire Dragon" )
            {
                FireDragonHealth fDragonHealth = other.GetComponent<FireDragonHealth> ( );
                fDragonHealth.Damage ( 1f );

            }

            if ( other.name == "Baby Ice Dragon" )
            {
                IDragonHealth iDragonHealth = other.GetComponent<IDragonHealth> ( );
                iDragonHealth.Damage ( 6f );

            }
        }

        if ( other.tag == "Blue Knight" )
        {
            BlueKnightHealth bkHealth = other.GetComponent<BlueKnightHealth>();
            bkHealth.Damage ( 3f );
        }

        if ( other.tag == "Red Knight" )
        {
            RedKnightHealth rkHealth = other.GetComponent<RedKnightHealth>();
            rkHealth.Damage ( 3f );
        }

        if ( other.tag == "Bat" )
        {
            BatHealth bHealth = other.GetComponent<BatHealth>();
            bHealth.Damage ( 2f );
        }

        if ( other.tag == "Demon" )
        {
            DemonHealth demonHealth = other.GetComponent<DemonHealth>();
            demonHealth.Damage ( 4f );
        }

        if ( other.tag == "Ghost" )
        {
            GhostHealth gHealth = other.GetComponent<GhostHealth>();
            gHealth.Damage ( 5f );

        }

        if ( other.tag == "Lancer" )
        {
            LancerHealth lHealth = other.GetComponent<LancerHealth>();
            lHealth.TakeDamage ( 3f );
        }

        if ( other.tag == "Skeleton" )
        {
            SkeletonHealth skeletonHealth = other.GetComponent<SkeletonHealth>();
            skeletonHealth.Damage ( 4f );
        }

    }
}