using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private string nameOfScene = null;

    // Start is called before the first frame update
    private void Start ( )
    {

    }

    private void OnParticleCollision ( GameObject other )
    {
        if ( other.tag == "Player" )
        {
            Debug.Log ( "Name of scene teleporting to: " + nameOfScene );
            //nameOfScene = GetSceneName ( );
            //SceneTeleport(nameOfScene);

            switch ( nameOfScene )
            {
                case "Main Hall":
                    {
                        SceneManager.LoadScene ( "Main Hall" );
                        break;
                    }
                case "Small Dungeon":
                    {
                        SceneManager.LoadScene ( "Small Dungeon" );
                        break;
                    }
                case "Large Dungeon":
                    {
                        SceneManager.LoadScene ( "Large Dungeon" );
                        break;
                    }
                case "Graveyard":
                    {
                        SceneManager.LoadScene ( "Graveyard" );
                        break;
                    }
                case "Boss Room":
                    {
                        SceneManager.LoadScene ( "Boss Room" );
                        break;
                    }
                case "Blue Diamond GraveYard":
                    {
                        SceneManager.LoadScene ( "Blue Diamond GraveYard" );
                        break;
                    }
                case "Orange Diamond GraveYard":
                    {
                        SceneManager.LoadScene ( "Orange Diamond GraveYard" );
                        break;
                    }
                case "Purple Diamond GraveYard":
                    {
                        SceneManager.LoadScene ( "Purple Diamond GraveYard" );
                        break;
                    }
                case "Red Diamond GraveYard":
                    {
                        SceneManager.LoadScene ( "Red Diamond GraveYard" );
                        break;
                    }
                case "Yellow Diamond GraveYard":
                    {
                        SceneManager.LoadScene ( "Yellow Diamond GraveYard" );
                        break;
                    }

            }

        }

    }

    public void SetSceneName ( string sceneName )
    {
        nameOfScene = sceneName;
    }

}