using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour {

    Animator doorAnim;
	// Use this for initialization
	void Start () {
        doorAnim = GetComponent<Animator>();
		
	}
	
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("isOpen", true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("isOpen", false);
        }

    }
}
