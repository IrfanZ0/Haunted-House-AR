using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot1Talk : MonoBehaviour
{
    Text robo1TalkBox;
    Animator robo1Anim;
    ToggleGroup tGroup;
    Toggle tDeployDrones;
    Toggle tPurchaseNewWeapons;
    Toggle tAskForHelp;
    GameObject robo1Panel;
    Transform eyes;
    float maxDistance;
    RaycastHit hit;


    private void Start()
    {
        eyes = GameObject.Find("Robo1").transform.Find("Body_joint").transform.Find("Ribs").transform.Find("Eye_joint");
        maxDistance = 50f;
    }


    private void Update()
    {
        if (Physics.Raycast(eyes.position, transform.forward, out hit, maxDistance))
        {

            if (hit.collider.CompareTag("Player"))
            {
                robo1Anim = hit.collider.GetComponent<Animator>();
                robo1Anim.SetBool("Speak", true);
                robo1Panel = hit.collider.gameObject.transform.Find("Canvas").transform.Find("Panel").gameObject;
                robo1TalkBox = robo1Panel.transform.Find("robo1Says").GetComponent<Text>();
                StartCoroutine(Greeting(robo1TalkBox));
                StartCoroutine(ProvideOptions(robo1TalkBox, robo1Panel));


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
