using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOfDoom1CutScene : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject animationCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam.SetActive ( true );
        animationCam.SetActive ( false );
        
    }

    private void OnTriggerEnter ( Collider other )
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCam.SetActive ( false );
            animationCam.SetActive ( true );
        }
    }

    private void OnTriggerExit ( Collider other )
    {
        if ( other.gameObject.CompareTag ( "Player" ) )
        {
            mainCam.SetActive ( true );
            animationCam.SetActive ( false );
            gameObject.SetActive ( false );
        }
    }
}
