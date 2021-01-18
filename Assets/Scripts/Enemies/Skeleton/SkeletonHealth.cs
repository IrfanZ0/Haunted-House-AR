
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealth : MonoBehaviour {

    Slider skeletonHealthBar;
    float total_health = 75f;
    float current_health;
    Animator skeletonAnim;
    public GameObject explosion;
    AudioSource bulletExplosionSound;
    ParticleSystem bulletPS;
   

	// Use this for initialization
	void Start () {
        current_health = total_health;
        skeletonHealthBar = transform.Find("Canvas").transform.Find("Health Bar").GetComponent<Slider>();
        
       
        skeletonAnim = GetComponent<Animator>();
        bulletPS = explosion.GetComponentInChildren<ParticleSystem>();
        bulletExplosionSound = explosion.GetComponent<AudioSource>();
      
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Bullets"))
        {
            Damage(1f);
            StartCoroutine(HideBullets ( coll.gameObject ));
           

        }

        if (coll.collider.CompareTag("Magic Sword"))
        {
            Damage(1f);

        }

        if (coll.collider.CompareTag("Lightning Bolt"))
        {
            Damage(3f);

        }
    }

    private void OnCollisionExit ( Collision collision )
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            skeletonAnim.SetTrigger ( "Damage" );
        }
    }

    public void Damage(float damage)
    {
        current_health -= damage;
       
        if (skeletonHealthBar.value < 1f)
        {
            skeletonAnim.SetBool("isDead", true);
            Destroy(gameObject, 2f);
        }

    }

    IEnumerator HideBullets(GameObject bullet)
    {
        bullet.SetActive ( false );
        yield return new WaitForSeconds ( 4f );
    }

    private void Update ( )
    {
       skeletonHealthBar.value = current_health;
         
    }

}
