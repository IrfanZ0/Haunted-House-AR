using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    private GameObject inventoryGO;
    private CanvasGroup inventoryToggleGroup;
    private GameObject weaponToggleGO;
    private CanvasGroup weaponToggleCanvasGroup;
    private Text weaponSelectionButtonText;

    // Start is called before the first frame update
    private void Awake ( )
    {
        HideInventory ( );

    }

    private void ViewInventory ( )
    {
        inventoryGO = GameObject.FindGameObjectWithTag ( "Weapon Inventory" );
        inventoryToggleGroup = inventoryGO.GetComponent<CanvasGroup> ( );
        inventoryToggleGroup.alpha = 1f;

        weaponToggleGO = GameObject.FindGameObjectWithTag ( "Weapon Toggle" );
        weaponToggleCanvasGroup = weaponToggleGO.GetComponent<CanvasGroup> ( );
        weaponToggleCanvasGroup.alpha = 1f;
        weaponSelectionButtonText = transform.Find ( "Label" ).GetComponent<Text> ( );
        weaponSelectionButtonText.text = "Hide Weapons";
    }

    private void HideInventory ( )
    {
        inventoryGO = GameObject.FindGameObjectWithTag ( "Weapon Inventory" );
        inventoryToggleGroup = inventoryGO.GetComponent<CanvasGroup> ( );
        inventoryToggleGroup.alpha = 0.05f;

        weaponToggleGO = GameObject.FindGameObjectWithTag ( "Weapon Toggle" );
        weaponToggleCanvasGroup = weaponToggleGO.GetComponent<CanvasGroup> ( );
        weaponToggleCanvasGroup.alpha = 0.05f;
        weaponSelectionButtonText = transform.Find ( "Label" ).GetComponent<Text> ( );
        weaponSelectionButtonText.text = "Show Weapons";
    }

    public void OnValueChanged ( bool weaponToggleOn )
    {

        if ( weaponToggleOn )
        {
            ViewInventory ( );
        }
        else
        {
            HideInventory ( );
        }
    }
}