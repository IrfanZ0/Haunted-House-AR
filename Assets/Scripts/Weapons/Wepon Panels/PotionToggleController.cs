using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionToggleController : MonoBehaviour
{
    Toggle potionToggle;
    public GameObject potionPanel;
   

    void Start ( )
    {
        //Fetch the Toggle GameObject
        potionToggle = GetComponent<Toggle> ( );
        //Add listener for when the state of the Toggle changes, to take action
        potionToggle.onValueChanged.AddListener ( delegate {
            ToggleValueChanged ( potionToggle );
        } );

      
    }

    //Output the new state of the Toggle into Text
    void ToggleValueChanged ( Toggle pToggle )
    {
        if ( pToggle.isOn )
        {
            potionPanel.SetActive ( true );
        }
        else
        {
            potionPanel.SetActive ( false );
        }
    }
}
