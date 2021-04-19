using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour
{
    private Animator swordAnim;

    // Start is called before the first frame update
    private void Start ( )
    {
        swordAnim = GetComponent<Animator> ( );
        StartCoroutine ( WaitForIdleState ( ) );
        StartCoroutine ( WaitForStationaryState ( ) );
    }

    private IEnumerator WaitForIdleState ( )
    {
        yield return new WaitForSeconds ( 20f );
        swordAnim.SetBool ( "Sword_Stationary" , false );

    }

    private IEnumerator WaitForStationaryState ( )
    {
        yield return new WaitForSeconds ( 10f );
        swordAnim.SetBool ( "Sword_Stationary" , true );

    }

    public void ForwardJab ( )
    {
        swordAnim.SetTrigger ( "Sword_Jab" );
    }

    public void Slash ( )
    {
        swordAnim.SetTrigger ( "Sword_Slash" );
    }
}