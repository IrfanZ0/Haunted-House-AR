using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

    public int pooledAmount = 10;
    public GameObject bullet;
    List<GameObject> bullets;
    

	// Use this for initialization
	void Start () {
      

        bullets = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject bulletGO = Instantiate(bullet) as GameObject;
            bulletGO.transform.SetParent ( gameObject.transform , false );
            bullet.transform.localPosition = Vector3.zero;
            bulletGO.transform.localRotation = Quaternion.Euler(-180f, 0, 0);

            bulletGO.SetActive(true);
            bullets.Add(bulletGO);
        }

       
      

    }
	
	public void Reload()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullets");
        foreach(GameObject bullet in bullets)
        {
            bullet.SetActive ( false );
            bullet.transform.localPosition = transform.localPosition;
        }

       
    }

    IEnumerator HideBullets()
    {
        yield return new WaitForSeconds ( 1f );

        for ( int i = 0 ; i < bullets.Count ; i++ )
        {
            if (bullets[i].activeInHierarchy)
            {
                bullets [ i ].SetActive ( false );
            }
            
        }
    }

	public void Fire ()
    {
        for (int j = 0; j < bullets.Count; j++)
        {
            if (!bullets[j].activeInHierarchy)
            {
                bullets[j].transform.localPosition = transform.localPosition;
               // bullets[j].transform.rotation = Quaternion.Euler(90f, 90f, 0);
                bullets[j].SetActive(true);
               
               
                break;
            }
        }

        StartCoroutine ( HideBullets ( ) );

    }

    private void Update ( )
    {
       
    }
}
