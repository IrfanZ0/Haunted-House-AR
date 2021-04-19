using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonHealth : MonoBehaviour
{
    private Slider lifeSlider;
    private Image fill;
    private Animator demonLordAnim;
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
        demonLordAnim = GetComponentInParent<Animator> ( );
        current_health = total_health;
        prizesList = new GameObject [ ] { blueDiamond , orangeDiamond , redDiamond , silverDiamond , violetDiamond , yellowDiamond , coinBag , treasureChest };
        prizeNum = Mathf.RoundToInt ( UnityEngine.Random.Range ( 0 , prizesList.Length ) );
        selectedPrize = DemonLordPrize ( prizesList , prizeNum ) as GameObject;
        selectedPrize.transform.parent = transform.root;
        selectedPrize.SetActive ( false );

    }

    private void Update ( )
    {
        lifeSlider.value = current_health;

    }

    private GameObject DemonLordPrize ( GameObject [ ] prizes , int numPrize )
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

    public void Damage ( float damage )
    {
        current_health -= damage;

        if ( current_health <= 0 && transform.root.gameObject != null )
        {

            DemonLordDeathAndRespawn ( );
            selectedPrize.transform.parent = null;
            selectedPrize.SetActive ( true );

        }

    }

    private void DemonLordDeathAndRespawn ( )
    {
        Vector3 currentPosition = transform.position;
        demonLordAnim.SetTrigger ( "Demon_Lord_Death" );
        float demonLordDeathTime = demonLordAnim.GetCurrentAnimatorClipInfo ( 0 )[0].clip.length;

        //Destroy ( transform.root.gameObject , demonLordDeathTime + 5f );

        //transform.root.gameObject.SetActive ( false );
        //transform.root.gameObject.transform.position = currentPosition;
        //yield return new WaitForSeconds ( 3f );
        //demonLordAnim.SetBool ( "Demon_Lord_Respawn" , true );
        //transform.root.gameObject.SetActive ( true );

    }

}