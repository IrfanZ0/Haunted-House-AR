using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderHealth : MonoBehaviour
{
    private Slider lifeSlider;
    private Animator spiderAnim;
    private float total_health = 50f;
    private float current_health;
    public GameObject blueDiamond;
    public GameObject orangeDiamond;
    public GameObject redDiamond;
    public GameObject silverDiamond;
    public GameObject violetDiamond;
    public GameObject yellowDiamond;
    public GameObject coinBag;
    public GameObject treasureChest;
    private GameObject[] prizesList;
    private GameObject prize;
    private int prizeNum;
    private GameObject selectedPrize;

    // Use this for initialization
    private void Start ( )
    {
        lifeSlider = GetComponent<Slider> ( );
        current_health = total_health;
        spiderAnim = GetComponentInParent<Animator> ( );
        prizesList = new GameObject [ ] { blueDiamond , orangeDiamond , redDiamond , silverDiamond , violetDiamond , yellowDiamond , coinBag , treasureChest };
        prizeNum = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , prizesList.Length ) );
        selectedPrize = SpiderPrize ( prizesList , prizeNum ) as GameObject;
        selectedPrize.transform.parent = transform.root;
        selectedPrize.SetActive ( false );

    }

    public void Damage ( float damage )
    {
        current_health -= damage;

        if ( current_health <= 0 )
        {
            SpiderDeath ( );
            selectedPrize.transform.parent = null;
            selectedPrize.SetActive ( true );

        }
    }

    private void SpiderDeath ( )
    {
        float deathTime = spiderAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Destroy ( transform.root.gameObject , deathTime + 2f );
        spiderAnim.SetBool ( "spiderDead" , true );
    }

    private GameObject SpiderPrize ( GameObject [ ] prizes , int numPrize )
    {
        GameObject prizeTemp = null;

        for ( int i = 0 ; i < prizes.Length ; i++ )
        {
            if ( i == numPrize )
            {
                prizeTemp = Instantiate ( prizes [ i ] , transform.position , Quaternion.identity , transform.root ) as GameObject;
            }

        }

        return prizeTemp;
    }

    private void Update ( )
    {
        lifeSlider.value = current_health;

    }
}