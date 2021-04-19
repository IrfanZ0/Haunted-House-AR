using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceBubaHealth : MonoBehaviour
{
    private Slider lifeSlider;
    private Animator iBubaAnim;
    private Image fill;
    private float current_health;
    private float total_health = 75f;
    public GameObject[] prizesList;
    private int prizeNum;
    private GameObject selectedPrize;
    public GameObject blueDiamond;
    public GameObject orangeDiamond;
    public GameObject redDiamond;
    public GameObject silverDiamond;
    public GameObject violetDiamond;
    public GameObject yellowDiamond;
    public GameObject coinBag;
    public GameObject treasureChest;

    // Use this for initialization
    private void Start ( )
    {
        lifeSlider = GetComponent<Slider> ( );
        iBubaAnim = GetComponentInParent<Animator> ( );
        current_health = total_health;
        prizesList = new GameObject [ ] { blueDiamond , orangeDiamond , redDiamond , silverDiamond , violetDiamond , yellowDiamond , coinBag , treasureChest };
        prizeNum = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , prizesList.Length ) );
        selectedPrize = IceBubaPrize ( prizesList , prizeNum ) as GameObject;
        selectedPrize.transform.parent = transform.root;
        selectedPrize.SetActive ( false );

    }

    public void Damage ( float damage )
    {
        current_health -= damage;

        if ( current_health <= 0 )
        {
            IceBubaDeath ( );
            selectedPrize.transform.parent = null;
            selectedPrize.SetActive ( true );

        }
    }

    private void IceBubaDeath ( )
    {
        float iceBubaDeathTime = iBubaAnim.GetCurrentAnimatorClipInfo ( 0 )[0].clip.length;
        Destroy ( transform.root.gameObject , iceBubaDeathTime + 2f );
        iBubaAnim.SetBool ( "isDead" , true );
    }

    private void Update ( )
    {
        lifeSlider.value = current_health;
    }

    private GameObject IceBubaPrize ( GameObject [ ] prizes , int numPrize )
    {
        GameObject prizeTemp = null;

        for ( int i = 0 ; i < prizes.Length ; i++ )
        {
            if ( i == numPrize )
            {
                prizeTemp = Instantiate ( prizes [ i ] , transform.position , Quaternion.identity ) as GameObject;
            }

        }

        return prizeTemp;
    }

}