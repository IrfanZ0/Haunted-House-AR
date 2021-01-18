using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LancerHealth : MonoBehaviour
{
    Slider lifeSlider;
    Animator lancerAnim;
    public GameObject explosion;
    AudioSource bulletExplosionSound;
    ParticleSystem bulletPS;
    AudioSource swordStrikeSound;
    public GameObject magicSword;
    AudioSource[] aSource;
    public GameObject chargedBoltSpell;
    ParticleSystem chargedBallSpellPS;
    AudioSource chargedBallSound;
    float total_health = 100f;
    float current_health;
    public GameObject explosionGO;
    ParticleSystem fireShrapnelPS;
    
   

    // Use this for initialization
    void Start()
    {
        
        lifeSlider = transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>();
        
        current_health = total_health;
        
        lancerAnim = GetComponent<Animator>();
        bulletPS = explosion.GetComponentInChildren<ParticleSystem>();
        bulletExplosionSound = explosion.GetComponent<AudioSource>();
        aSource = new AudioSource[2];

        for (int i = 0; i < aSource.Length; i++)
        {
            AudioSource audioTemp = magicSword.GetComponentInChildren<AudioSource>();
            aSource[i] = audioTemp;

            if (aSource[i].clip.name == "Swords Collide")
            {
                swordStrikeSound = aSource[i];
            }
        }

        chargedBallSpellPS = chargedBoltSpell.transform.Find("ChargedBoltStart").transform.Find("ChargedBoltEmissionParticleSystem").GetComponent<ParticleSystem>();
        chargedBallSound = chargedBoltSpell.transform.Find("ChargedBoltStart").transform.Find("ChargedBoltSound").GetComponent<AudioSource>();

    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Bullets"))
        {
            Damage ( 1f );


            foreach ( ContactPoint contact in coll.contacts )
            {
                Vector3 hitPoint = contact.point;
                explosion = Instantiate ( explosionGO , hitPoint , Quaternion.identity ) as GameObject;
                bulletPS = explosion.transform.Find ( "FireExplosion" ).transform.Find ( "Explosion" ).GetComponent<ParticleSystem> ( );

                if ( !bulletPS.isPlaying )
                {
                    bulletPS.Play ( );
                }

                fireShrapnelPS = explosion.transform.Find ( "FireExplosion" ).transform.Find ( "FireShrapnel" ).GetComponent<ParticleSystem> ( );

                if ( !fireShrapnelPS.isPlaying )
                {
                    fireShrapnelPS.Play ( );
                }

                bulletExplosionSound = explosion.transform.Find ( "FireExplosion" ).GetComponent<AudioSource> ( );

                if ( !bulletExplosionSound.isPlaying )
                {
                    bulletExplosionSound.Play ( );
                }

               

            }

           

        }

        if (coll.collider.CompareTag("Magic Sword"))
        {
            Damage(1f);

        }

        if (coll.collider.CompareTag("Lightning Bolt"))
        {
            Damage(3f);

        }
    }

    private void OnCollisionExit ( Collision collision )
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            lancerAnim.SetTrigger ( "Damage" );
        }
    }

    public void Damage(float damage)
    {
        current_health -= damage;
       
    }

    public float GetCurrentHealth()
    {
        return current_health;
    }

    private void Update ( )
    {
        lifeSlider.value = current_health;

        if ( lifeSlider.value < 1f )
        {
            lancerAnim.SetBool ( "isDead" , true );
            Destroy ( gameObject , 2f );
        }
    }
}
