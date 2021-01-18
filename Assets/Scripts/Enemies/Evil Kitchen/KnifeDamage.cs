
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeDamage : MonoBehaviour
{

    Slider lifeSlider;
    Animator knifeAnim;
    public GameObject explosion;
    AudioSource bulletExplosionSound;
    ParticleSystem bulletPS;
    AudioSource swordStrikeSound;
    public GameObject magicSword;
    AudioSource[] aSource;
    public GameObject chargedBoltSpell;
    ParticleSystem chargedBallSpellPS;
    AudioSource chargedBallSound;

    // Use this for initialization
    void Start()
    {
        lifeSlider = gameObject.GetComponentInChildren<Slider>();
        knifeAnim = gameObject.GetComponent<Animator>();
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
        if (coll.collider.CompareTag("Bullets"))
        {
            Damage(1f);

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

    public void Damage(float damage)
    {
        lifeSlider.value -= 3f;
        knifeAnim.SetTrigger("Damage");

        if (lifeSlider.value < 1f)
        {
            knifeAnim.SetBool("isDead", true);
            Destroy(gameObject, 2f);
        }

    }

}

