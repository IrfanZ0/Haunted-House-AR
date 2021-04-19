using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiamondToggleController : MonoBehaviour
{
    Toggle diamondToggle;
    public GameObject diamondPanel;
   

    void Start ( )
    {
        //Fetch the Toggle GameObject
        diamondToggle = GetComponent<Toggle> ( );
        //Add listener for when the state of the Toggle changes, to take action
        diamondToggle.onValueChanged.AddListener ( delegate {
            ToggleValueChanged ( diamondToggle );
        } );

       
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged ( Toggle dToggle )
    {
        if ( dToggle.isOn )
        {
            diamondPanel.SetActive ( true );
        }
        else
        {
            diamondPanel.SetActive ( false );
        }
    }
}
