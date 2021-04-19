using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private float forceFactor;

    // Start is called before the first frame update
    private void Start ( )
    {
        forceFactor = 5f;

    }

    private void OnTriggerEnter ( Collider other )
    {
        if ( other.CompareTag ( "Ghost" ) )
        {
            GameObject ghost = other.gameObject;
            ghost.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
            ghost.GetComponentInChildren<GhostHealth> ( ).Damage ( 2f );

        }

        if ( other.CompareTag ( "Skeleton" ) )
        {
            GameObject skeleton = other.gameObject;
            skeleton.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
            skeleton.GetComponentInChildren<SkeletonHealth> ( ).Damage ( 5f );
        }

        if ( other.CompareTag ( "Buba" ) )
        {
            GameObject bubaGO = other.gameObject;

            if ( bubaGO.name == "Fire Buba" )
            {
                bubaGO.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
                bubaGO.GetComponentInChildren<FireBubaHealth> ( ).Damage ( 4f );
            }

            if ( bubaGO.name == "Ice Buba" )
            {
                bubaGO.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
                bubaGO.GetComponentInChildren<IceBubaHealth> ( ).Damage ( 8f );
            }

            if ( bubaGO.name == "Lightning Buba" )
            {
                bubaGO.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
                bubaGO.GetComponentInChildren<LightningBubaHealth> ( ).Damage ( 3f );
            }

        }

        if ( other.CompareTag ( "Demon" ) )
        {
            GameObject demonLord = other.gameObject;
            demonLord.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
            demonLord.GetComponentInChildren<DemonHealth> ( ).Damage ( 8f );
        }

        if ( other.CompareTag ( "Dragon" ) )
        {
            GameObject dragonGO = other.gameObject;

            if ( dragonGO.name == "Baby Fire Dragon" )
            {
                dragonGO.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
                dragonGO.GetComponentInChildren<FireDragonHealth> ( ).Damage ( 2f );
            }

            if ( dragonGO.name == "Baby Ice Dragon" )
            {
                dragonGO.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
                dragonGO.GetComponentInChildren<GhostHealth> ( ).Damage ( 2f );
            }

        }

        if ( other.CompareTag ( "Lancer" ) )
        {
            GameObject ghost = other.gameObject;
            ghost.GetComponent<Rigidbody> ( ).AddForce ( forceFactor * Vector3.back );
            ghost.GetComponentInChildren<LancerHealth> ( ).TakeDamage ( 7f );
        }

        if ( other.CompareTag ( "Player" ) )
        {
            PlayerHealth pHealth = GameObject.FindGameObjectWithTag("Player Life").transform.Find("Player Health Bar").GetComponent<PlayerHealth>();
            pHealth.Damage ( 3f );
            StartCoroutine ( ShowBlood ( ) );
        }
    }

    private IEnumerator ShowBlood ( )
    {
        GameObject blood = GameObject.FindGameObjectWithTag("Player").transform.Find("AR Camera").transform.Find("blood1").gameObject;

        blood.SetActive ( true );
        yield return new WaitForSeconds ( 3f );
        blood.SetActive ( false );
    }
}