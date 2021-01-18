using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot2Talk : MonoBehaviour
{
    Text robo2TalkBox;
    Animator robo2Anim;
    ToggleGroup tGroup;
    Toggle tDeployDrones;
    Toggle tPurchaseNewWeapons;
    Toggle tAskForHelp;
    GameObject robo2Panel;
    Transform eyes;
    float maxDistance;
    RaycastHit hit;


    private void Start()
    {
        eyes = GameObject.Find("Robo2").transform.Find("Body_joint").transform.Find("Ribs").transform.Find("Eye_joint");
        maxDistance = 50f;
    }


    private void Update()
    {
        if (Physics.Raycast(eyes.position, transform.forward, out hit, maxDistance))
        {

            if (hit.collider.CompareTag("Player"))
            {
                Debug.DrawRay(hit.collider.transform.position, transform.forward, Color.red);
                robo2Anim = hit.collider.GetComponent<Animator>();
                robo2Anim.SetBool("Speak", true);
                robo2Panel = hit.collider.gameObject.transform.Find("Canvas").transform.Find("Panel").gameObject;
                robo2TalkBox = robo2Panel.transform.Find("robo2Says").GetComponent<Text>();
                StartCoroutine(Greeting(robo2TalkBox));
                StartCoroutine(ProvideOptions(robo2TalkBox, robo2Panel));


            }
        }
    }

   

    IEnumerator Greeting(Text robotTalk)
    {
        robotTalk.text = "Greetings my friend.  Are you in need of my assistane? ";
        yield return new WaitForSeconds(2f);
    }

    IEnumerator ProvideOptions(Text robotTalk, GameObject panel)
    {
        robotTalk.text = "Here are a few things that I can help you with";
        yield return new WaitForSeconds(2f);
        tGroup = panel.AddComponent<ToggleGroup>();
        tGroup.RegisterToggle(tDeployDrones);
        tGroup.RegisterToggle(tPurchaseNewWeapons);
        tGroup.RegisterToggle(tAskForHelp);



    }
}
