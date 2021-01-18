using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AxePanel : MonoBehaviour
{
    Animator axeAnim;
    GameObject axeSlotGO;
    private Image axeIcon;
    Sprite axeSprite;
    private Image typeImage;
    Sprite typeSprite;
    Text axeName;
    //private GameObject axeSlot;
    //Transform _slots;
    //string jsonPath;
    //Inventory weaponList;
    //string iconPath;
    //FileStream fStream;
    //FileStream jsonStream;
    //string typePath;
    //List<string> weapons;
    //JsonWriter jWriter;
    //JsonReader jReader;
    public GameObject axeButtonGO;
   

    // Start is called before the first frame update
    void Start()
    {
        axeAnim = GetComponent<Animator>();
        
    }

    public void OpenAxePanel()
    {
        axeAnim.SetBool("isOpen", true);
    }

    public void CloseAxePanel()
    {
        axeAnim.SetBool("isOpen", false);
    }

    public void AddNewAxe(Sprite axeSprite, int quantity, string axeName)
    {
        GameObject newAxeButtonGO = Instantiate(axeButtonGO, transform) as GameObject;
        Button newAxeButton = newAxeButtonGO.transform.Find("Button").GetComponent<Button>();

        Image newAxeButtonImage = newAxeButtonGO.transform.Find("Button").GetComponent<Image> ( );
        newAxeButtonImage.sprite = axeSprite;

        Text newAxeText = newAxeButtonGO.transform.Find("Name Text").GetComponent<Text>();
        newAxeText.text = axeName;

        Text quantityText = newAxeButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString();

        
       
    }
    //private void SaveNewaxe(Sprite axeSprite, Sprite typeSprite, stringaxeName)
    //{
    //    weaponList.name =axeName;
    //    weapons.Add(weaponList.name);
    //    weaponList.description = "";
    //    weapons.Add(weaponList.description);
    //    weaponList.price = "";
    //    weapons.Add(weaponList.price);
    //    weaponList.icon = iconPath + "//" + axeSprite.name;
    //    weapons.Add(weaponList.icon);
    //    weaponList.type = typePath + "//" + typeSprite.name;
    //    weapons.Add(weaponList.type);

    //    string weapon_axe = JsonConvert.SerializeObject(weapons, Formatting.Indented);

    //    using (var streamReader = new StreamReader(jsonStream))
    //    {
    //        jReader = new JsonTextReader(streamReader);

    //        while (jReader.Read())
    //        {
    //            if (jReader.ReadAsString() != "axes")
    //            {
    //                jReader.Skip();
    //            }

    //            else
    //            {
    //                jWriter.Formatting = Formatting.Indented;

    //                jWriter.WriteStartObject();
    //                jWriter.WritePropertyName("name");
    //                jWriter.WriteValue(weapons[0]);
    //                jWriter.WritePropertyName("description");
    //                jWriter.WriteValue(weapons[1]);
    //                jWriter.WritePropertyName("price");
    //                jWriter.WriteValue(weapons[2]);
    //                jWriter.WritePropertyName("icon");
    //                jWriter.WriteValue(weapons[3]);
    //                jWriter.WritePropertyName("type");
    //                jWriter.WriteValue(weapons[4]);
    //                jWriter.WriteEndObject();
    //            }
    //        }
    //    }


    //}
}
