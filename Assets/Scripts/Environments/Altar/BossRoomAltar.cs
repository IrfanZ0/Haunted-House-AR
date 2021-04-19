using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomAltar : MonoBehaviour, IRedDiamondReader, IYellowDiamondReader, IBlueDiamondReader, ISilverDiamondReader, IPurpleDiamondReader, IGreenDiamondReader
{
    private List<Light> lights;
    private Animator bossDoorRightAnim;
    private Animator bossDoorLeftAnim;
    private GameObject bossLock;
    private AudioSource successMusic;

    // Start is called before the first frame update
    private void Start ( )
    {
        bossDoorRightAnim = GameObject.Find ( "Boss Dungeon" ).transform.Find ( "Boss Lair" ).transform.Find ( "door2" ).transform.Find ( "door2_Right" ).GetComponent<Animator> ( );
        bossDoorLeftAnim = GameObject.Find ( "Boss Dungeon" ).transform.Find ( "Boss Lair" ).transform.Find ( "door2" ).transform.Find ( "door2_Left" ).GetComponent<Animator> ( );

        lights = new List<Light> ( );

        bossLock = transform.root.transform.Find ( "Boss Room HallWay" ).transform.Find ( "Canvas" ).transform.Find ( "Boss Lock" ).gameObject;

        lights.AddRange ( bossLock.GetComponentsInChildren<Light> ( true ) );
        successMusic = GetComponent<AudioSource> ( );

    }

    // Update is called once per frame
    private void Update ( )
    {
        if ( lights [ 0 ].intensity > 1 && lights [ 1 ].intensity > 1 && lights [ 2 ].intensity > 1 && lights [ 3 ].intensity > 1 && lights [ 4 ].intensity > 1 && lights [ 5 ].intensity > 1 )
        {
            if ( !successMusic.isPlaying )
            {
                successMusic.Play ( );
            }

            bossDoorRightAnim.SetBool ( "BossRightDoorOpen" , true );
            bossDoorLeftAnim.SetBool ( "BossLeftDoorOpen" , true );
        }

    }

    public bool BlueDiamondDestroying ( GameObject blueDiamond )
    {
        bool isDestroyed = false;

        if ( blueDiamond != null )
        {
            Destroy ( blueDiamond.gameObject , 30f );
            lights [ 5 ].intensity = 1f;
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
            lights [ 5 ].gameObject.SetActive ( true );
            lights [ 5 ].intensity = 3f;
            lights [ 5 ].color = Color.blue;

        }

    }

    public bool YellowDiamondDestroying ( GameObject yellowDiamond )
    {
        bool isDestroyed = false;

        if ( yellowDiamond != null )
        {
            Destroy ( yellowDiamond.gameObject , 30f );
            lights [ 0 ].intensity = 1f;
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
            lights [ 0 ].gameObject.SetActive ( true );
            lights [ 0 ].intensity = 3f;
            lights [ 0 ].color = new Color ( 255 , 165 , 0 , 255 );

        }

    }

    public bool PurpleDiamondDestroying ( GameObject purpleDiamond )
    {
        bool isDestroyed = false;

        if ( purpleDiamond != null )
        {
            Destroy ( purpleDiamond.gameObject , 30f );
            lights [ 3 ].intensity = 1f;
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
            lights [ 3 ].gameObject.SetActive ( true );
            lights [ 3 ].intensity = 3f;
            lights [ 3 ].color = new Color ( 128 , 0 , 128 , 255 );

        }

    }

    public bool RedDiamondDestroying ( GameObject redDiamond )
    {
        bool isDestroyed = false;

        if ( redDiamond != null )
        {
            Destroy ( redDiamond.gameObject , 30f );
            lights [ 1 ].intensity = 1f;
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
            lights [ 1 ].gameObject.SetActive ( true );
            lights [ 1 ].intensity = 3f;
            lights [ 1 ].color = Color.red;

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
            lights [ 4 ].gameObject.SetActive ( true );
            lights [ 4 ].intensity = 3f;
            lights [ 4 ].color = new Color ( 169 , 169 , 169 , 255 );

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
            lights [ 2 ].gameObject.SetActive ( true );
            lights [ 2 ].intensity = 3f;
            lights [ 2 ].color = Color.yellow;
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