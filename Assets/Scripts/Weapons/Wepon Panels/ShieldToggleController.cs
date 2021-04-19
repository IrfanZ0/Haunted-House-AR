using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldToggleController : MonoBehaviour
{
    Toggle shieldToggle;
    public GameObject shieldPanel;
  

    void Start ( )
    {
        //Fetch the Toggle GameObject
        shieldToggle = GetComponent<Toggle> ( );
        //Add listener for when the state of the Toggle changes, to take action
        shieldToggle.onValueChanged.AddListener ( delegate {
            ToggleValueChanged ( shieldToggle );
        } );

      
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged ( Toggle shToggle )
    {
        if ( shToggle.isOn )
        {
            shieldPanel.SetActive ( true );
        }
        else
        {
            shieldPanel.SetActive ( false );
        }
    }
}
