using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponFireController : MonoBehaviour
{
    Button fireButton;
    BulletFire bulletFire;
    GameObject player;
    List<GameObject> gunList;

    // Start is called before the first frame update
    void Start()
    {
        fireButton = GetComponent<Button> ( );
        gunList = new List<GameObject> ( );

        player = GameObject.FindGameObjectWithTag ( "Player" );

        foreach ( var child in player.GetComponentsInChildren<Transform>() )
        {
            if (child.gameObject.CompareTag("Gun"))
            {
                gunList.Add ( child.gameObject );
            }
        }
       
        if (gunList != null)
        {

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
