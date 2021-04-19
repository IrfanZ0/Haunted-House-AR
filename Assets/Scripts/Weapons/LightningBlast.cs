using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.ThunderAndLightning;

public class LightningBlast : MonoBehaviour
{
    public GameObject lightningBoltGO;
    private GameObject lightningBolt;
    LightningBoltPrefabScript lbpScript;
    AudioSource lightningSound;
    Transform startLightningTransform;
    Transform endLightningTransform;

    private void Start ( )
    {
        lbpScript = GameObject.FindGameObjectWithTag ( "Player" ).transform.Find ( "AR Camera" ).transform.Find ( "Weapon Spot" ).transform.Find ( "archtronic" ).transform.Find ( "Fire Spot" ).transform.Find ( "LightningBoltPrefab(Clone)" ).GetComponent<LightningBoltPrefabScript>();

    }

    private void Update ( )
    {
      
    }

    public void Fire()
    {
       
        lightningBolt = Instantiate(lightningBoltGO, transform) as GameObject;
        lightningBolt.transform.localPosition = Vector3.zero;
        lightningBolt.transform.localRotation = Quaternion.Euler ( 270f , 0 , 0 );
        startLightningTransform = lightningBolt.transform.Find ( "LightningStart" );
        startLightningTransform.localPosition = lightningBolt.transform.localPosition;
        endLightningTransform = lightningBolt.transform.Find ( "LightningEnd" );
        endLightningTransform.localPosition = lightningBolt.transform.localPosition + Vector3.forward;

        
        lbpScript.ManualMode = true;
        lbpScript.Trigger ( startLightningTransform.position , endLightningTransform.position );

        lightningSound = lightningBolt.transform.Find("LightningRayStart").transform.Find("LightningRaySound").GetComponent<AudioSource>();

        if (!lightningSound.isPlaying)
        {
            lightningSound.Play();
        }

        

    }

}
