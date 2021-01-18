using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleWarpExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChanger ( int sceneIndex )
    {
        switch ( sceneIndex )
        {
            case 0:
                {
                    MainHall ( );
                    break;
                }

            case 1:
                {
                    SmallDungeon ( );
                    break;
                }

            case 2:
                {
                    LargeDungeon ( );
                    break;
                }

            case 3:
                {
                    Kitchen ( );
                    break;
                }

            case 4:
                {
                    Graveyard ( );
                    break;
                }

            case 5:
                {
                    WeaponShop ( );
                    break;
                }

            case 6:
                {
                    BossDungeon ( );
                    break;
                }
        }
    }

    public void BossDungeon ( )
    {
        StartCoroutine ( LoadSceneAsync ( "Boss Room" ) );
        SceneManager.SetActiveScene ( SceneManager.GetSceneByName ( "Boss Room" ) );
    }

    public void SmallDungeon ( )
    {
        StartCoroutine ( LoadSceneAsync ( "Small Dungeon" ) );
    }

    public void LargeDungeon ( )
    {
        StartCoroutine ( LoadSceneAsync ( "Large Dungeon" ) );
    }

    public void MainHall ( )
    {
        StartCoroutine ( LoadSceneAsync ( "Main Hall" ) );
    }

    public void Graveyard ( )
    {
        StartCoroutine ( LoadSceneAsync ( "Graveyard" ) );
    }

    public void WeaponShop ( )
    {
        StartCoroutine ( LoadSceneAsync ( "Weapon Shop" ) );
    }

    public void Kitchen ( )
    {
        StartCoroutine ( LoadSceneAsync ( "Kitchen" ) );
    }


    private IEnumerator LoadSceneAsync ( string sceneName )
    {
        AsyncOperation asyncOpLoad = SceneManager.LoadSceneAsync(sceneName);

        OnEnable ( );

        while ( !asyncOpLoad.isDone )
        {
            //loadingBar.value = asyncOpLoad.progress * 100;
            yield return null;
        }

        SceneManager.SetActiveScene ( SceneManager.GetSceneByName ( sceneName ) );
       // selectedText.text = sceneDD.options [ sceneDD.value ].text;

        OnDisable ( );


    }




    void OnEnable ( )
    {
        Debug.Log ( "Loading has started" );
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded ( Scene newScene , LoadSceneMode mode )
    {

        Debug.Log ( "Sceen Loaded: " + newScene.name );
        Debug.Log ( "Scene Load Mode: " + mode );

    }

    void OnDisable ( )
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log ( "Boss Dungeon has unloaded" );
    }




}
