using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpener : MonoBehaviour {

    Animator leftGateAnim;
    Animator rightGateAnim;

    // Use this for initialization
    void Start()
    {
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.name == "door3")
            {
                rightGateAnim = child.GetComponent<Animator>();
            }

            if (child.name == "door3 1")
            {
                leftGateAnim = child.GetComponent<Animator>();
            }
        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leftGateAnim.SetBool("isOpen", true);
            rightGateAnim.SetBool("isOpen", true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            leftGateAnim.SetBool("isOpen", false);
            rightGateAnim.SetBool("isOpen", false);
        }

    }
}
