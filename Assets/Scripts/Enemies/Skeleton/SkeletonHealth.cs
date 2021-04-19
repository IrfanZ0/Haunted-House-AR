using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealth : MonoBehaviour
{

    private Slider lifeSlider;
    private float total_health = 50f;
    private float current_health;
    private Animator skeletonAnim;
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
        current_health = total_health;
        lifeSlider = GetComponent<Slider> ( );
        skeletonAnim = GetComponentInParent<Animator> ( );
        prizesList = new GameObject [ ] { blueDiamond , orangeDiamond , redDiamond , silverDiamond , violetDiamond , yellowDiamond , coinBag , treasureChest };
        prizeNum = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , prizesList.Length ) );
        selectedPrize = SkeletonPrize ( prizesList , prizeNum ) as GameObject;
        selectedPrize.transform.parent = transform.root;
        selectedPrize.SetActive ( false );
    }

    public void Damage ( float damage )
    {
        current_health -= damage;

        if ( current_health <= 0 )
        {
            SkeletonDeath ( );
            selectedPrize.transform.parent = null;
            selectedPrize.SetActive ( true );

        }
    }

    private void SkeletonDeath ( )
    {
        float skeletonDeathTime = skeletonAnim.GetCurrentAnimatorClipInfo ( 0) [0].clip.length;
        Destroy ( transform.root.gameObject , skeletonDeathTime );
        skeletonAnim.SetBool ( "isDead_Skeleton" , true );
    }

    private void Update ( )
    {
        lifeSlider.value = current_health;

    }

    private GameObject SkeletonPrize ( GameObject [ ] prizes , int numPrize )
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