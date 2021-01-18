using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class ChoicesManager : MonoBehaviour
{
    ToggleGroup tGroup;
    RobotKyleTalk kyleTalk;
    public GameObject airDroneGO;
    GameObject airDrone;
    public GameObject landDroneGO;
    GameObject landDrone;
    public GameObject attackDroneGO;
    GameObject attackDrone;
    Transform kyleTransform;
    GameObject choicesCanvas;


    // Start is called before the first frame update
    void Start()
    {
        tGroup = GetComponent<ToggleGroup>();
        kyleTalk = GameObject.Find("Robot Kyle").GetComponent<RobotKyleTalk>();
        kyleTransform = GameObject.Find("Robot Kyle").transform;
        choicesCanvas = GameObject.Find("Choices Canvas");
        choicesCanvas.transform.position = new Vector3(kyleTransform.position.x, kyleTransform.position.y + 2f, kyleTransform.position.z);
        choicesCanvas.transform.localScale = new Vector3(0.005f, 0.003f, 0.005f);
     
    }

   

    public void DeployDroids()
    {
        kyleTalk.anim_Dispatch();
        StartCoroutine(Deploy());
       
    }

    public void PurchaseNewWeapons()
    {
        kyleTalk.anim_Speak();
        kyleTalk.kyleTalkBox.text = "So, you would like to purchase new weapons?  Let's warp to the weapon store ...";
        SceneManager.LoadScene("Weapon Shop", LoadSceneMode.Single);
    }

    public void AskForHelp()
    {
        kyleTalk.anim_Speak();
        kyleTalk.kyleTalkBox.text = "Your wish is my command.  How may I serve you today?";
    }

    IEnumerator Deploy()
    {
        kyleTalk.anim_Speak();
        kyleTalk.kyleTalkBox.text = "";
        kyleTalk.kyleTalkBox.text = "Deploying Droids now ...";
        yield return new WaitForSeconds(2f);
        airDrone = Instantiate(airDroneGO, transform.position, transform.rotation) as GameObject;
        landDrone = Instantiate(landDroneGO, transform.position, transform.rotation) as GameObject;
        attackDrone = Instantiate(attackDroneGO, transform.position, transform.rotation) as GameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (tGroup.AnyTogglesOn())
        {
           IEnumerable<Toggle> activeToggles =  tGroup.ActiveToggles();

            Toggle selectedToggle = activeToggles.FirstOrDefault<Toggle>();
            
                

            if (selectedToggle.name.Equals("Deploy Droids"))
            {
               


            }

            else if (selectedToggle.name.Equals("Purchase New Weapons"))
            {
               
            }

            else if (selectedToggle.name.Equals("Ask For Help"))
            {
                
            }

            else
            {
                
            }
            

           
        }
        
    }
}
