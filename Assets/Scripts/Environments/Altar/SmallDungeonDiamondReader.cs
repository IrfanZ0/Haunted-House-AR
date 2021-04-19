using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDungeonDiamondReader : MonoBehaviour, IBlueDiamondReader, IOrangeDiamondReader, IPurpleDiamondReader, IRedDiamondReader, ISilverDiamondReader, IYellowDiamondReader, IGreenDiamondReader
{
    private List<Light> lights;
    private List<GameObject> gates;
    private AudioSource successMusic;
    private AudioSource destroyedMusic;

    // Start is called before the first frame update
    private void Start ( )
    {
        successMusic = GetComponent<AudioSource> ( );
        destroyedMusic = GetComponent<AudioSource> ( );
        lights = new List<Light> ( );
        gates = new List<GameObject> ( );

        foreach ( Transform childTransform in GetComponentInParent<Transform> ( ) )
        {
            if ( childTransform.name == "torch_Left" )
            {
                Light left1Light = childTransform.Find("FireMobile").transform.Find("fire light").GetComponent<Light>();
                lights.Add ( left1Light );
            }
            if ( childTransform.name == "torch2_Left" )
            {
                Light left2Light = childTransform.Find("FireMobile").transform.Find("fire light").GetComponent<Light>();
                lights.Add ( left2Light );
            }
            if ( childTransform.name == "torch3_Left" )
            {
                Light left3Light = childTransform.Find("FireMobile").transform.Find("fire light").GetComponent<Light>();
                lights.Add ( left3Light );
            }
            if ( childTransform.name == "torch4_Left" )
            {
                Light left4Light = childTransform.Find("FireMobile").transform.Find("fire light").GetComponent<Light>();
                lights.Add ( left4Light );
            }
            if ( childTransform.name == "torch_Right" )
            {
                Light right1Light = childTransform.Find("FireMobile").transform.Find("fire light").GetComponent<Light>();
                lights.Add ( right1Light );
            }
            if ( childTransform.name == "torch2_Right" )
            {
                Light right2Light = childTransform.Find("FireMobile").transform.Find("fire light").GetComponent<Light>();
                lights.Add ( right2Light );
            }
            if ( childTransform.name == "torch3_Right" )
            {
                Light right3Light = childTransform.Find("FireMobile").transform.Find("fire light").GetComponent<Light>();
                lights.Add ( right3Light );
            }
            if ( childTransform.name == "torch4_Right" )
            {
                Light right4Light = childTransform.Find("FireMobile").transform.Find("fire light").GetComponent<Light>();
                lights.Add ( right4Light );
            }
            if ( childTransform.name == "Arch_Gate4_Right" )
            {
                gates.Add ( childTransform.gameObject );
            }
            if ( childTransform.name == "Arch_Gate3_Right" )
            {
                gates.Add ( childTransform.gameObject );
            }
            if ( childTransform.name == "Arch_Gate2_Right" )
            {
                gates.Add ( childTransform.gameObject );
            }
            if ( childTransform.name == "Arch_Gate1_Right" )
            {
                gates.Add ( childTransform.gameObject );
            }
            if ( childTransform.name == "Arch_Gate4_Left" )
            {
                gates.Add ( childTransform.gameObject );
            }
            if ( childTransform.name == "Arch_Gate3_Left" )
            {
                gates.Add ( childTransform.gameObject );
            }
            if ( childTransform.name == "Arch_Gate2_Left" )
            {
                gates.Add ( childTransform.gameObject );
            }
            if ( childTransform.name == "Arch_Gate1_Left" )
            {
                gates.Add ( childTransform.gameObject );
            }
            if ( childTransform.name == "Front Wall" )
            {
                gates.Add ( childTransform.gameObject );
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
            lights [ 0 ].intensity = 1f;
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
            lights [ 0 ].intensity = 3f;
            lights [ 0 ].color = Color.blue;
            gates [ 4 ].GetComponent<Animator> ( ).SetBool ( "Left4GateOpen" , true );
        }

    }

    public bool OrangeDiamondDestroying ( GameObject orangeDiamond )
    {
        bool isDestroyed = false;

        if ( orangeDiamond != null )
        {
            Destroy ( orangeDiamond.gameObject , 30f );
            lights [ 1 ].intensity = 1f;
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
            lights [ 1 ].intensity = 3f;
            lights [ 1 ].color = new Color ( 255 , 165 , 0 , 255 );
            gates [ 5 ].GetComponent<Animator> ( ).SetBool ( "Left3GateOpen" , true );
        }

    }

    public bool PurpleDiamondDestroying ( GameObject purpleDiamond )
    {
        bool isDestroyed = false;

        if ( purpleDiamond != null )
        {
            Destroy ( purpleDiamond.gameObject , 30f );
            lights [ 2 ].intensity = 1f;
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
            lights [ 2 ].intensity = 3f;
            lights [ 2 ].color = new Color ( 128 , 0 , 128 , 255 );
            gates [ 6 ].GetComponent<Animator> ( ).SetBool ( "Left2GateOpen" , true );
        }

    }

    public bool RedDiamondDestroying ( GameObject redDiamond )
    {
        bool isDestroyed = false;

        if ( redDiamond != null )
        {
            Destroy ( redDiamond.gameObject , 30f );
            lights [ 3 ].intensity = 1f;
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
            lights [ 3 ].intensity = 3f;
            lights [ 3 ].color = Color.red;
            gates [ 7 ].GetComponent<Animator> ( ).SetBool ( "Left1GateOpen" , true );
        }

    }

    public bool SilverDiamondDestroying ( GameObject silverDiamond )
    {
        bool isDestroyed = false;

        if ( silverDiamond != null )
        {
            Destroy ( silverDiamond.gameObject , 30f );
            lights [ 4 ].intensity = 1f;
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
            lights [ 4 ].intensity = 3f;
            lights [ 4 ].color = new Color ( 169 , 169 , 169 , 255 );
            gates [ 3 ].GetComponent<Animator> ( ).SetBool ( "Right1GateOpen" , true );
        }

    }

    public bool YellowDiamondDestroying ( GameObject yellowDiamond )
    {
        bool isDestroyed = false;

        if ( yellowDiamond != null )
        {
            Destroy ( yellowDiamond.gameObject , 30f );
            lights [ 5 ].intensity = 1f;
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
            lights [ 5 ].intensity = 3f;
            lights [ 5 ].color = Color.yellow;
            gates [ 2 ].GetComponent<Animator> ( ).SetBool ( "Right2GateOpen" , true );
        }

    }

    public bool GreenDiamondScanning ( GameObject greenDiamond )
    {
        bool isScanned = true;

        greenDiamond.transform.parent = transform;

        greenDiamond.GetComponent<Rigidbody> ( ).constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        return isScanned;
    }

    public void GreenDiamondTriggering ( GameObject greenDiamond )
    {
        if ( greenDiamond != null )
        {
            gates [ 8 ].GetComponent<Animator> ( ).SetBool ( "FrontWallOpen" , true );
        }
    }

    public bool GreenDiamondDestroying ( GameObject greenDiamond )
    {
        bool isDestroyed = false;

        if ( greenDiamond != null )
        {
            Destroy ( greenDiamond.gameObject , 30f );
            isDestroyed = true;
        }

        return isDestroyed;
    }
}