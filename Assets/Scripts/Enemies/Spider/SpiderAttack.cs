using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    public GameObject spiderWebGO;
    private GameObject spiderWeb;
    private Animator animator;
    private Transform spiderWebSpot;
    private float speed;

    // Start is called before the first frame update
    private void Start ( )
    {
        animator = GetComponent<Animator> ( );
        spiderWebSpot = transform.Find ( "Spider Web Spot" );
        speed = 1.5f;
    }

    private void Update ( )
    {

        if ( animator.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "Root|Attack" ) )
        {
            if ( spiderWeb == null )
            {
                SpawnSpiderWeb ( );

            }

            if ( spiderWeb.CompareTag ( "Spider Web" ) && spiderWeb != null && animator.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "attack" ) )
            {
                ShootSpiderWeb ( spiderWeb );
            }

        }
    }

    private void ShootSpiderWeb ( GameObject spiderWeb )
    {
        spiderWeb.transform.localPosition = Vector3.Lerp ( spiderWeb.transform.localPosition , transform.forward , speed * Time.deltaTime );
    }

    private void SpawnSpiderWeb ( )
    {
        if ( spiderWeb != null )
        {
            Destroy ( spiderWeb.gameObject , 2f );
        }

        spiderWeb = Instantiate ( spiderWebGO ) as GameObject;
        spiderWeb.SetActive ( true );
        spiderWeb.transform.parent = spiderWebSpot.transform;
        spiderWeb.transform.localPosition = Vector3.zero;
        spiderWeb.transform.rotation = Quaternion.Euler ( 0 , 270f , 0 );

    }
}