using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordToggleController : MonoBehaviour
{
    Toggle swordToggle;
    public GameObject swordPanel;
   

    void Start ( )
    {
        //Fetch the Toggle GameObject
        swordToggle = GetComponent<Toggle> ( );
        //Add listener for when the state of the Toggle changes, to take action
        swordToggle.onValueChanged.AddListener ( delegate {
            ToggleValueChanged ( swordToggle );
        } );

        
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged ( Toggle swToggle )
    {
        if ( swToggle.isOn )
        {
            swordPanel.SetActive ( true );
        }
        else
        {
            swordPanel.SetActive ( false );
        }
    }
}
