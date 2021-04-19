using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadWeapon : MonoBehaviour
{
    private GameObject weaponSpot;
    private List<GameObject> weapons;
    private GameObject mauler;
    private GameObject hellwailer;
    private GameObject fire_sleet;
    private GameObject archtronic;
    private bool load;

    // Start is called before the first frame update
    private void Start ( )
    {
        weaponSpot = GameObject.FindGameObjectWithTag ( "Player" ).transform.Find ( "AR Camera" ).transform.Find ( "Weapon Spot" ).gameObject;
        mauler = weaponSpot.transform.Find ( "mauler" ).gameObject;
        hellwailer = weaponSpot.transform.Find ( "hellwailer" ).gameObject;
        fire_sleet = weaponSpot.transform.Find ( "fire_sleet" ).gameObject;
        archtronic = weaponSpot.transform.Find ( "archtronic" ).gameObject;
        weapons = new List<GameObject> ( );
        weapons.Add ( mauler );
        weapons.Add ( hellwailer );
        weapons.Add ( fire_sleet );
        weapons.Add ( archtronic );
        load = false;

    }

    private void WeaponLoader ( )
    {
        Text weaponNameText = transform.Find("Name Text").GetComponent<Text>();

        switch ( weaponNameText.text )
        {
            case "mauler":
                {
                    weapons [ 0 ].transform.localPosition = Vector3.zero;
                    weapons [ 0 ].SetActive ( true );
                    HideWeapons ( weapons , 0 );

                    break;
                }
            case "hellwailer":
                {
                    weapons [ 1 ].transform.localPosition = Vector3.zero;
                    weapons [ 1 ].SetActive ( true );
                    HideWeapons ( weapons , 1 );

                    break;
                }
            case "fire_sleet":
                {
                    weapons [ 2 ].transform.localPosition = Vector3.zero;
                    weapons [ 2 ].SetActive ( true );
                    HideWeapons ( weapons , 2 );

                    break;
                }
            case "archtronic":
                {
                    weapons [ 3 ].transform.localPosition = Vector3.zero;
                    weapons [ 3 ].transform.localRotation = Quaternion.Euler ( 270f , 0 , 180f );
                    weapons [ 3 ].SetActive ( true );
                    HideWeapons ( weapons , 3 );

                    break;
                }
                //case "regular axe":
                //    {
                //        GameObject regularAxe = Instantiate(weapons[4]) as GameObject;
                //        regularAxe.transform.parent = weaponSpot;
                //        regularAxe.transform.localScale = new Vector3 ( 0.004f , 0.008f , 0.004f );
                //        regularAxe.transform.localRotation = Quaternion.Euler ( 40f , 33f , 285f );
                //        regularAxe.transform.localPosition = new Vector3 ( 0.41f , 0.88f , 0.02f );
                //        regularAxe.SetActive ( true );
                //        HideWeapons ( weapons , 4 );
                //        showInventory.HideInventory ( );
                //        break;
                //    }
                //case "medieval axe":
                //    {
                //        GameObject medievalAxe = Instantiate(weapons[5], transform.position, transform.rotation) as GameObject;
                //        medievalAxe.transform.parent = weaponSpot;
                //        medievalAxe.transform.localPosition = new Vector3 ( -0.22f , 0.88f , -0.42f );
                //        medievalAxe.transform.localRotation = Quaternion.Euler ( 71.5f , 0 , -90f );
                //        medievalAxe.transform.localScale = new Vector3 ( 0.004f , 0.008f , 0.004f );
                //        medievalAxe.SetActive ( true );
                //        HideWeapons ( weapons , 5 );
                //        showInventory.HideInventory ( );
                //        break;
                //    }
                //case "fireMan axe":
                //    {
                //        GameObject fireManAxe = Instantiate(weapons[6], transform.position, Quaternion.identity) as GameObject;
                //        fireManAxe.transform.parent = weaponSpot;
                //        fireManAxe.transform.localPosition = new Vector3 ( -0.8f , 1.1f , -0.6f );
                //        fireManAxe.transform.localRotation = Quaternion.Euler ( 18f , 360f , 270f );
                //        fireManAxe.transform.localScale = new Vector3 ( 0.004f , 0.008f , 0.004f );
                //        fireManAxe.SetActive ( true );
                //        HideWeapons ( weapons , 6 );
                //        showInventory.HideInventory ( );
                //        break;
                //    }
                //case "double hammer axe":
                //    {
                //        GameObject doubleHammerAxe = Instantiate(weapons[7], transform.position, transform.rotation) as GameObject;
                //        doubleHammerAxe.transform.parent = weaponSpot;
                //        doubleHammerAxe.transform.localPosition = new Vector3 ( 0.68f , 0.74f , -0.1f );
                //        doubleHammerAxe.transform.localRotation = Quaternion.Euler ( 233f , 7.2f , 90f );
                //        doubleHammerAxe.transform.localScale = new Vector3 ( 0.004f , 0.008f , 0.004f );
                //        doubleHammerAxe.SetActive ( true );
                //        HideWeapons ( weapons , 7 );
                //        showInventory.HideInventory ( );
                //        break;
                //    }
                //case "double blade axe":
                //    {
                //        GameObject doubleBladeAxe = Instantiate(weapons[8], transform.position, transform.rotation) as GameObject;
                //        doubleBladeAxe.transform.parent = weaponSpot;
                //        doubleBladeAxe.transform.localPosition = new Vector3 ( 0.46f , 1.07f , 0.08f );
                //        doubleBladeAxe.transform.localRotation = Quaternion.Euler ( 204.4f , 25.6f , 84.3f );
                //        doubleBladeAxe.transform.localScale = new Vector3 ( 0.004f , 0.008f , 0.004f );
                //        doubleBladeAxe.SetActive ( true );
                //        HideWeapons ( weapons , 8 );
                //        showInventory.HideInventory ( );
                //        break;
                //    }

        }

    }

    private void HideWeapons ( List<GameObject> weapons , int weaponNum )
    {
        for ( int i = 0 ; i < weapons.Count ; i++ )
        {
            if ( i != weaponNum )
            {
                weapons [ i ].SetActive ( false );
            }
        }
    }

    public void loadWeapon ( )
    {
        load = true;
    }

    private void Update ( )
    {
        if ( load )
        {
            WeaponLoader ( );
        }
    }
}