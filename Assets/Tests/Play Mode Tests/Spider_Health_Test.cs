using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spider_Health_Test : MonoBehaviour
{
    private Slider lifeSlider;
    private Animator spiderAnim;
    private float total_health = 50f;
    private float current_health;
    public GameObject explosionGO;
    private ParticleSystem fireShrapnelPS;
    public GameObject[] prizes;
    private GameObject prize;

    // Use this for initialization
    private void Start ( )
    {
        prizes = new GameObject [ 5 ];
        lifeSlider = transform.Find ( "Canvas" ).transform.Find ( "Health Bar" ).GetComponent<Slider> ( );
        current_health = total_health;
        spiderAnim = GetComponent<Animator> ( );

    }

    private void OnCollisionEnter ( Collision coll )
    {
        if ( coll.gameObject.CompareTag ( "Bullets" ) )
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

    private void OnCollisionExit ( Collision collision )
    {
        if ( collision.gameObject.CompareTag ( "Bullets" ) )
        {
            spiderAnim.SetTrigger ( "spiderHit" );
        }
    }

    public void Damage ( float damage )
    {
        current_health -= damage;

    }

    public float GetCurrentHealth ( )
    {
        return current_health;
    }

    private void Update ( )
    {
        lifeSlider.value = current_health;

        if ( lifeSlider.value < 1f )
        {
            spiderAnim.SetBool ( "isDead" , true );
            Destroy ( gameObject , 2f );
            if ( gameObject == null )
            {
                int prizeNum = Mathf.RoundToInt(Random.Range(0, 5));

                if ( GotPrize ( prizes , prizeNum ) == false )
                {
                    prize = Instantiate ( prizes [ prizeNum ] , transform.position , transform.rotation ) as GameObject;
                    prize.SetActive ( true );
                }
            }

        }
    }

    private bool GotPrize ( GameObject [ ] prizeList , int prizeNum )
    {
        if ( prizeList [ prizeNum ].activeInHierarchy && prizeList [ prizeNum ].activeSelf )
            return true;
        else return false;
    }
}