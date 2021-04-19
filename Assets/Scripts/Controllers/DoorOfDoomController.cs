using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOfDoomController : MonoBehaviour
{

    private GameObject canvas;
    private AudioSource hauntedMusic;
    private GameObject player;

    // Start is called before the first frame update
    private void Start ( )
    {

        player = GameObject.FindGameObjectWithTag ( "Player" );
        canvas = player.transform.Find ( "Weapon UI Canvas" ).gameObject;
        hauntedMusic = GetComponent<AudioSource> ( );

        if ( !hauntedMusic.isPlaying )
        {
            hauntedMusic.Play ( );
        }

        //for ( int i = 0 ; i < secretRoomSpots.Length ; i++ )
        //{
        //    int randomItemNum = Mathf.RoundToInt(Random.Range(0, 6));

        //    switch ( doorItems [ randomItemNum ].tag )
        //    {
        //        case "Portal":
        //            {
        //                SpawnPuzzlePortal ( secretRoomSpots [ i ] );
        //                break;
        //            }
        //        case "Ghost":
        //            {
        //                SpawnGhost ( secretRoomSpots [ i ] );
        //                break;
        //            }
        //        case "Bat":
        //            {
        //                SpawnBat ( secretRoomSpots [ i ] );
        //                break;
        //            }
        //        case "Spider":
        //            {
        //                SpawnSpider ( secretRoomSpots [ i ] );
        //                break;
        //            }
        //        case "Skeleton":
        //            {
        //                SpawnSkeleton ( secretRoomSpots [ i ] );
        //                break;
        //            }
        //        case "Buba":
        //            {
        //                SpawnLightningBuba ( secretRoomSpots [ i ] );
        //                break;
        //            }
        //        case "Treasure":
        //            {
        //                SpawnTreasureBox ( secretRoomSpots [ i ] );
        //                break;
        //            }
        //    }

        //}

    }

    private IEnumerator HideCanvas ( GameObject canvas )
    {
        yield return new WaitForSeconds ( 5f );
        canvas.gameObject.SetActive ( false );
    }

    // Update is called once per frame
    private void Update ( )
    {
        if ( Input.touchCount > 0 )
        {

            Touch touch = Input.GetTouch(0);

            if ( Input.touchCount < 1 || ( touch.phase != TouchPhase.Began ) )
            {
                return;
            }

            if ( EventSystem.current.IsPointerOverGameObject ( touch.fingerId ) )
            {
                return;

            }
        }

    }

}