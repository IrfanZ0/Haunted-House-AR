using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SmallDungeonTeleport : MonoBehaviour
{
    private Text teleportText;
    public GameObject teleporterGO;
    private GameObject teleport;
    private Transform player;
    private Teleport teleportScript;
    private Toggle smallDungeonToggle;

    // Start is called before the first frame update
    private void Start ( )
    {
        teleportText = transform.parent.transform.Find ( "Text" ).GetComponent<Text> ( );
        player = GameObject.FindGameObjectWithTag ( "Player" ).transform;
        smallDungeonToggle = GetComponent<Toggle> ( );
    }

    private void Update ( )
    {
        if ( smallDungeonToggle.isOn )
        {
            TeleportToSmallDungeon ( true );
        }
        else
        {
            TeleportToSmallDungeon ( false );
        }
    }

    public void TeleportToSmallDungeon ( bool teleporting )
    {
        if ( teleporting )
        {
            teleportText.text = "Teleporting to Small Dungeon";
            SpawnTeleport ( );

            teleportScript = teleport.transform.Find ( "Particle System" ).GetComponent<Teleport> ( );
            teleportScript.SetSceneName ( "Small Dungeon" );
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
        smallDungeonToggle.isOn = false;

    }
}