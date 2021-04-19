using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealTeleportMenu : MonoBehaviour
{
    private GameObject teleportScreen;
    private CanvasGroup teleportCanvasGroup;
    private Text teleportToggleText;
    private Toggle teleportToggle;

    // Start is called before the first frame update
    private void Start ( )
    {
        teleportToggleText = transform.Find ( "Label" ).GetComponent<Text> ( );
        teleportToggle = GetComponent<Toggle> ( );
        teleportToggle.isOn = false;
        teleportCanvasGroup = GameObject.Find ( "Level Change Canvas" ).GetComponent<CanvasGroup> ( );

    }

    private void ShowMenu ( )
    {
        teleportToggle.isOn = true;
        teleportToggleText.text = "Show Teleport Screen";
        teleportCanvasGroup.alpha = 1f;
    }

    private void HideMenu ( )
    {
        teleportToggle.isOn = false;
        teleportToggleText.text = "Hide Teleport Screen";
        teleportCanvasGroup.alpha = 0.05f;
    }

    public void OnValueChanged ( bool teleportToggleOn )
    {
        if ( teleportToggle )
        {
            ShowMenu ( );
        }
        else
        {
            HideMenu ( );
        }
    }

}