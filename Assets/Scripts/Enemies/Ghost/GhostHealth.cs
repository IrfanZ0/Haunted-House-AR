using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GhostHealth : MonoBehaviour
{
    private Slider lifeSlider;
    private Animator ghostAnim;
    private Image fill;
    private float current_health;
    private float total_health = 50f;
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
        ghostAnim = gameObject.GetComponentInParent<Animator> ( );
        current_health = total_health;
        prizesList = new GameObject [ ] { blueDiamond , orangeDiamond , redDiamond , silverDiamond , violetDiamond , yellowDiamond , coinBag , treasureChest };
        prizeNum = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , prizesList.Length ) );
        selectedPrize = GhostPrize ( prizesList , prizeNum ) as GameObject;
        selectedPrize.transform.parent = transform.root;
        selectedPrize.SetActive ( false );

    }

    public void Damage ( float damage )
    {
        current_health -= damage;

        if ( current_health <= 0 )
        {
            GhostDeath ( );
            selectedPrize.transform.parent = null;
            selectedPrize.SetActive ( true );

        }

    }

    private void GhostDeath ( )
    {
        float ghostDeathTime = ghostAnim.GetCurrentAnimatorClipInfo ( 0 )[0].clip.length;
        Destroy ( transform.root.gameObject , ghostDeathTime + 2f );
        ghostAnim.SetBool ( "Dead_Ghost" , true );
    }

    private void Update ( )
    {
        lifeSlider.value = current_health;
    }

    private GameObject GhostPrize ( GameObject [ ] prizes , int numPrize )
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