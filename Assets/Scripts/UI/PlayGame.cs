using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    private GameObject weaponSpot;
    private List<GameObject> weapons;
    private GameObject tempActiveWeapon;

    // Start is called before the first frame update
    private void Start ( )
    {
        weapons = new List<GameObject> ( );
        weaponSpot = GameObject.FindGameObjectWithTag ( "Player" ).transform.Find ( "AR Camera" ).transform.Find ( "Weapon Spot" ).gameObject;

        foreach ( Transform weapon in weaponSpot.GetComponentInChildren<Transform> ( ) )
        {
            if ( weapon.tag == "Sword" || weapon.tag == "Guns" )
            {
                weapons.Add ( weapon.gameObject );
            }

        }

    }

    public void StartGame ( )
    {
        foreach ( GameObject weapon in weapons )
        {
            if ( weapon.activeSelf )
            {
                DontDestroyOnLoad ( weapon.gameObject );
                weapon.SetActive ( true );

                if ( weapon.tag == "Sword" )
                {
                    weapon.transform.localScale = new Vector3 ( 0.2f , 0.2f , 0.2f );
                    weapon.transform.localPosition = new Vector3 ( 3.0f , 0 , 2.3f );
                }

                if ( weapon.tag == "Guns" )
                {
                    weapon.transform.localScale = new Vector3 ( 2f , 2f , 2f );
                    weapon.transform.localPosition = new Vector3 ( 0 , 0.07f , -0.54f );
                }

            }

        }
        PlayerData pData = SaveLoadPlayerData.Load();
        string level = pData.levelName;

        SceneManager.LoadScene ( level );

    }
}