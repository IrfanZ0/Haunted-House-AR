using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    private GameObject playerCanvas;
    private float lifeAmount;
    private float magicAmount;
    private string moneyText;
    private GameObject altarCanvas;
    private Text altarText;

    private void Start ( )
    {
        playerCanvas = GameObject.FindGameObjectWithTag ( "Player Life" ).gameObject;
        lifeAmount = playerCanvas.transform.Find ( "Player Health Bar" ).transform.Find ( "Fill Area" ).transform.Find ( "Fill" ).GetComponent<Image> ( ).fillAmount;
        magicAmount = playerCanvas.transform.Find ( "Magic Bar" ).GetComponent<Slider> ( ).value;
        moneyText = playerCanvas.transform.Find ( "Coin Text" ).GetComponent<Text> ( ).text;
        altarCanvas = transform.Find ( "Altar Canvas" ).gameObject;
        altarText = altarCanvas.transform.Find ( "Panel" ).transform.Find ( "Text" ).GetComponent<Text> ( );
        altarCanvas.SetActive ( false );
    }

    private void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.CompareTag ( "Player" ) )
        {
            altarCanvas.SetActive ( true );
            StartCoroutine ( AltarSpeaks ( ) );
            SaveLoadPlayerData.Save ( GetLifeAmount ( ) , GetMagicAmount ( ) , GetMoney ( ) , GetLevelName ( ) , GetAvatarName ( ) );

        }
    }

    private string GetAvatarName ( )
    {
        throw new NotImplementedException ( );
    }

    private IEnumerator AltarSpeaks ( )
    {
        altarText.text = "Please hold while I save your game!!!";
        yield return new WaitForSeconds ( 5f );
        altarText.text = "Save Completed";
        yield return new WaitForSeconds ( 5f );
        altarText.text = "Provide your diamond offering to the mystical mighty altar now";
        yield return new WaitForSeconds ( 3f );
        altarCanvas.SetActive ( false );

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
}