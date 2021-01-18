using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    ParticleSystem psFire;
    AudioSource fireSound;
    List<ParticleCollisionEvent> pCollEvents;
   

    // Start is called before the first frame update
    void Start()
    {
        psFire = transform.Find("SmallFiresParticleSystem").GetComponent<ParticleSystem>();
        fireSound = transform.Find("SmallFiresSound").GetComponent<AudioSource>();
        pCollEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {

        int numCollisions = psFire.GetCollisionEvents(other, pCollEvents);

        for ( int i = 0 ; i < numCollisions ; i++ )
        {
            Vector3 hitPositions = pCollEvents[i].intersection;

            switch (other.tag)
            {
                case "Dragon":
                    {
                        if (other.name == "Baby Fire Dragon")
                        {
                            FireDragonHealth fDragonHealth = other.gameObject.transform.Find ( "Canvas" ).transform.Find ( "Health Bar" ).GetComponent<FireDragonHealth> ( );
                            fDragonHealth.Damage ( 1f );
                        }

                        if (other.name == "Baby Ice Dragon")
                        {
                            IDragonHealth iDragonHealth = other.gameObject.transform.Find ( "Canvas" ).transform.Find ( "Health Bar" ).GetComponent<IDragonHealth> ( );
                            iDragonHealth.Damage ( 8f );
                        }
                        break;
                    }
                case "Demon":
                    {
                        DemonHealth demonHealth = other.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<DemonHealth>();
                        demonHealth.Damage ( 9f );
                        break;
                    }
                case "Buba":
                    {
                        if (other.name == "Fire Buba")
                        {
                            FireBubaHealth fBubaHealth = other.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<FireBubaHealth>();
                            fBubaHealth.Damage ( 1f );
                        }

                        if (other.name == "Ice Buba")
                        {
                            IceBubaHealth iBubaHealth = other.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<IceBubaHealth>();
                            iBubaHealth.Damage ( 1f );
                        }

                        if (other.name == "Lightning Buba")
                        {
                            LightningBubaHealth lBubaHealth = other.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<LightningBubaHealth>();
                            lBubaHealth.Damage ( 1f );
                        }

                        break;
                    }
                case "Ghost":
                    {
                        GhostHealth ghostHealth = other.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<GhostHealth>();
                        ghostHealth.Damage ( 6f );
                        break;
                    }
                case "Lancer":
                    {
                        LancerHealth lancerHealth = other.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<LancerHealth>();
                        lancerHealth.Damage ( 7f );
                        break;
                    }
                case "Skeleton":
                    {
                        SkeletonHealth skeletonHealth = other.gameObject.transform.Find("Canvas").transform.Find("Health Bar").GetComponent<SkeletonHealth>();
                        skeletonHealth.Damage ( 5f );
                        break;
                    }
               
            }
        }

       

        if (other.CompareTag("Player"))
        {
            PlayerHealth pHealth = other.transform.Find("Canvas").transform.Find("Panel").transform.Find("Health Bar").GetComponent<PlayerHealth>();
            pHealth.Damage(2f);
        }
    }
}
