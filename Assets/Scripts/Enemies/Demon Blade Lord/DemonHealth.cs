using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonHealth : MonoBehaviour
{
    Slider lifeSlider;
    Animator demonLordAnim;

    // Use this for initialization
    void Start()
    {
        lifeSlider = gameObject.GetComponentInChildren<Slider>();
        demonLordAnim = gameObject.GetComponent<Animator>();


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
        demonLordAnim.SetTrigger("Damage");

        if (lifeSlider.value < 1f)
        {
            demonLordAnim.SetBool("isDead", true);
            Destroy(gameObject, 2f);
        }

    }

}

