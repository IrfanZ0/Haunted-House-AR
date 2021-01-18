using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleWarpEnter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            int randomSceneNum = 0;

            switch(randomSceneNum)
            {
                case 0:
                    {
                        SceneManager.LoadScene ( 10  );
                        break;
                    }
                case 1:
                    {
                        SceneManager.LoadScene ( 11 );
                        break;
                    }
                case 2:
                    {
                        SceneManager.LoadScene ( 12 );
                        break;
                    }
               
            }


        }

    }
}
