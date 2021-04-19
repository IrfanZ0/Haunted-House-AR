using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LargeDungeonTeleport : MonoBehaviour
{
    private Text teleportText;
    public GameObject teleporterGO;
    private GameObject teleport;
    private Transform player;
    private Teleport teleportScript;
    private Toggle largeDungeonToggle;

    // Start is called before the first frame update
    private void Start ( )
    {
        teleportText = transform.parent.transform.Find ( "Text" ).GetComponent<Text> ( );
        player = GameObject.FindGameObjectWithTag ( "Player" ).transform;
        largeDungeonToggle = GetComponent<Toggle> ( );
    }

    private void Update ( )
    {
        if ( largeDungeonToggle.isOn )
        {
            TeleportToLargeDungeon ( true );
        }
        else
        {
            TeleportToLargeDungeon ( false );
        }
    }

    public void TeleportToLargeDungeon ( bool teleporting )
    {
        if ( teleporting )
        {
            teleportText.text = "Teleporting to Large Dungeon";
            SpawnTeleport ( );
            teleportScript = teleport.transform.Find ( "Particle System" ).GetComponent<Teleport> ( );
            teleportScript.SetSceneName ( "Large Dungeon" );
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
        yield return new WaitForSeconds ( 30f );
        teleportText.text = "Teleport to: ";
        teleport.SetActive ( false );
        largeDungeonToggle.isOn = false;

    }
}