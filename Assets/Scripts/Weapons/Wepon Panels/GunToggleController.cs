using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunToggleController : MonoBehaviour
{
    Toggle gunToggle;
    public GameObject gunPanel;
   

    void Start ( )
    {
        //Fetch the Toggle GameObject
       gunToggle = GetComponent<Toggle> ( );
        //Add listener for when the state of the Toggle changes, to take action
       gunToggle.onValueChanged.AddListener ( delegate {
            ToggleValueChanged (gunToggle );
        } );

       
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged ( Toggle gToggle )
    {
        if ( gToggle.isOn )
        {
            gunPanel.SetActive ( true );
        }
        else
        {
            gunPanel.SetActive ( false );
        }
    }
}
