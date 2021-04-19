using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlockSpawn : MonoBehaviour
{
    public GameObject iceBlockGO;
    private GameObject iceBlock;
    private ParticleSystem psBlueRay;
    private List<ParticleCollisionEvent> pCollEvents;

    // Start is called before the first frame update
    private void Start ( )
    {
        psBlueRay = GetComponent<ParticleSystem> ( );
        pCollEvents = new List<ParticleCollisionEvent> ( );

    }

    private void OnParticleCollision ( GameObject other )
    {
        int numCollisions = psBlueRay.GetCollisionEvents(other, pCollEvents);

        for ( int i = 0 ; i < numCollisions ; i++ )
        {
            iceBlock = Instantiate ( iceBlockGO , pCollEvents [ i ].intersection , Quaternion.identity ) as GameObject;

        }

    }
}