using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.ThunderAndLightning;

public class PlayerAttack : MonoBehaviour
{
    private Button playerAttackButton;
    private GameObject [ ] guns;
    private GameObject [ ] axes;
    private GameObject [ ] swords;
    private GameObject [ ] potions;

    public GameObject lightningBoltGO;
    private GameObject lightningBolt;
    private LightningBoltPrefabScript lbpScript;
    private AudioSource lightningSound;
    private Transform startLightningTransform;
    private Transform endLightningTransform;

    // Start is called before the first frame update
    private void Start ( )
    {
        playerAttackButton = GetComponent<Button> ( );

        playerAttackButton.onClick.AddListener ( delegate { LightningFire ( ); } );
        guns = GameObject.FindGameObjectsWithTag ( "Guns" );
        axes = GameObject.FindGameObjectsWithTag ( "Axes" );
        swords = GameObject.FindGameObjectsWithTag ( "Swords" );
        potions = GameObject.FindGameObjectsWithTag ( "Potions" );

    }

    // Update is called once per frame
    private void Update ( )
    {

    }

    public void LightningFire ( )
    {

        lightningBolt = Instantiate ( lightningBoltGO , transform ) as GameObject;
        lightningBolt.transform.localPosition = Vector3.zero;
        lightningBolt.transform.localRotation = Quaternion.Euler ( 270f , 0 , 0 );
        startLightningTransform = lightningBolt.transform.Find ( "LightningStart" );
        startLightningTransform.localPosition = lightningBolt.transform.localPosition;
        endLightningTransform = lightningBolt.transform.Find ( "LightningEnd" );
        endLightningTransform.localPosition = lightningBolt.transform.localPosition + Vector3.forward;

        lbpScript.ManualMode = true;
        lbpScript.Trigger ( startLightningTransform.position , endLightningTransform.position );

        lightningSound = lightningBolt.transform.Find ( "LightningRayStart" ).transform.Find ( "LightningRaySound" ).GetComponent<AudioSource> ( );

        if ( !lightningSound.isPlaying )
        {
            lightningSound.Play ( );
        }

    }
}