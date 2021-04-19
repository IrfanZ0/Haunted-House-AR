using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHallLeftDiamondCOntroller : MonoBehaviour, IBlueDiamondReader, IOrangeDiamondReader, IRedDiamondReader, ISilverDiamondReader, IYellowDiamondReader, IPurpleDiamondReader
{
    private List<GameObject> leftDiamondDoors;
    private Light leftBlueDiamondLight;
    private Light leftOrangeDiamondLight;
    private Light leftRedDiamondLight;
    private Light leftSilverDiamondLight;
    private Light leftYellowDiamondLight;
    private Light leftPurpleDiamondLight;
    private AudioSource successMusic;
    private AudioSource destroyedMusic;

    private void Start ( )
    {
        successMusic = GetComponent<AudioSource> ( );
        destroyedMusic = GetComponent<AudioSource> ( );

        leftDiamondDoors = new List<GameObject> ( );

        foreach ( Transform doorTransform in GetComponentInParent<Transform> ( ) )
        {
            if ( doorTransform.name == "blue diamond door" )
            {
                leftDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "orange diamond door" )
            {
                leftDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "red diamond door" )
            {
                leftDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "silver diamond door" )
            {
                leftDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "yellow diamond door" )
            {
                leftDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "purple diamond door" )
            {
                leftDiamondDoors.Add ( doorTransform.gameObject );
            }
        }

    }

    private void OnTriggerEnter ( Collider other )
    {

        if ( other.gameObject.CompareTag ( "Treasure" ) )
        {
            string diamondName = other.gameObject.name;

            switch ( diamondName )
            {
                case "Blue Diamond":
                    {

                        if ( BlueDiamondScanning ( other.gameObject ) )
                        {
                            if ( successMusic.clip.name.Contains ( "Success" ) && !successMusic.isPlaying )
                            {
                                successMusic.Play ( );
                            }

                            BlueDiamondTriggering ( other.gameObject );
                        }
                        else
                        {
                            other.gameObject.transform.localPosition = Vector3.zero;
                        }

                        break;
                    }
                case "Orange Diamond":
                    {
                        if ( OrangeDiamondScanning ( other.gameObject ) )
                        {
                            if ( successMusic.clip.name.Contains ( "Success" ) && !successMusic.isPlaying )
                            {
                                successMusic.Play ( );
                            }

                            OrangeDiamondTriggering ( other.gameObject );
                        }
                        else
                        {
                            other.gameObject.transform.localPosition = Vector3.zero;
                        }

                        break;
                    }
                case "Red Diamond":
                    {
                        if ( RedDiamondScanning ( other.gameObject ) )
                        {
                            if ( successMusic.clip.name.Contains ( "Success" ) && !successMusic.isPlaying )
                            {
                                successMusic.Play ( );
                            }

                            RedDiamondTriggering ( other.gameObject );
                        }
                        else
                        {
                            other.gameObject.transform.localPosition = Vector3.zero;
                        }

                        break;
                    }
                case "Silver Diamond":
                    {
                        if ( SilverDiamondScanning ( other.gameObject ) )
                        {
                            if ( successMusic.clip.name.Contains ( "Success" ) && !successMusic.isPlaying )
                            {
                                successMusic.Play ( );
                            }

                            SilverDiamondTriggering ( other.gameObject );
                        }
                        else
                        {
                            other.gameObject.transform.localPosition = Vector3.zero;
                        }

                        break;
                    }
                case "Yellow Diamond":
                    {
                        if ( YellowDiamondScanning ( other.gameObject ) )
                        {
                            if ( successMusic.clip.name.Contains ( "Success" ) && !successMusic.isPlaying )
                            {
                                successMusic.Play ( );
                            }

                            YellowDiamondTriggering ( other.gameObject );
                        }
                        else
                        {
                            other.gameObject.transform.localPosition = Vector3.zero;
                        }

                        break;
                    }
                case "Purple Diamond":
                    {
                        if ( PurpleDiamondScanning ( other.gameObject ) )
                        {
                            if ( successMusic.clip.name.Contains ( "Success" ) && !successMusic.isPlaying )
                            {
                                successMusic.Play ( );
                            }

                            PurpleDiamondTriggering ( other.gameObject );
                        }
                        else
                        {
                            other.gameObject.transform.localPosition = Vector3.zero;
                        }
                        break;
                    }

            }
        }

    }

    private void OnTriggerStay ( Collider other )
    {

        if ( other.gameObject.CompareTag ( "Treasure" ) )
        {
            string diamondName = other.gameObject.name;

            switch ( diamondName )
            {
                case "Blue Diamond":
                    {
                        if ( BlueDiamondDestroying ( other.gameObject ) )
                        {
                            if ( destroyedMusic.clip.name.Contains ( "Missed" ) && !destroyedMusic.isPlaying )
                            {
                                destroyedMusic.Play ( );
                            }

                        }

                        break;
                    }
                case "Orange Diamond":
                    {
                        if ( OrangeDiamondDestroying ( other.gameObject ) )
                        {
                            if ( destroyedMusic.clip.name.Contains ( "Missed" ) && !destroyedMusic.isPlaying )
                            {
                                destroyedMusic.Play ( );
                            }

                        }

                        break;
                    }
                case "Red Diamond":
                    {
                        if ( RedDiamondDestroying ( other.gameObject ) )
                        {
                            if ( destroyedMusic.clip.name.Contains ( "Missed" ) && !destroyedMusic.isPlaying )
                            {
                                destroyedMusic.Play ( );
                            }

                        }

                        break;
                    }
                case "Silver Diamond":
                    {
                        if ( SilverDiamondDestroying ( other.gameObject ) )
                        {
                            if ( destroyedMusic.clip.name.Contains ( "Missed" ) && !destroyedMusic.isPlaying )
                            {
                                destroyedMusic.Play ( );
                            }

                        }

                        break;
                    }
                case "Yellow Diamond":
                    {
                        if ( YellowDiamondDestroying ( other.gameObject ) )
                        {
                            if ( destroyedMusic.clip.name.Contains ( "Missed" ) && !destroyedMusic.isPlaying )
                            {
                                destroyedMusic.Play ( );
                            }

                        }

                        break;
                    }

            }
        }

    }

    public bool BlueDiamondDestroying ( GameObject blueDiamond )
    {
        bool isDestroyed = false;

        if ( blueDiamond != null )
        {
            Destroy ( blueDiamond.gameObject , 30f );
            leftBlueDiamondLight.intensity = 1f;
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
        if ( blueDiamond != null )
        {
            leftBlueDiamondLight = leftDiamondDoors [ 0 ].transform.Find ( "left door" ).transform.Find ( "blue diamond" ).GetComponent<Light> ( );
            leftBlueDiamondLight.intensity = 3f;
        }

    }

    public bool OrangeDiamondDestroying ( GameObject orangeDiamond )
    {
        bool isDestroyed = false;

        if ( orangeDiamond != null )
        {
            Destroy ( orangeDiamond.gameObject , 30f );
            leftOrangeDiamondLight.intensity = 1f;
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
        if ( orangeDiamond != null )
        {
            leftOrangeDiamondLight = leftDiamondDoors [ 1 ].transform.Find ( "left door" ).transform.Find ( "orange diamond" ).GetComponent<Light> ( );
            leftOrangeDiamondLight.intensity = 3f;
        }

    }

    public bool PurpleDiamondDestroying ( GameObject purpleDiamond )
    {
        bool isDestroyed = false;

        if ( purpleDiamond != null )
        {
            Destroy ( purpleDiamond.gameObject , 30f );
            leftPurpleDiamondLight.intensity = 1f;
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
        if ( purpleDiamond != null )
        {
            leftPurpleDiamondLight = leftDiamondDoors [ 5 ].transform.Find ( "left door" ).transform.Find ( "purple diamond" ).GetComponent<Light> ( );
            leftPurpleDiamondLight.intensity = 3f;
        }

    }

    public bool RedDiamondDestroying ( GameObject redDiamond )
    {
        bool isDestroyed = false;

        if ( redDiamond != null )
        {
            Destroy ( redDiamond.gameObject , 30f );
            leftRedDiamondLight.intensity = 1f;
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
        if ( redDiamond != null )
        {
            leftRedDiamondLight = leftDiamondDoors [ 2 ].transform.Find ( "left door" ).transform.Find ( "red diamond" ).GetComponent<Light> ( );
            leftRedDiamondLight.intensity = 3f;
        }

    }

    public bool SilverDiamondDestroying ( GameObject silverDiamond )
    {
        bool isDestroyed = false;

        if ( silverDiamond != null )
        {
            Destroy ( silverDiamond.gameObject , 30f );
            leftSilverDiamondLight.intensity = 1f;
            isDestroyed = true;
        }

        return isDestroyed;
    }

    public bool SilverDiamondScanning ( GameObject silverDiamond )
    {
        bool isScanned = true;

        silverDiamond.transform.parent = transform;

        silverDiamond.GetComponent<Rigidbody> ( ).constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        return isScanned;
    }

    public void SilverDiamondTriggering ( GameObject silverDiamond )
    {
        if ( silverDiamond != null )
        {
            leftSilverDiamondLight = leftDiamondDoors [ 3 ].transform.Find ( "left door" ).transform.Find ( "silver diamond" ).GetComponent<Light> ( );
            leftSilverDiamondLight.intensity = 3f;
        }

    }

    public bool YellowDiamondDestroying ( GameObject yellowDiamond )
    {
        bool isDestroyed = false;

        if ( yellowDiamond != null )
        {
            Destroy ( yellowDiamond.gameObject , 30f );
            leftYellowDiamondLight.intensity = 1f;
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
        if ( yellowDiamond != null )
        {
            leftYellowDiamondLight = leftDiamondDoors [ 4 ].transform.Find ( "left door" ).transform.Find ( "yellow diamond" ).GetComponent<Light> ( );
            leftYellowDiamondLight.intensity = 3f;
        }

    }
}