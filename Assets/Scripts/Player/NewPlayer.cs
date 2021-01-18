using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NewPlayer : MonoBehaviour
{
    XmlDocument xDoc;
    XmlReader xReader;
    XmlWriter xWriter;
    string xmlPath;
    Text first_name;
    Text last_name;
    Player player;
    Stats stats;
    XmlNode root;
    string fName;
    string lName;
    string full_name;
    float current_health;
    float current_magic;
    int current_money;
    int current_diamonds;
    FileStream fs;
    List<string> playerNames;
    Text statusText;
    Slider newPlayerLoadBar;
    string last_screen_name;





    void Awake()
    {
        xDoc = new XmlDocument();
        xmlPath = Path.Combine(Application.dataPath, "ExternalDocs//playerdata.xml");
        playerNames = new List<string>();

        statusText = transform.Find("Status").GetComponent<Text>();
        newPlayerLoadBar = transform.Find("Level Load Bar").GetComponent<Slider>();
        // xWriter.Close();
        // xWriter.Close();

        last_screen_name = "Main Hall";

        first_name = transform.Find("InputField_First_Name").transform.Find("Text").GetComponent<Text>();
        last_name = transform.Find("InputField_Last_Name").transform.Find("Text").GetComponent<Text>();

        

    }

   

    public void AddPlayer()
    {
        fName = first_name.text;
        lName = last_name.text;
        full_name = fName + " " + lName;
        current_health = 100f;
        current_magic = 100f;
        current_money = 0;
        current_diamonds = 0;
        playerNames.Add(full_name);

        //XmlNode ps = xDoc.DocumentElement.SelectSingleNode("HauntedHouse/Players").FirstChild;

        xReader = XmlReader.Create(fs);
        xDoc.Load(xReader);
       

        XmlElement rootNode = xDoc.DocumentElement;
        
     
        XmlElement playersElement = xDoc.CreateElement("Players");
        rootNode.AppendChild(playersElement);
        
        XmlElement playerElement = xDoc.CreateElement("Player");

        playersElement.AppendChild(playerElement);

        XmlElement nameElement = xDoc.CreateElement("Name");
        nameElement.InnerText = full_name;
        playerElement.AppendChild(nameElement);

        XmlElement healthElement = xDoc.CreateElement("Health");
        healthElement.InnerText = current_health.ToString();
        playerElement.AppendChild(healthElement);

        XmlElement magicElement = xDoc.CreateElement("Magic");
        magicElement.InnerText = current_magic.ToString();
        playerElement.AppendChild(magicElement);

        XmlElement moneyElement = xDoc.CreateElement("Money");
        moneyElement.InnerText = current_money.ToString();
        playerElement.AppendChild(moneyElement);

        XmlElement sceneElement = xDoc.CreateElement("Scene");
        sceneElement.InnerText = last_screen_name;
        playerElement.AppendChild(sceneElement);

        XmlElement diamondElement = xDoc.CreateElement("Diamond");
        diamondElement.InnerText = current_diamonds.ToString();
        playerElement.AppendChild(diamondElement);


        playersElement.AppendChild(playerElement);
        xDoc.DocumentElement.AppendChild(playersElement);

        xReader.Close();

        
        
        
    }

    public void SavePlayer ()
    {
        fs = new FileStream(xmlPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        xDoc.PreserveWhitespace = false;
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.ConformanceLevel = ConformanceLevel.Auto;
        settings.Indent = true;

        xWriter = XmlWriter.Create(fs, settings);

       

            xWriter.WriteStartDocument(true);


            xWriter.WriteStartElement("HauntedHouse");
            xWriter.WriteStartElement("Players");

        if (CheckIfNameExists(full_name) == false)
        {
            foreach (string name in playerNames)
            {
                xWriter.WriteStartElement("Player");

                xWriter.WriteStartElement("Name");
                xWriter.WriteString(name);
                xWriter.WriteFullEndElement();
                xWriter.Flush();

                xWriter.WriteStartElement("Health");
                xWriter.WriteString(current_health.ToString());
                xWriter.WriteFullEndElement();
                xWriter.Flush();

                xWriter.WriteStartElement("Magic");
                xWriter.WriteString(current_magic.ToString());
                xWriter.WriteFullEndElement();
                xWriter.Flush();

                xWriter.WriteStartElement("Money");
                xWriter.WriteString(current_money.ToString());
                xWriter.WriteFullEndElement();
                xWriter.Flush();

                xWriter.WriteStartElement("Diamond");
                xWriter.WriteString(current_diamonds.ToString());
                xWriter.WriteFullEndElement();
                xWriter.Flush();

                xWriter.WriteStartElement("Scene");
                xWriter.WriteString(last_screen_name);
                xWriter.WriteFullEndElement();
                xWriter.Flush();

                xWriter.WriteFullEndElement();
                xWriter.Flush();
                statusText.text = name + " has been saved!!!";

            }


            xWriter.WriteFullEndElement();
            xWriter.Flush();
            xWriter.WriteFullEndElement();
            xWriter.Flush();

        }


        xWriter.Close();

        
    }

    private bool CheckIfNameExists(string fullname)
    {
        bool exists = false;

        XmlNodeList xmlNodeList = xDoc.GetElementsByTagName("Name");

        foreach (XmlNode name in xmlNodeList)
        {
            string Name = name.InnerText;

            if (Name.Equals(fName))
            {
                exists = true;
                statusText.text = Name + " exists!!!.";
                AsyncOperation aSyncOp = SceneManager.LoadSceneAsync("Main Hall", LoadSceneMode.Single);

                while(!aSyncOp.isDone)
                {
                   float sceneLoadProgress = aSyncOp.progress;
                    newPlayerLoadBar.value = sceneLoadProgress;
                }

                aSyncOp.allowSceneActivation = true;
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
