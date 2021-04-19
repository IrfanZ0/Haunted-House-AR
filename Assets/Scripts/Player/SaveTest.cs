using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveTest : MonoBehaviour
{
    private PlayerData pData;
    private GameObject playerCanvas;
    private float lifeAmount;
    private float magicAmount;
    private string moneyText;
    private string avatarName;

    private void Start ( )
    {
        playerCanvas = GameObject.FindGameObjectWithTag ( "Player Life" ).gameObject;
        lifeAmount = playerCanvas.transform.Find ( "Player Health Bar" ).transform.Find ( "Fill Area" ).transform.Find ( "Fill" ).GetComponent<Image> ( ).fillAmount;
        magicAmount = playerCanvas.transform.Find ( "Magic Bar" ).GetComponent<Slider> ( ).value;
        moneyText = playerCanvas.transform.Find ( "Coin Text" ).GetComponent<Text> ( ).text;
        avatarName = playerCanvas.transform.Find ( "Avatar Image" ).GetComponent<Image> ( ).sprite.name;
    }

    public void SavePlayer ( )
    {
        SaveLoadPlayerData.Save ( GetLifeAmount ( ) , GetMagicAmount ( ) , GetMoney ( ) , GetLevelName ( ) , GetAvatarName ( ) );
    }

    public void LoadPlayer ( )
    {
        pData = SaveLoadPlayerData.Load ( );

    }

    private float GetLifeAmount ( )
    {
        return lifeAmount;

    }

    private float GetMagicAmount ( )
    {
        return magicAmount;
    }

    private int GetMoney ( )
    {
        int money = int.Parse(moneyText);

        return money;
    }

    private string GetLevelName ( )
    {
        return SceneManager.GetActiveScene ( ).name;
    }

    private string GetAvatarName ( )
    {
        return avatarName;
    }

}