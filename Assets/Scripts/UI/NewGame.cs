using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    private Sprite avatarSprite;

    // Start is called before the first frame update
    private void Start ( )
    {
        avatarSprite = GetComponent<Image> ( ).sprite;
    }

    public void CreateNewGame ( )
    {
        SaveLoadPlayerData.Save ( 1f , 5f , 0 , "Main Level" , avatarSprite.name );
        SceneManager.LoadScene ( "Character Selection" );
    }
}