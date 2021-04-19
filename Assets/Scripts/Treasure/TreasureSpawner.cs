using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public GameObject blueDiamondGO;
    private GameObject blueDiamond;
    public GameObject orangeDiamondGO;
    private GameObject orangeDiamond;
    public GameObject redDiamondGO;
    private GameObject redDiamond;
    public GameObject silverDiamondGO;
    private GameObject silverDiamond;
    public GameObject purpleDiamondGO;
    private GameObject purpleDiamond;
    public GameObject yellowDiamondGO;
    private GameObject yellowDiamond;
    public GameObject coinBagGO;
    private GameObject coinBag;
    public GameObject medievalAxeGO;
    private GameObject medievalAxe;
    public GameObject hellWailerGO;
    private GameObject hellWailer;
    public GameObject bluePotionGO;
    private GameObject bluePotion;
    public GameObject redPotionGO;
    private GameObject redPotion;
    public GameObject gutterSwordGO;
    private GameObject gutterSword;
    private List<GameObject> treasureItems;
    private Animator treasureChestAnim;
    private int treasureRandomNumber;
    private float speed;
    private RaycastHit hit;

    // Start is called before the first frame update
    private void Start ( )
    {
        speed = 3f;
        treasureItems = new List<GameObject> ( );
        treasureItems.Add ( blueDiamondGO );
        treasureItems.Add ( orangeDiamondGO );
        treasureItems.Add ( redDiamondGO );
        treasureItems.Add ( silverDiamondGO );
        treasureItems.Add ( purpleDiamondGO );
        treasureItems.Add ( yellowDiamondGO );
        treasureItems.Add ( coinBagGO );
        treasureItems.Add ( medievalAxeGO );
        treasureItems.Add ( hellWailerGO );
        treasureItems.Add ( bluePotionGO );
        treasureItems.Add ( redPotionGO );
        treasureItems.Add ( gutterSwordGO );
        treasureChestAnim = GetComponent<Animator> ( );
        //treasureRandomNumber = Mathf.RoundToInt ( Random.Range ( 0 , treasureItems.Count ) );
        treasureRandomNumber = 11;
        Debug.Log ( "Random Treasure Number: " + treasureRandomNumber );

    }

    // Update is called once per frame
    private void Update ( )
    {
        if ( Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);

            if ( Physics.Raycast ( touch.position , Vector3.forward , out hit ) )
            {
                if ( touch.phase == TouchPhase.Began )
                {
                    treasureChestAnim.SetBool ( "chestOpen" , true );

                    if ( treasureChestAnim.GetCurrentAnimatorStateInfo ( 0 ).IsName ( "open" ) && treasureChestAnim.GetBool ( "chestOpen" ) )
                    {

                        switch ( treasureRandomNumber )
                        {
                            case 0:
                                {
                                    blueDiamond = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    blueDiamond.transform.localScale = new Vector3 ( 0.1f , 0.1f , 0.1f );
                                    blueDiamond.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( blueDiamond );

                                    break;
                                }
                            case 1:
                                {
                                    orangeDiamond = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    orangeDiamond.transform.localScale = new Vector3 ( 0.1f , 0.1f , 0.1f );
                                    orangeDiamond.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( orangeDiamond );
                                    break;
                                }
                            case 2:
                                {
                                    redDiamond = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    redDiamond.transform.localScale = new Vector3 ( 0.1f , 0.1f , 0.1f );
                                    redDiamond.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( redDiamond );
                                    break;
                                }
                            case 3:
                                {
                                    silverDiamond = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    silverDiamond.transform.localScale = new Vector3 ( 0.1f , 0.1f , 0.1f );
                                    silverDiamond.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( silverDiamond );
                                    break;
                                }
                            case 4:
                                {
                                    purpleDiamond = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    purpleDiamond.transform.localScale = new Vector3 ( 0.1f , 0.1f , 0.1f );
                                    purpleDiamond.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( purpleDiamond );
                                    break;
                                }
                            case 5:
                                {
                                    yellowDiamond = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    yellowDiamond.transform.localScale = new Vector3 ( 0.1f , 0.1f , 0.1f );
                                    yellowDiamond.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( yellowDiamond );
                                    break;
                                }
                            case 6:
                                {
                                    coinBag = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    coinBag.transform.localScale = new Vector3 ( 0.5f , 0.5f , 0.5f );
                                    coinBag.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( coinBag );
                                    break;
                                }
                            case 7:
                                {
                                    medievalAxe = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    medievalAxe.transform.localScale = new Vector3 ( 0.01f , 0.01f , 0.01f );
                                    medievalAxe.transform.position = new Vector3 ( transform.position.x - 2.0f , 1.5f , transform.position.z );
                                    medievalAxe.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( medievalAxe );

                                    break;
                                }
                            case 8:
                                {
                                    hellWailer = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    hellWailer.transform.localScale = new Vector3 ( 1f , 1f , 1f );
                                    hellWailer.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( hellWailer );

                                    break;
                                }
                            case 9:
                                {
                                    bluePotion = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    bluePotion.transform.localScale = new Vector3 ( 1f , 1f , 1f );
                                    bluePotion.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( bluePotion );

                                    break;
                                }
                            case 10:
                                {
                                    redPotion = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    redPotion.transform.localScale = new Vector3 ( 1f , 1f , 1f );
                                    redPotion.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( redPotion );
                                    break;
                                }
                            case 11:
                                {
                                    gutterSword = SpawnTreasure ( treasureItems , treasureRandomNumber );
                                    gutterSword.transform.localScale = new Vector3 ( 0.01f , 0.01f , 0.01f );
                                    gutterSword.SetActive ( true );
                                    treasureChestAnim.SetBool ( "chestOpen" , false );
                                    LevitateTreasure ( gutterSword );

                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }
        }

    }

    private void LevitateTreasure ( GameObject treasure )
    {
        Vector3 levitatedPosition =  treasure.transform.position + new Vector3(0,2f,0);
        treasure.transform.position = Vector3.Lerp ( treasure.transform.position , levitatedPosition , speed * Time.deltaTime );
    }

    private GameObject SpawnTreasure ( List<GameObject> treasureItems , int treasureRandomNumber )
    {
        GameObject tempTreasure = null;

        if ( treasureItems [ treasureRandomNumber ] != null )
        {
            Destroy ( treasureItems [ treasureRandomNumber ] , 2f );
        }

        tempTreasure = Instantiate ( treasureItems [ treasureRandomNumber ] , transform.position , Quaternion.identity ) as GameObject;

        return tempTreasure;
    }
}