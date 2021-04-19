using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningBubaHealth : MonoBehaviour
{
    private Slider lifeSlider;
    private Animator lBubaAnim;
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
        lifeSlider = gameObject.GetComponentInChildren<Slider> ( );
        fill = lifeSlider.transform.Find ( "Fill Area" ).transform.Find ( "Fill" ).GetComponent<Image> ( );
        lBubaAnim = gameObject.GetComponent<Animator> ( );
        current_health = total_health;

    }

    private void OnCollisionEnter ( Collision coll )
    {
        if ( coll.collider.CompareTag ( "Bullets" ) )
        {
            Damage ( 1f );

        }

        if ( coll.collider.CompareTag ( "Magic Sword" ) )
        {
            Damage ( 1f );

        }

        if ( coll.collider.CompareTag ( "Lightning Bolt" ) )
        {
            Damage ( 3f );

        }
    }

    public void Damage ( float damage )
    {
        current_health -= damage;

        fill.fillAmount = current_health / total_health;

        if ( fill.fillAmount == 0 )
        {
            StartCoroutine ( LightningBubaDeath ( ) );

        }

    }

    private IEnumerator LightningBubaDeath ( )
    {
        lBubaAnim.SetBool ( "isDead" , true );
        yield return new WaitForSeconds ( lBubaAnim.GetCurrentAnimatorStateInfo ( 0 ).length );
        Destroy ( gameObject , 2f );
    }

}