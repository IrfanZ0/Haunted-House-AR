using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGateOpener : MonoBehaviour {

    
    Animator rightGateAnim;

    // Use this for initialization
    void Start()
    {
        
        rightGateAnim = GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            rightGateAnim.SetBool("isOpen", true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            rightGateAnim.SetBool("isOpen", false);
        }

    }
}
