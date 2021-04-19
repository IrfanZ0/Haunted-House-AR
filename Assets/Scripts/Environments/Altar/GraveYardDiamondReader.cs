using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraveYardDiamondReader : MonoBehaviour, IOrangeDiamondReader, IPurpleDiamondReader, IRedDiamondReader, IYellowDiamondReader, IBlueDiamondReader
{
    private GameObject mazeHolder;
    private GameObject altar;
    private Text altarTextBox;
    private GameObject enterPortal;
    private string message;

    // Start is called before the first frame update
    private void Start ( )
    {
        mazeHolder = transform.root.transform.Find ( "MazeHolder" ).gameObject;
        altar = transform.root.Find ( "altar Grave Yard" ).gameObject;
        altarTextBox = altar.transform.Find ( "Altar Canvas" ).transform.Find ( "Panel" ).transform.Find ( "Text" ).GetComponent<Text> ( );
        message = "Welcome to the Yellow Diamond Grave Yard Maze";
        StartCoroutine ( DisplayText ( message ) );
        message = "Traverse the grave yard to find the altar and treasure";
        StartCoroutine ( DisplayText ( message ) );
        enterPortal = mazeHolder.transform.Find ( "Enter Portal" ).gameObject;
    }

    private IEnumerator DisplayText ( string instruction )
    {
        altarTextBox.transform.parent.parent.gameObject.SetActive ( true );
        altarTextBox.text = instruction;
        yield return new WaitForSeconds ( 4f );
        altarTextBox.transform.parent.parent.gameObject.SetActive ( false );

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
        StartCoroutine ( RevealGraveYard ( blueDiamond.name ) );
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
        StartCoroutine ( RevealGraveYard ( orangeDiamond.name ) );
    }

    public bool PurpleDiamondDestroying ( GameObject purpleDiamond )
    {
        bool isDestroyed = false;

        if ( purpleDiamond != null )
        {
            Destroy ( purpleDiamond.gameObject , 30f );
            isDestroyed = true;
        }

        return isDestroyed;
    }

    public bool PurpleDiamondScanning ( GameObject purpleDiamond )
    {
        bool isScanned = true;

        purpleDiamond.transform.parent = transform;

        purpleDiamond.GetComponent<Rigidbody> ( ).constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        return isScanned;
    }

    public void PurpleDiamondTriggering ( GameObject purpleDiamond )
    {
        StartCoroutine ( RevealGraveYard ( purpleDiamond.name ) );
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
        StartCoroutine ( RevealGraveYard ( redDiamond.name ) );
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
        StartCoroutine ( RevealGraveYard ( yellowDiamond.name ) );
    }

    private IEnumerator RevealGraveYard ( string diamondName )
    {
        yield return new WaitForSeconds ( 5f );

        switch ( diamondName )
        {
            case "Blue Diamond":
                {
                    SceneManager.LoadScene ( "Blue Diamond GraveYard" );
                    break;
                }
            case "Orange Diamond":
                {
                    SceneManager.LoadScene ( "Orange Diamond GraveYard" );
                    break;
                }
            case "Purple Diamond":
                {
                    SceneManager.LoadScene ( "Purple Diamond GraveYard" );
                    break;
                }
            case "Red Diamond":
                {
                    SceneManager.LoadScene ( "Red Diamond GraveYard" );
                    break;
                }
            case "Yellow Diamond":
                {
                    SceneManager.LoadScene ( "Yellow Diamond GraveYard" );
                    break;
                }
        }

    }

}