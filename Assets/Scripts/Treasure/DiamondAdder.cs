using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiamondAdder : MonoBehaviour
{
    private GameObject weaponInventory;
    private RaycastHit hit;

    private void Start ( )
    {
        weaponInventory = GameObject.FindGameObjectWithTag ( "Weapon Inventory" );
    }

    private void Update ( )
    {
        if ( Input.touchCount > 0 )
        {

            Touch touch = Input.GetTouch(0);

            if ( Input.touchCount < 1 || ( touch.phase != TouchPhase.Began ) )
            {
                return;
            }

            if ( EventSystem.current.IsPointerOverGameObject ( touch.fingerId ) )
            {
                return;

            }

            if ( touch.phase == TouchPhase.Began )
            {
                if ( Physics.Raycast ( touch.position , Vector3.forward , out hit ) )
                {
                    if ( hit.transform.CompareTag ( "Treasure" ) && hit.transform.gameObject.name == "Blue Diamond" )
                    {
                        AddDiamond ( hit.transform.gameObject );
                    }
                    if ( hit.transform.CompareTag ( "Treasure" ) && hit.transform.gameObject.name == "Orange Diamond" )
                    {
                        AddDiamond ( hit.transform.gameObject );
                    }
                    if ( hit.transform.CompareTag ( "Treasure" ) && hit.transform.gameObject.name == "Red Diamond" )
                    {
                        AddDiamond ( hit.transform.gameObject );
                    }
                    if ( hit.transform.CompareTag ( "Treasure" ) && hit.transform.gameObject.name == "Silver Diamond" )
                    {
                        AddDiamond ( hit.transform.gameObject );
                    }
                    if ( hit.transform.CompareTag ( "Treasure" ) && hit.transform.gameObject.name == "Violet Diamond" )
                    {
                        AddDiamond ( hit.transform.gameObject );
                    }
                    if ( hit.transform.CompareTag ( "Treasure" ) && hit.transform.gameObject.name == "Yellow Diamond" )
                    {
                        AddDiamond ( hit.transform.gameObject );
                    }

                }
            }

        }

    }

    public void AddDiamond ( GameObject diamond )
    {
        switch ( diamond.name )
        {
            case "Blue Diamond":
                {
                    DiamondPanel dPanel = weaponInventory.transform.Find("Diamond Panel").GetComponent<DiamondPanel>();
                    Sprite blueDiamondSprite = diamond.GetComponent<SpriteRenderer>().sprite;
                    dPanel.AddNewDiamond ( blueDiamondSprite , dPanel.DiamondCounter ( ) , diamond.name );
                    break;
                }
            case "Orange Diamond":
                {
                    DiamondPanel dPanel = weaponInventory.transform.Find("Diamond Panel").GetComponent<DiamondPanel>();
                    Sprite orangeDiamondSprite = diamond.GetComponent<SpriteRenderer>().sprite;
                    dPanel.AddNewDiamond ( orangeDiamondSprite , dPanel.DiamondCounter ( ) , diamond.name );
                    break;
                }
            case "Red Diamond":
                {
                    DiamondPanel dPanel = weaponInventory.transform.Find("Diamond Panel").GetComponent<DiamondPanel>();
                    Sprite redDiamondSprite = diamond.GetComponent<SpriteRenderer>().sprite;
                    dPanel.AddNewDiamond ( redDiamondSprite , dPanel.DiamondCounter ( ) , diamond.name );
                    break;
                }
            case "Silver Diamond":
                {
                    DiamondPanel dPanel = weaponInventory.transform.Find("Diamond Panel").GetComponent<DiamondPanel>();
                    Sprite silverDiamondSprite = diamond.GetComponent<SpriteRenderer>().sprite;
                    dPanel.AddNewDiamond ( silverDiamondSprite , dPanel.DiamondCounter ( ) , diamond.name );
                    break;
                }
            case "Violet Diamond":
                {
                    DiamondPanel dPanel = weaponInventory.transform.Find("Diamond Panel").GetComponent<DiamondPanel>();
                    Sprite violetDiamondSprite = diamond.GetComponent<SpriteRenderer>().sprite;
                    dPanel.AddNewDiamond ( violetDiamondSprite , dPanel.DiamondCounter ( ) , diamond.name );
                    break;
                }
            case "Yellow Diamond":
                {
                    DiamondPanel dPanel = weaponInventory.transform.Find("Diamond Panel").GetComponent<DiamondPanel>();
                    Sprite yellowDiamondSprite = diamond.GetComponent<SpriteRenderer>().sprite;
                    dPanel.AddNewDiamond ( yellowDiamondSprite , dPanel.DiamondCounter ( ) , diamond.name );
                    break;
                }
        }
    }
}