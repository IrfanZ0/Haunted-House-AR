using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DojoController : MonoBehaviour
{
    private GameObject weaponSpot;

    // Start is called before the first frame update
    private void Start ( )
    {
        weaponSpot = GameObject.FindGameObjectWithTag ( "Player" ).transform.Find ( "AR Camera" ).transform.Find ( "Weapon Spot" ).gameObject;
    }

    // Update is called once per frame
    private void Update ( )
    {

    }

    private void ActivateWeapon ( string avatarName )
    {
        switch ( avatarName )
        {
            case "Man_4":
                {
                    GameObject basicSword = weaponSpot.transform.Find("Basic Sword").gameObject;
                    basicSword.SetActive ( true );
                    break;
                }
            case "Girl":
                {
                    GameObject mauler = weaponSpot.transform.Find("mauler").gameObject;
                    mauler.SetActive ( true );
                    break;
                }
        }

    }
}