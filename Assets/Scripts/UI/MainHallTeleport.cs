using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainHallTeleport : MonoBehaviour
{
    private Text teleportText;
    public GameObject teleporterGO;
    private GameObject teleport;
    private Transform player;
    private Teleport teleportScript;
    private Toggle mainHallToggle;

    // Start is called before the first frame update
    private void Start ( )
    {
        teleportText = transform.parent.transform.Find ( "Text" ).GetComponent<Text> ( );
        player = GameObject.FindGameObjectWithTag ( "Player" ).transform;
        mainHallToggle = GetComponent<Toggle> ( );

    }

    private void Update ( )
    {
        if ( mainHallToggle.isOn )
        {
            TeleportToMainHall ( true );
        }
        else
        {
            TeleportToMainHall ( false );
        }
    }

    public void TeleportToMainHall ( bool teleporting )
    {
        if ( teleporting && teleport == null )
        {
            teleportText.text = "Teleporting to Main Hall";
            SpawnTeleport ( );

            teleportScript = teleport.transform.Find ( "Particle System" ).GetComponent<Teleport> ( );
            teleportScript.SetSceneName ( "Main Hall" );
            teleporting = false;
            StartCoroutine ( ClosingTeleport ( ) );

        }
        else
        {

        }

    }

    private void SpawnTeleport ( )
    {
        if ( teleport != null )
        {
            Destroy ( teleport.gameObject , 2f );
        }

        teleport = Instantiate ( teleporterGO ) as GameObject;
        teleport.SetActive ( true );

    }

    private IEnumerator ClosingTeleport ( )
    {
        yield return new WaitForSeconds ( 1f );
        teleportText.text = "Teleport to: ";
        mainHallToggle.isOn = false;

    }
}