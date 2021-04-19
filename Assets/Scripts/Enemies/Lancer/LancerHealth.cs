using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LancerHealth : MonoBehaviour
{
    private Slider lifeSlider;
    private Animator lancerAnim;
    public GameObject magicSword;
    private float total_health = 100f;
    private float current_health;
    private Image fill;
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
        current_health = total_health;
        lancerAnim = GetComponentInParent<Animator> ( );
        prizesList = new GameObject [ ] { blueDiamond , orangeDiamond , redDiamond , silverDiamond , violetDiamond , yellowDiamond , coinBag , treasureChest };
        prizeNum = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , prizesList.Length ) );
        selectedPrize = LancerPrize ( prizesList , prizeNum ) as GameObject;
        selectedPrize.transform.parent = transform.root;
        selectedPrize.SetActive ( false );

    }

    public void TakeDamage ( float damage )
    {
        current_health -= damage;

        if ( current_health <= 0 )
        {
            LancerDeath ( );
            selectedPrize.transform.parent = null;
            selectedPrize.SetActive ( true );

        }
    }

    private void LancerDeath ( )
    {
        float lancerDeathTime = lancerAnim.GetCurrentAnimatorClipInfo ( 0 )[0].clip.length;
        Destroy ( transform.root.gameObject , lancerDeathTime + 2f );
        lancerAnim.SetTrigger ( "Dead_Lancer" );
    }

    private void Update ( )
    {
        lifeSlider.value = current_health;
    }

    private GameObject LancerPrize ( GameObject [ ] prizes , int numPrize )
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