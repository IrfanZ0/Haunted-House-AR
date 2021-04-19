using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxeToggleController : MonoBehaviour
{
    Toggle axeToggle;
    public GameObject axePanel;
  

    void Start ( )
    {
        //Fetch the Toggle GameObject
        axeToggle = GetComponent<Toggle> ( );
        //Add listener for when the state of the Toggle changes, to take action
        axeToggle.onValueChanged.AddListener ( delegate {
            ToggleValueChanged ( axeToggle );
        } );

       
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged ( Toggle aToggle )
    {
        if (aToggle.isOn)
        {
            axePanel.SetActive ( true );
        }
        else
        {
            axePanel.SetActive ( false );
        }
       
    }
}
