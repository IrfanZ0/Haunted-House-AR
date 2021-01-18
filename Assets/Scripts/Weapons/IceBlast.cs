using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlast : MonoBehaviour
{
    public GameObject iceGO;
    private GameObject ice;
    ParticleSystem psIce;
    AudioSource iceSound;

   public void Fire()
   {
        if (ice == null)
        {
            ice = Instantiate(iceGO, transform.position, transform.rotation) as GameObject;
            psIce = ice.transform.Find("FlameStrikeMainColumn").GetComponent<ParticleSystem>();

            if (!psIce.isPlaying)
            {
                psIce.Play();
            }

            iceSound = ice.GetComponent<AudioSource>();

            if (!iceSound.isPlaying)
            {
                iceSound.Play();
            }

        }

   }
}
