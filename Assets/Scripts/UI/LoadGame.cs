using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private PlayerData pData;
    private TitlePageController tpController;

    // Start is called before the first frame update
    private void Start ( )
    {
        tpController = GameObject.Find ( "Title Page Controller" ).GetComponent<TitlePageController> ( );
        pData = SaveLoadPlayerData.Load ( );

        SaveLoadPlayerData.Save ( GetLife ( tpController.life ) , GetMagic ( tpController.magic ) , GetMoney ( tpController.money ) , GetLevel ( tpController.levelName ) , GetSpriteName ( tpController.avatarName ) );
    }

    private string GetSpriteName ( string spriteName )
    {
        if ( spriteName != null )
            spriteName = pData.characterSpriteName;
        else
            spriteName = "Man_4";
        return spriteName;
    }

    private string GetLevel ( string levelName )
    {
        if ( levelName != null )
            levelName = pData.levelName;
        else
            levelName = "Main Hall";
        return levelName;
    }

    private int GetMoney ( int money )
    {
        if ( money >= 0 )
            money = pData.money;
        else
            money = 5;
        return money;
    }

    private float GetMagic ( float magic )
    {
        if ( magic >= 0 )
            magic = pData.magicAmount;
        else
            magic = 5f;
        return magic;
    }

    private float GetLife ( float life )
    {
        if ( life >= 0 )
            life = pData.lifeAmount;
        else
            life = 1f;
        return life;
    }

    public void Load ( )
    {
        pData = SaveLoadPlayerData.Load ( );
        SceneManager.LoadScene ( pData.levelName );
    }
}