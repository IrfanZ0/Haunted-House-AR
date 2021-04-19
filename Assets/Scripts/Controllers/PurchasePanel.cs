using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PurchasePanel : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private CanvasGroup purchaseCanvasGroup;
    private List<GameObject> weaponList;
    private GameObject weaponSpot;

    // Start is called before the first frame update
    private void Start ( )
    {
        weaponList = new List<GameObject> ( );
        weaponSpot = GameObject.FindGameObjectWithTag ( "Player" ).transform.Find ( "AR Camera" ).transform.Find ( "Weapon Spot" ).gameObject;

        foreach ( Transform child in weaponSpot.transform.GetComponentInChildren<Transform> ( true ) )
        {
            if ( child.tag == "Gun" || child.tag == "Potion" || child.tag == "Sword" || child.tag == "Cross Bow " || child.tag == "Staff" )
            {
                weaponList.Add ( child.gameObject );

            }
        }

        textMeshPro = gameObject.GetComponentInParent<Transform> ( ).Find ( "Weapon Store Panel" ).transform.Find ( "Weapon Name" ).GetComponent<TextMeshProUGUI> ( );

    }

    public void ShowPurchasePanel ( )
    {
        purchaseCanvasGroup = GetComponent<CanvasGroup> ( );
        purchaseCanvasGroup.alpha = 1f;
    }

    public void HidePurchasePanel ( )
    {
        purchaseCanvasGroup = GetComponent<CanvasGroup> ( );
        purchaseCanvasGroup.alpha = 0.05f;
    }

    public void DojoRoom ( )
    {
        PlayerData pData;
        SaveLoadPlayerData.Save ( 100f , 0f , 0 , "Dojo Room" , "Man_4" );
        foreach ( GameObject weapon in weaponList )
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

        pData = SaveLoadPlayerData.Load ( );
        string level = pData.levelName;

        SceneManager.LoadScene ( level );
    }
}