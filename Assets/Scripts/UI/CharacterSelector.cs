using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    private List<GameObject> characters;
    private Sprite [ ] weaponSprites;
    public Sprite  basicSwordSprite;
    public Sprite maulerSprite;
    public Sprite bowSprite;
    public Sprite staffSprite;
    private string [ ] weaponNames;
    private Image weaponImage;
    private Text weaponText;
    private PlayerData pData;
    private GameObject weaponSpot;
    private List<GameObject> weapons;
    private List<Image> boxImages;

    // Start is called before the first frame update
    private void Start ( )
    {
        ActivateAvatar ( "Wizard" );
        weapons = new List<GameObject> ( );
        weaponSpot = GameObject.FindGameObjectWithTag ( "Player" ).transform.Find ( "AR Camera" ).transform.Find ( "Weapon Spot" ).gameObject;

        foreach ( Transform weapon in weaponSpot.transform.GetComponentsInChildren<Transform> ( true ) )
        {
            if ( weapon.tag == "Gun" || weapon.tag == "Sword" || weapon.tag == "Potion" || weapon.tag == "Cross Bow" || weapon.tag == "Staff" )
            {
                weapons.Add ( weapon.gameObject );
            }

        }

        pData = SaveLoadPlayerData.Load ( );
        characters = new List<GameObject> ( );
        boxImages = new List<Image> ( );

        for ( int i = 0 ; i < transform.childCount ; i++ )
        {
            characters.Add ( transform.GetChild ( i ).gameObject );
            boxImages.Add ( transform.GetChild ( i ).transform.Find ( "Image" ).GetComponent<Image> ( ) );
        }

        weaponSprites = new Sprite [ ] { basicSwordSprite , maulerSprite , bowSprite , staffSprite };
        weaponNames = new string [ ] { "Basic Sword" , "Mauler" , "Elven Long Bow" , "Wizard Staff" };
        weaponImage = transform.root.transform.Find ( "Panel" ).transform.Find ( "Weapon Image" ).GetComponent<Image> ( );
        weaponText = transform.root.transform.Find ( "Panel" ).transform.Find ( "Weapon Name" ).GetComponent<Text> ( );

    }

    public void SetWeapon ( string buttonName )
    {

        switch ( buttonName )
        {
            case "Man":
                {

                    weaponImage.sprite = weaponSprites [ 0 ];
                    weaponText.text = weaponNames [ 0 ];
                    SetAvatar ( "Man" );
                    GetWeapon ( 5 , weapons );
                    HighLightBox ( boxImages , 0 );

                    break;
                }
            case "Woman":
                {
                    weaponImage.sprite = weaponSprites [ 1 ];
                    weaponText.text = weaponNames [ 1 ];
                    SetAvatar ( "Woman" );
                    GetWeapon ( 0 , weapons );
                    HighLightBox ( boxImages , 1 );
                    break;
                }
            case "Button (2)":
                {
                    weaponImage.sprite = weaponSprites [ 2 ];
                    weaponText.text = weaponNames [ 2 ];
                    SetAvatar ( "Button (2)" );
                    HighLightBox ( boxImages , 2 );
                    break;
                }
            case "Wizard":
                {
                    weaponImage.sprite = weaponSprites [ 3 ];
                    weaponText.text = weaponNames [ 3 ];
                    SetAvatar ( "Wizard" );
                    GetWeapon ( 7 , weapons );
                    HighLightBox ( boxImages , 3 );
                    break;
                }
            case "Button (4)":
                {
                    weaponImage.sprite = weaponSprites [ 4 ];
                    weaponText.text = weaponNames [ 4 ];
                    SetAvatar ( "Button (4)" );
                    HighLightBox ( boxImages , 4 );
                    break;
                }
            case "Button (5)":
                {
                    weaponImage.sprite = weaponSprites [ 5 ];
                    weaponText.text = weaponNames [ 5 ];
                    SetAvatar ( "Button (5)" );
                    HighLightBox ( boxImages , 5 );
                    break;
                }
            case "Button (6)":
                {
                    weaponImage.sprite = weaponSprites [ 6 ];
                    weaponText.text = weaponNames [ 6 ];
                    SetAvatar ( "Button (6)" );
                    HighLightBox ( boxImages , 6 );
                    break;
                }
            case "Button (7)":
                {
                    weaponImage.sprite = weaponSprites [ 7 ];
                    weaponText.text = weaponNames [ 7 ];
                    SetAvatar ( "Button (7)" );
                    HighLightBox ( boxImages , 7 );
                    break;
                }
            case "Button (8)":
                {
                    weaponImage.sprite = weaponSprites [ 8 ];
                    weaponText.text = weaponNames [ 8 ];
                    SetAvatar ( "Button (8)" );
                    HighLightBox ( boxImages , 8 );
                    break;
                }
            case "Button (9)":
                {
                    weaponImage.sprite = weaponSprites [ 9 ];
                    weaponText.text = weaponNames [ 9 ];
                    SetAvatar ( "Button (9)" );
                    HighLightBox ( boxImages , 9 );
                    break;
                }
            case "Button (10)":
                {
                    weaponImage.sprite = weaponSprites [ 10 ];
                    weaponText.text = weaponNames [ 10 ];
                    SetAvatar ( "Button (10)" );
                    HighLightBox ( boxImages , 10 );
                    break;
                }
            case "Button (11)":
                {
                    weaponImage.sprite = weaponSprites [ 11 ];
                    weaponText.text = weaponNames [ 11 ];
                    SetAvatar ( "Button (11)" );
                    HighLightBox ( boxImages , 11 );
                    break;
                }
            case "Button (12)":
                {
                    weaponImage.sprite = weaponSprites [ 12 ];
                    weaponText.text = weaponNames [ 12 ];
                    SetAvatar ( "Button (12)" );
                    HighLightBox ( boxImages , 12 );
                    break;
                }
            case "Button (13)":
                {
                    weaponImage.sprite = weaponSprites [ 13 ];
                    weaponText.text = weaponNames [ 13 ];
                    SetAvatar ( "Button (13)" );
                    HighLightBox ( boxImages , 13 );
                    break;
                }
            case "Button (14)":
                {
                    weaponImage.sprite = weaponSprites [ 14 ];
                    weaponText.text = weaponNames [ 14 ];
                    SetAvatar ( "Button (14)" );
                    HighLightBox ( boxImages , 14 );
                    break;
                }
            case "Button (15)":
                {
                    weaponImage.sprite = weaponSprites [ 15 ];
                    weaponText.text = weaponNames [ 15 ];
                    SetAvatar ( "Button (15)" );
                    HighLightBox ( boxImages , 15 );
                    break;
                }
            case "Button (16)":
                {
                    weaponImage.sprite = weaponSprites [ 16 ];
                    weaponText.text = weaponNames [ 16 ];
                    SetAvatar ( "Button (16)" );
                    HighLightBox ( boxImages , 16 );
                    break;
                }
            case "Button (17)":
                {
                    weaponImage.sprite = weaponSprites [ 17 ];
                    weaponText.text = weaponNames [ 17 ];
                    SetAvatar ( "Button (17)" );
                    HighLightBox ( boxImages , 17 );
                    break;
                }
            case "Button (18)":
                {
                    weaponImage.sprite = weaponSprites [ 18 ];
                    weaponText.text = weaponNames [ 18 ];
                    SetAvatar ( "Button (18)" );
                    HighLightBox ( boxImages , 18 );
                    break;
                }
            case "Button (19)":
                {
                    weaponImage.sprite = weaponSprites [ 19 ];
                    weaponText.text = weaponNames [ 19 ];
                    SetAvatar ( "Button (19)" );
                    HighLightBox ( boxImages , 19 );
                    break;
                }
            case "Button (20)":
                {
                    weaponImage.sprite = weaponSprites [ 20 ];
                    weaponText.text = weaponNames [ 20 ];
                    SetAvatar ( "Button (20)" );
                    HighLightBox ( boxImages , 20 );
                    break;
                }
            case "Button (21)":
                {
                    weaponImage.sprite = weaponSprites [ 21 ];
                    weaponText.text = weaponNames [ 21 ];
                    SetAvatar ( "Button (21)" );
                    HighLightBox ( boxImages , 21 );
                    break;
                }
            case "Elf":
                {
                    weaponImage.sprite = weaponSprites [ 2 ];
                    weaponText.text = weaponNames [ 2 ];
                    SetAvatar ( "Elf" );
                    GetWeapon ( 6 , weapons );
                    HighLightBox ( boxImages , 22 );
                    break;
                }
            case "Button (23)":
                {
                    weaponImage.sprite = weaponSprites [ 23 ];
                    weaponText.text = weaponNames [ 23 ];
                    SetAvatar ( "Button (23)" );
                    HighLightBox ( boxImages , 23 );
                    break;
                }
            case "Button (24)":
                {
                    weaponImage.sprite = weaponSprites [ 24 ];
                    weaponText.text = weaponNames [ 24 ];
                    SetAvatar ( "Button (24)" );
                    HighLightBox ( boxImages , 24 );
                    break;
                }
            case "Button (25)":
                {
                    weaponImage.sprite = weaponSprites [ 25 ];
                    weaponText.text = weaponNames [ 25 ];
                    SetAvatar ( "Button (25)" );
                    HighLightBox ( boxImages , 25 );
                    break;
                }
            case "Button (26)":
                {
                    weaponImage.sprite = weaponSprites [ 26 ];
                    weaponText.text = weaponNames [ 26 ];
                    SetAvatar ( "Button (26)" );
                    HighLightBox ( boxImages , 26 );
                    break;
                }
        }

    }

    private void HighLightBox ( List<Image> boxImages , int v )
    {
        for ( int i = 0 ; i < boxImages.Count ; i++ )
        {
            if ( i == v )
            {
                boxImages [ i ].color = Color.blue;
            }
            else
            {
                boxImages [ i ].color = Color.white;
            }
        }
    }

    private void GetWeapon ( int v , List<GameObject> weapons )
    {
        for ( int i = 0 ; i < weapons.Count ; i++ )
        {
            if ( i == v )
            {
                weapons [ i ].SetActive ( true );

            }
            else
            {
                weapons [ i ].SetActive ( false );
            }

        }
    }

    public void SetAvatar ( string buttonName )
    {
        Image buttonImage = GameObject.Find ( buttonName ).GetComponent<Image> ( );

        if ( !pData.characterSpriteName.Equals ( buttonImage.sprite.name ) )
        {
            SaveLoadPlayerData.Save ( 1f , 5f , 0 , "Main Hall" , buttonImage.sprite.name );

        }

        pData = SaveLoadPlayerData.Load ( );

    }

    public void ActivateAvatar ( string buttonName )
    {
        Button characterButton = GameObject.Find(buttonName).gameObject.GetComponent<Button>();
        characterButton.interactable = true;
    }
}