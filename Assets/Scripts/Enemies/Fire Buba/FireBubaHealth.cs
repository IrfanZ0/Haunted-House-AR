using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBubaHealth : MonoBehaviour
{
    private Slider lifeSlider;
    private Animator fireBubaAnim;
    private Image fill;
    private float current_health;
    private float total_health = 30f;
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
        fireBubaAnim = GetComponentInParent<Animator> ( );
        current_health = total_health;

    }

    public void Damage ( float damage )
    {
        current_health -= damage;

    }

    private void FireBubaDeath ( )
    {
        fireBubaAnim.SetBool ( "isDead" , true );
        float deathTime = fireBubaAnim.GetCurrentAnimatorStateInfo ( 0 ).length;
        Destroy ( gameObject , deathTime + 3f );
    }

    private void Update ( )
    {
        lifeSlider.value = current_health;

        if ( lifeSlider.value <= 0 )
        {
            FireBubaDeath ( );

        }
    }

}