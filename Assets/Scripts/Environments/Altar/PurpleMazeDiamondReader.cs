using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurpleMazeDiamondReader : MonoBehaviour, IBlueDiamondReader, IOrangeDiamondReader, IRedDiamondReader, IYellowDiamondReader
{
    private GameObject mazeHolder;
    private GameObject altar;
    private Text altarTextBox;
    private GameObject enterPortal;
    public GameObject treasureBoxGO;
    private GameObject treasureBox;

    private void Start ( )
    {
        mazeHolder = transform.root.transform.Find ( "MazeHolder" ).gameObject;
        altar = mazeHolder.transform.Find ( "altar" ).gameObject;
        altarTextBox = altar.transform.Find ( "Altar Canvas" ).transform.Find ( "Panel" ).transform.Find ( "Text" ).GetComponent<Text> ( );
        enterPortal = mazeHolder.transform.Find ( "Enter Portal" ).gameObject;
    }

    private void OnTriggerEnter ( Collider other )
    {
        GameObject diamond = other.gameObject;

        switch ( diamond.name )
        {
            case "Orange Diamond":
                {
                    if ( OrangeDiamondScanning ( diamond ) )
                    {
                        OrangeDiamondTriggering ( diamond );
                    }
                    else
                    {
                        OrangeDiamondDestroying ( diamond );
                    }

                    break;
                }
            case "Blue Diamond":
                {
                    if ( BlueDiamondScanning ( diamond ) )
                    {
                        BlueDiamondTriggering ( diamond );
                    }
                    else
                    {
                        BlueDiamondDestroying ( diamond );
                    }

                    break;
                }
            case "Red Diamond":
                {
                    if ( RedDiamondScanning ( diamond ) )
                    {
                        RedDiamondTriggering ( diamond );
                    }
                    else
                    {
                        RedDiamondDestroying ( diamond );
                    }
                    break;
                }
            case "Yellow Diamond":
                {
                    if ( YellowDiamondScanning ( diamond ) )
                    {
                        YellowDiamondTriggering ( diamond );
                    }
                    else
                    {
                        YellowDiamondDestroying ( diamond );
                    }
                    break;
                }
        }
    }

    private void Update ( )
    {

    }

    public bool BlueDiamondDestroying ( GameObject blueDiamond )
    {
        bool isDestroyed = false;

        if ( blueDiamond != null )
        {
            Destroy ( blueDiamond.gameObject , 30f );
            isDestroyed = true;
        }

        return isDestroyed;
    }

    public bool BlueDiamondScanning ( GameObject blueDiamond )
    {
        bool isScanned = true;

        blueDiamond.transform.parent = transform;

        blueDiamond.GetComponent<Rigidbody> ( ).constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        return isScanned;
    }

    public void BlueDiamondTriggering ( GameObject blueDiamond )
    {
        StartCoroutine ( AltarSpeaks ( blueDiamond.name ) );
        StartCoroutine ( RevealPassage ( altar ) );
    }

    public bool OrangeDiamondDestroying ( GameObject orangeDiamond )
    {
        bool isDestroyed = false;

        if ( orangeDiamond != null )
        {
            Destroy ( orangeDiamond.gameObject , 30f );
            isDestroyed = true;
        }

        return isDestroyed;
    }

    public bool OrangeDiamondScanning ( GameObject orangeDiamond )
    {
        bool isScanned = true;

        orangeDiamond.transform.parent = transform;

        orangeDiamond.GetComponent<Rigidbody> ( ).constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        return isScanned;
    }

    public void OrangeDiamondTriggering ( GameObject orangeDiamond )
    {
        StartCoroutine ( AltarSpeaks ( orangeDiamond.name ) );
        StartCoroutine ( RevealPassage ( altar ) );
    }

    public bool RedDiamondDestroying ( GameObject redDiamond )
    {
        bool isDestroyed = false;

        if ( redDiamond != null )
        {
            Destroy ( redDiamond.gameObject , 30f );
            isDestroyed = true;
        }

        return isDestroyed;
    }

    public bool RedDiamondScanning ( GameObject redDiamond )
    {
        bool isScanned = true;

        redDiamond.transform.parent = transform;

        redDiamond.GetComponent<Rigidbody> ( ).constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        return isScanned;
    }

    public void RedDiamondTriggering ( GameObject redDiamond )
    {
        StartCoroutine ( AltarSpeaks ( redDiamond.name ) );
        StartCoroutine ( RevealPassage ( altar ) );
    }

    public bool YellowDiamondDestroying ( GameObject yellowDiamond )
    {
        bool isDestroyed = false;

        if ( yellowDiamond != null )
        {
            Destroy ( yellowDiamond.gameObject , 30f );
            isDestroyed = true;
        }

        return isDestroyed;
    }

    public bool YellowDiamondScanning ( GameObject yellowDiamond )
    {
        bool isScanned = true;

        yellowDiamond.transform.parent = transform;

        yellowDiamond.GetComponent<Rigidbody> ( ).constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        return isScanned;
    }

    public void YellowDiamondTriggering ( GameObject yellowDiamond )
    {
        StartCoroutine ( AltarSpeaks ( yellowDiamond.name ) );
        StartCoroutine ( RevealPassage ( altar ) );
    }

    private IEnumerator AltarSpeaks ( string diamondName )
    {
        altarTextBox.text = "Greetings treasure hunter.";
        yield return new WaitForSeconds ( 5f );
        altarTextBox.text = "If you seek to find more treasure in the graveyard.  Provide me a diamond, and I will transport you.";
        yield return new WaitForSeconds ( 5f );
        altarTextBox.text = "From here you could be transported to Blue, Orange, Red, and Yellow mazes.";
        yield return new WaitForSeconds ( 5f );

    }

    private IEnumerator RevealPassage ( GameObject altar )
    {
        var material = altar.transform.Find("altar").GetComponent<MeshRenderer>().material;
        float fadePerSecond = 2.5f;
        material.color = new Color ( material.color.r , material.color.g , material.color.b , material.color.a - fadePerSecond * Time.deltaTime );
        yield return new WaitForSeconds ( fadePerSecond );
        enterPortal.SetActive ( true );
        enterPortal.transform.localPosition = new Vector3 ( altar.transform.localPosition.x + 0.4f , altar.transform.localPosition.y , altar.transform.localPosition.z );
        yield return new WaitForSeconds ( 2f );
        treasureBox = Instantiate ( treasureBox ) as GameObject;
        treasureBox.SetActive ( true );
        treasureBox.transform.localPosition = new Vector3 ( altar.transform.localPosition.x - 0.4f , altar.transform.localPosition.y , altar.transform.localPosition.z );

    }

}