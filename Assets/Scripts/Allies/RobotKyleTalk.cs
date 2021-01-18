using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotKyleTalk : MonoBehaviour
{
    
    Animator kyleAnim;
    ToggleGroup togGroup;
    Toggle tDeployDrones;
    Toggle tPurchaseNewWeapons;
    Toggle tAskForHelp;
    Transform eyes;
    float maxDistance;
    RaycastHit hit;

    [HideInInspector]
    public Text kyleTalkBox;
    public GameObject kylePanel;
    public GameObject choicesPanel;

    private void Start()
    {
        eyes = GameObject.Find("Robot Kyle").transform.Find("Root").transform.Find("Ribs").transform.Find("Neck").transform.Find("Head").transform.Find("Eyes");
        maxDistance = 50f;
        kyleAnim = GetComponent<Animator>();
        kylePanel = transform.Find("Canvas").transform.Find("Panel").gameObject;
        kylePanel.gameObject.SetActive(false);
        choicesPanel = GameObject.Find("Robot Kyle").transform.Find("Canvas").transform.Find("Choices Panel").gameObject;
        choicesPanel.gameObject.SetActive(false);

    }


    private void Update()
    {
        if (Physics.Raycast(eyes.position, transform.forward, out hit, maxDistance))
        {
            Debug.DrawRay(eyes.position, transform.forward, Color.red);

            if (hit.collider.CompareTag("Player"))
            {
                anim_Speak();
                
                kyleTalkBox = kylePanel.transform.Find("KyleSays").GetComponent<Text>();
                StartCoroutine(Greeting(kyleTalkBox));
            }

            

           
        }
    }
    
    public void anim_Dispatch()
    {
        kyleAnim.SetTrigger("Dispatch");
    }
    public void anim_Idle()
    {
        kyleAnim.SetBool("Speak", false);
       
    }
    public void anim_Speak()
    {
        kyleAnim.SetBool("Speak", true);
        kylePanel.gameObject.SetActive(true);
     
    }
    IEnumerator Greeting(Text robotTalk)
    {
        kylePanel.gameObject.SetActive(true);
        robotTalk.text = "Greetings my friend.  Are you in need of my assistane? ";
        yield return new WaitForSeconds(5f);
        kylePanel.gameObject.SetActive(false);
        StartCoroutine(ProvideOptions(kyleTalkBox, kylePanel));
    }

    IEnumerator ProvideOptions(Text robotTalk, GameObject panel)
    {
        kylePanel.gameObject.SetActive(true);
        robotTalk.text = "Here are a few things that I can help you with";
        yield return new WaitForSeconds(5f);
        kylePanel.gameObject.SetActive(false);
        choicesPanel.gameObject.SetActive(true);
              
        
    }

   
}
