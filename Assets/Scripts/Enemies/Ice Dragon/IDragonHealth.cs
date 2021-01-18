using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDragonHealth : MonoBehaviour
{
    Slider lifeSlider;
    Animator iceDragonAnim;

    // Use this for initialization
    void Start()
    {
        lifeSlider = gameObject.GetComponentInChildren<Slider>();
        iceDragonAnim = gameObject.GetComponent<Animator>();


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
        lifeSlider.value -= damage;
        iceDragonAnim.SetTrigger("Damage");

        if (lifeSlider.value < 1f)
        {
            iceDragonAnim.SetBool("isDead", true);
            Destroy(gameObject, 2f);
        }

    }
}
