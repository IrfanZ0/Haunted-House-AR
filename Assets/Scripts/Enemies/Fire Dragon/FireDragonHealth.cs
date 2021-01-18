using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireDragonHealth : MonoBehaviour
{
    Slider lifeSlider;
    Animator fireDragonAnim;

    // Use this for initialization
    void Start()
    {
        lifeSlider = gameObject.GetComponentInChildren<Slider>();
        fireDragonAnim = gameObject.GetComponent<Animator>();


    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Bullets"))
        {
            Damage(1f);

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

    public void Damage(float damage)
    {
        lifeSlider.value -= 3f;
        fireDragonAnim.SetTrigger("Damage");

        if (lifeSlider.value < 1f)
        {
            fireDragonAnim.SetBool("isDead", true);
            Destroy(gameObject, 2f);
        }

    }

}
