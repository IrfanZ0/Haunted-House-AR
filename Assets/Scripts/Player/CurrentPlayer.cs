using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using UnityEngine.SceneManagement;


public class CurrentPlayer : MonoBehaviour, IDataCollect
{
    string xmlPath;
    FileStream fs;
    XmlReader xReader;
    XmlDocument xDoc;
    Text statusText;
    Slider currentPlayerLoadBar;
    Text first_name;
    Text last_name;
    string full_name;
    public static float current_health;
    public static float current_magic;
    public static int current_money;
    public static int current_diamond;
    public MainHallController mHallController;
    


    private void Start()
    {
        xmlPath = Path.Combine(Application.dataPath, "ExternalDocs//playerdata.xml");

        fs = new FileStream(xmlPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        xReader = XmlReader.Create(fs);
        xDoc = new XmlDocument();
        xDoc.Load(xReader);
        xDoc.PreserveWhitespace = false;
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.ConformanceLevel = ConformanceLevel.Auto;
        settings.Indent = true;

        statusText = transform.Find("Status").GetComponent<Text>();
        currentPlayerLoadBar = transform.Find("Load Progress Bar").GetComponent<Slider>();
        first_name = transform.Find("InputField_Current_First_Name").transform.Find("Text").GetComponent<Text>();
        last_name = transform.Find("InputField_Current_Last_Name").transform.Find("Text").GetComponent<Text>();
    }                                                                    

    public void Load()
    {
        full_name = first_name.text + " " + last_name.text;

        if (CheckIfNameExists(full_name))
        {
            statusText.text = full_name + " exists!!!.";
            XmlNodeList playerNodeList = xDoc.GetElementsByTagName("Player");

                                                                                                                                                                                                                 
            foreach (XmlNode playerNode in playerNodeList)
            {
                if (playerNode.HasChildNodes)
                {
                    XmlNode nameNode = playerNode.ChildNodes[0];

                    if (nameNode.InnerText.Equals(full_name))
                    {
                        XmlNode sceneNode = playerNode.ChildNodes[5];
                       



                        switch (sceneNode.InnerText)
                        {
                            case "Boss Room":
                                {
                                                                       
                                    StartCoroutine(LoadPlayer("Boss Room", playerNode));
                                    break;
                                }

                            case "Graveyard":
                                {
                                    
                                    StartCoroutine(LoadPlayer("Graveyard", playerNode));
                                    break;
                                }

                            case "Kitchen":
                                {
                                    
                                    StartCoroutine(LoadPlayer("Kitchen", playerNode));
                                    break;
                                }

                            case "Large Dungeon":
                                {
                                   
                                    StartCoroutine(LoadPlayer("Large Dungeon", playerNode));
                                    break;
                                }

                            case "Main Hall":
                                {
                                    
                                    StartCoroutine(LoadPlayer("Main Hall", playerNode));
                                    break;
                                }

                            case "Small Dungeon":
                                {
                                   

                                    StartCoroutine(LoadPlayer("Small Dungeon", playerNode));
                                    break;
                                }

                            case "Weapon Shop":
                                {
                                    

                                    StartCoroutine(LoadPlayer("weapon Shop", playerNode));
                                    break;
                                }
                        }
                       
                    }
                }
            }
        }
    }
  
        
    public float GetMagicLevel(XmlNode playerNode)
    {
        float magic;

        magic = float.Parse(playerNode.ChildNodes[2].InnerText);
        return magic;

    }

   

    public float GetLifeLevel(XmlNode playerNode)
    {
        float life;
        life = float.Parse(playerNode.ChildNodes[1].InnerText);
        return life;
    }

   

    public int GetCoins(XmlNode playerNode)
    {
        int coins;
        coins = int.Parse(playerNode.ChildNodes[3].InnerText);
        return coins;
    }

   

    public int GetDiamonds(XmlNode playerNode)
    {
        int diamonds;
        diamonds = int.Parse(playerNode.ChildNodes[4].InnerText);
        return diamonds;
    }

    

    IEnumerator LoadPlayer(string scene_name, XmlNode player)
    {
        
        
        AsyncOperation aSyncOp = SceneManager.LoadSceneAsync(scene_name);
       

        aSyncOp.allowSceneActivation = false;

        while (!aSyncOp.isDone)
        {
            float sceneLoadProgress = aSyncOp.progress;
            currentPlayerLoadBar.value = sceneLoadProgress;

            if (sceneLoadProgress >= 0.9f)
            {
                aSyncOp.allowSceneActivation = true;
                current_health = GetLifeLevel(player);
                current_magic = GetMagicLevel(player);
                current_money = GetCoins(player);
                current_diamond = GetDiamonds(player);
            }

            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene_name));

                    
    }
               
        

    private bool CheckIfNameExists(string fullname)
    {
        bool exists = false;

        XmlNodeList xmlNodeList = xDoc.GetElementsByTagName("Name");

        foreach (XmlNode name in xmlNodeList)
        {
            string Name = name.InnerText;

            if (Name.Equals(fullname))
            {
                exists = true;
                
            }

            else
            {
                exists = false;
                statusText.text = Name + " does not exists.";
            }
        }


        return exists;

    }

    
}
