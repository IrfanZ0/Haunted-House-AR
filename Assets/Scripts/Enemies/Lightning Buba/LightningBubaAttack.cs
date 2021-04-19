using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DigitalRuby.ThunderAndLightning;

public class LightningBubaAttack : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    private void Start ( )
    {
        animator = GetComponent<Animator> ( );

    }

    private void Update ( )
    {
        if ( animator.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "Root|Attack" ) && animator.GetCurrentAnimatorStateInfo ( 0 ).normalizedTime > 0.9f )
        {
            GameObject lightningBolt = transform.Find("Lightning Spot").transform.Find("SimpleLightningBoltPrefab").gameObject;
            ShootLightningBolt ( lightningBolt );
        }
    }

    private void ShootLightningBolt ( GameObject lightningBolt )
    {
        LightningBoltPrefabScript lbpScript = lightningBolt.GetComponent<LightningBoltPrefabScript> ( );
        lbpScript.Trigger ( );
    }
}