using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.ThunderAndLightning;

public class LightningBlast : MonoBehaviour
{
    public GameObject lightningBoltGO;
    private GameObject lightningBolt;
    LightningBoltPathScript lbpScript;
    AudioSource lightningSound;

    public void Fire()
    {
        if (lightningBolt== null)
        {
            lightningBolt = Instantiate(lightningBoltGO, transform.position, transform.rotation) as GameObject;
            lbpScript = lightningBolt.transform.Find("LightningRayPath").GetComponent<LightningBoltPathScript>();

            lbpScript.Trigger();

            lightningSound = lightningBolt.transform.Find("LightningRayStart").transform.Find("LightningRaySound").GetComponent<AudioSource>();

            if (!lightningSound.isPlaying)
            {
                lightningSound.Play();
            }

        }

    }

}
