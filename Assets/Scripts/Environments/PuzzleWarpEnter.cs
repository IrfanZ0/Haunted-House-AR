using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleWarpEnter : MonoBehaviour
{
    private string nameOfScene;

    // Start is called before the first frame update
    private void Start ( )
    {
        nameOfScene = "Main Hall";
    }

    private void OnParticleCollision ( GameObject other )
    {
        if ( other.CompareTag ( "Player" ) )
        {
            int randomSceneNum = SceneTeleport(nameOfScene);

            switch ( randomSceneNum )
            {
                case 0:
                    {
                        SceneManager.LoadScene ( 0 );
                        break;
                    }
                case 1:
                    {
                        SceneManager.LoadScene ( 1 );
                        break;
                    }
                case 2:
                    {
                        SceneManager.LoadScene ( 2 );
                        break;
                    }
                case 3:
                    {
                        SceneManager.LoadScene ( 3 );
                        break;
                    }
                case 4:
                    {
                        SceneManager.LoadScene ( 4 );
                        break;
                    }

            }

        }

    }

    public void SetSceneName ( string sceneName )
    {
        nameOfScene = sceneName;
    }

    private int SceneTeleport ( string scene )
    {
        return SceneManager.GetSceneByName ( scene ).buildIndex;
    }
}