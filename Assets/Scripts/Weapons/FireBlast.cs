using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
    public GameObject fireBlastGO;
    private GameObject fireBlast;
    ParticleSystem psFire;
    AudioSource fireSound;

    private void Start ( )
    {
        Fire ( );
    }

    public void Fire()
    {
        if (fireBlast == null)
        {
            fireBlast = Instantiate(fireBlastGO, transform.position, transform.rotation) as GameObject;
            psFire = fireBlast.transform.Find("FlameStrikeMainColumn").GetComponent<ParticleSystem>();

            if (!psFire.isPlaying)
            {
                psFire.Play();
            }

            fireSound = fireBlast.GetComponent<AudioSource>();

            if (!fireSound.isPlaying)
            {
                fireSound.Play();
            }

        }

    }

}
