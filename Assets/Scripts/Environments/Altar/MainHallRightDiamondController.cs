using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHallRightDiamondController : MonoBehaviour, IBlueDiamondReader, IOrangeDiamondReader, IRedDiamondReader, ISilverDiamondReader, IYellowDiamondReader, IPurpleDiamondReader
{
    private List<GameObject> rightDiamondDoors;
    private Light rightBlueDiamondLight;
    private Light rightOrangeDiamondLight;
    private Light rightRedDiamondLight;
    private Light rightSilverDiamondLight;
    private Light rightYellowDiamondLight;
    private Light rightPurpleDiamondLight;
    private AudioSource successMusic;
    private AudioSource destroyedMusic;

    private void Start ( )
    {
        successMusic = GetComponent<AudioSource> ( );
        destroyedMusic = GetComponent<AudioSource> ( );

        rightDiamondDoors = new List<GameObject> ( );

        foreach ( Transform doorTransform in GetComponentInParent<Transform> ( ) )
        {
            if ( doorTransform.name == "blue diamond door" )
            {
                rightDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "orange diamond door" )
            {
                rightDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "red diamond door" )
            {
                rightDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "silver diamond door" )
            {
                rightDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "yellow diamond door" )
            {
                rightDiamondDoors.Add ( doorTransform.gameObject );
            }

            if ( doorTransform.name == "purple diamond door" )
            {
                rightDiamondDoors.Add ( doorTransform.gameObject );
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
            rightBlueDiamondLight.intensity = 1f;
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
            rightBlueDiamondLight = rightDiamondDoors [ 0 ].transform.Find ( "right door" ).transform.Find ( "blue diamond" ).GetComponent<Light> ( );
            rightBlueDiamondLight.intensity = 3f;
        }

    }

    public bool OrangeDiamondDestroying ( GameObject orangeDiamond )
    {
        bool isDestroyed = false;

        if ( orangeDiamond != null )
        {
            Destroy ( orangeDiamond.gameObject , 30f );
            rightOrangeDiamondLight.intensity = 1f;
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
            rightOrangeDiamondLight = rightDiamondDoors [ 1 ].transform.Find ( "right door" ).transform.Find ( "orange diamond" ).GetComponent<Light> ( );
            rightOrangeDiamondLight.intensity = 3f;
        }

    }

    public bool PurpleDiamondDestroying ( GameObject purpleDiamond )
    {
        bool isDestroyed = false;

        if ( purpleDiamond != null )
        {
            Destroy ( purpleDiamond.gameObject , 30f );
            rightPurpleDiamondLight.intensity = 1f;
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
            rightPurpleDiamondLight = rightDiamondDoors [ 5 ].transform.Find ( "right door" ).transform.Find ( "purple diamond" ).GetComponent<Light> ( );
            rightPurpleDiamondLight.intensity = 3f;
        }

    }

    public bool RedDiamondDestroying ( GameObject redDiamond )
    {
        bool isDestroyed = false;

        if ( redDiamond != null )
        {
            Destroy ( redDiamond.gameObject , 30f );
            rightRedDiamondLight.intensity = 1f;
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
            rightRedDiamondLight = rightDiamondDoors [ 2 ].transform.Find ( "right door" ).transform.Find ( "red diamond" ).GetComponent<Light> ( );
            rightRedDiamondLight.intensity = 3f;
        }

    }

    public bool SilverDiamondDestroying ( GameObject silverDiamond )
    {
        bool isDestroyed = false;

        if ( silverDiamond != null )
        {
            Destroy ( silverDiamond.gameObject , 30f );
            rightSilverDiamondLight.intensity = 1f;
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
            rightSilverDiamondLight = rightDiamondDoors [ 3 ].transform.Find ( "right door" ).transform.Find ( "silver diamond" ).GetComponent<Light> ( );
            rightSilverDiamondLight.intensity = 3f;
        }

    }

    public bool YellowDiamondDestroying ( GameObject yellowDiamond )
    {
        bool isDestroyed = false;

        if ( yellowDiamond != null )
        {
            Destroy ( yellowDiamond.gameObject , 30f );
            rightYellowDiamondLight.intensity = 1f;
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
            rightYellowDiamondLight = rightDiamondDoors [ 4 ].transform.Find ( "right door" ).transform.Find ( "yellow diamond" ).GetComponent<Light> ( );
            rightYellowDiamondLight.intensity = 3f;
        }

    }

}