using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class PotionsPanel : MonoBehaviour
{
    Animator potionsAnim;
    GameObject potionsSlotGO;
    private Image potionsIcon;
    Sprite potionsSprite;
    private Image typeImage;
    Sprite typeSprite;
    Text potionsName;
    private GameObject potionsSlot;
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
    public GameObject potionButtonGO;


    // Start is called before the first frame update
    void Start()
    {
        potionsAnim = GetComponent<Animator>();
        
    }

    public void OpenPotionsPanel()
    {
        potionsAnim.SetBool("isOpen", true);
    }

    public void ClosePotionsPanel()
    {
        potionsAnim.SetBool("isOpen", false);
    }

    public void AddNewPotions(Sprite potionsSprite, int quantity, string potionsName)
    {
        GameObject newPotionButtonGO = Instantiate(potionButtonGO, transform) as GameObject;
        Button newPotionButton = newPotionButtonGO.transform.Find("Button").GetComponent<Button>();

        Image newPotionButtonImage = newPotionButton.transform.Find("Button").GetComponent<Image> ( );
        newPotionButtonImage.sprite = potionsSprite;

        Text newPotionText = newPotionButton.transform.Find("Name Text").GetComponent<Text>();
        newPotionText.text = potionsName;

        
        Text quantityText = newPotionButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString();

      
    }
    //private void SaveNewpotions(Sprite potionsSprite, Sprite typeSprite, string potionsName)
    //{
    //    weaponList.name = potionsName;
    //    weapons.Add(weaponList.name);
    //    weaponList.description = "";
    //    weapons.Add(weaponList.description);
    //    weaponList.price = "";
    //    weapons.Add(weaponList.price);
    //    weaponList.icon = iconPath + "//" + potionsSprite.name;
    //    weapons.Add(weaponList.icon);
    //    weaponList.type = typePath + "//" + typeSprite.name;
    //    weapons.Add(weaponList.type);

    //    string weapon_potions = JsonConvert.SerializeObject(weapons, Formatting.Indented);

    //    using (var streamReader = new StreamReader(jsonStream))
    //    {
    //        jReader = new JsonTextReader(streamReader);

    //        while (jReader.Read())
    //        {
    //            if (jReader.ReadAsString() != "potionss")
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
