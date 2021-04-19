using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireButtonPress : MonoBehaviour, IPointerClickHandler
{
    private GameObject weaponSpot;
    private List<GameObject> weaponChildGameObjects;
    private bool clicked;
    private float lastClicked;
    private float clickInterval;

    // Start is called before the first frame update
    private void Start ( )
    {
        lastClicked = 0;
        clickInterval = 0.4f;
        clicked = false;
        weaponChildGameObjects = new List<GameObject> ( );

        weaponSpot = GameObject.FindGameObjectWithTag ( "Player" ).transform.Find ( "AR Camera" ).transform.Find ( "Weapon Spot" ).gameObject;

        foreach ( Transform child in weaponSpot.transform.GetComponentInChildren<Transform> ( ) )
        {
            weaponChildGameObjects.Add ( child.gameObject );
        }

    }

    public void wasClicked ( )
    {
        clicked = true;

    }

    public void OnPointerClick ( PointerEventData eventData )
    {
        if ( clicked )
        {

            GameObject activeWeapon = GetActiveWeapon ( weaponChildGameObjects );
            Animator swordAnim = activeWeapon.GetComponent<Animator>();

            if ( ( lastClicked + clickInterval ) > Time.time )
            {
                //Double Click

                if ( activeWeapon.CompareTag ( "Gun" ) )
                {
                    BulletFire bFire = activeWeapon.GetComponentInChildren<BulletFire>();
                    bFire.Launch ( );
                }

                if ( activeWeapon.CompareTag ( "Sword" ) )
                {

                    swordAnim.SetTrigger ( "Sword_Slash" );
                }

            }
            else
            {
                // Single Click
                activeWeapon = GetActiveWeapon ( weaponChildGameObjects );

                if ( activeWeapon.CompareTag ( "Gun" ) )
                {
                    BulletFire bFire = activeWeapon.GetComponentInChildren<BulletFire>();
                    bFire.Launch ( );
                }

                if ( activeWeapon.CompareTag ( "Sword" ) )
                {
                    swordAnim.SetTrigger ( "Sword_Jab" );
                }

                lastClicked = Time.time;

            }

        }

    }

    private GameObject GetActiveWeapon ( List<GameObject> weaponChildGameObjects )
    {
        GameObject activeGO = null;

        for ( int i = 0 ; i < weaponChildGameObjects.Count ; i++ )
        {
            if ( weaponChildGameObjects [ i ].activeSelf )
            {
                activeGO = weaponChildGameObjects [ i ];
            }
        }

        return activeGO;
    }
}