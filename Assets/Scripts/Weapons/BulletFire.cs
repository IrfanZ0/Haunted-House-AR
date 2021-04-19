using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    private GameObject bulletGO;
    private int maxBullets;
    private int currentBullets;
    public GameObject bullet;
    private GameObject activeBullet;
    private List<GameObject> bulletList;
    private AudioSource gunFireSound;
    private AudioSource gunReloadSound;
    private float thrust;
    private bool launch;
    private bool reload;
    public float reLoadTime;

    // Use this for initialization
    private void Start ( )
    {
        launch = false;
        reload = false;
        reLoadTime = 2.5f;
        thrust = 10f;
        maxBullets = 20;
        currentBullets = maxBullets;
        bulletList = new List<GameObject> ( );
        bulletList.AddRange ( LoadBullets ( ) );
    }

    private void Update ( )
    {

        if ( launch && currentBullets > -1 )
        {
            currentBullets -= 1;
            GameObject currentBullet = GetBullet(bulletList, currentBullets);
            currentBullet.SetActive ( true );
            Fire ( currentBullet );

        }

        if ( currentBullets <= 0 )
        {
            for ( int i = 0 ; i < bulletList.Count ; i++ )
            {
                bulletList [ i ].transform.localPosition = Vector3.zero;
                bulletList [ i ].SetActive ( false );
                currentBullets = maxBullets;

            }
        }

    }

    public void Launch ( )
    {
        launch = true;
    }

    private GameObject GetBullet ( List<GameObject> bullets , int currentBullets )
    {
        for ( int i = 0 ; i < bullets.Count ; i++ )
        {
            if ( i == currentBullets )
            {
                return bullets [ i ];

            }
            else
            {
                bullets [ i ].SetActive ( false );
            }

        }

        return null;
    }

    private void Fire ( GameObject bullet )
    {
        gunFireSound = GetComponent<AudioSource> ( );
        bullet.SetActive ( true );

        bullet.GetComponent<Rigidbody> ( ).velocity = thrust * transform.forward;

        if ( gunFireSound.clip.name == "GUN_FIRE-GoodSoundForYou-820112263" && !gunFireSound.isPlaying )
        {
            gunFireSound.Play ( );
        }

        launch = false;
    }

    private GameObject [ ] LoadBullets ( )
    {
        GameObject[] bullets = new GameObject[maxBullets];
        gunReloadSound = GetComponent<AudioSource> ( );

        for ( int i = 0 ; i < bullets.Length ; i++ )
        {
            bullets [ i ] = Instantiate ( bullet ) as GameObject;
            bullets [ i ].transform.SetParent ( gameObject.transform , false );
            bullets [ i ].transform.localPosition = Vector3.zero;
            bullets [ i ].transform.localRotation = Quaternion.Euler ( 90f , 0 , 0 );
            bullets [ i ].SetActive ( false );

        }

        if ( !gunReloadSound.isPlaying && gunReloadSound.clip.name.Contains ( "reload" ) )
        {
            gunReloadSound.Play ( );
        }

        return bullets;

    }

}