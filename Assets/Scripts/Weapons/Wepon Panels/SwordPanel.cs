using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SwordPanel : MonoBehaviour
{
    Animator swordAnim;
    GameObject swordSlotGO;
    private Image swordIcon;
    Sprite swordSprite;
    private Image typeImage;
    Sprite typeSprite;
    Text swordName;
    //private GameObject swordSlot;
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
    public GameObject swordButtonGO;
    

    // Start is called before the first frame update
    void Start()
    {
        swordAnim = GetComponent<Animator>();
        
    }

    public void OpenSwordPanel()
    {
        swordAnim.SetBool("isOpen", true);
    }

    public void CloseSwordPanel()
    {
        swordAnim.SetBool("isOpen", false);
    }

    public void AddNewSword(Sprite swordSprite, int quantity, string swordName)
    {
        GameObject newSwordButtonGO = Instantiate(swordButtonGO, transform) as GameObject;
        Button newSwordButton = newSwordButtonGO.transform.Find("Button").GetComponent<Button>();

        Image newSwordButtonImage = newSwordButtonGO.transform.Find("Button").GetComponent<Image> ( );
        newSwordButtonImage.sprite = swordSprite;

        Text newSwordText = newSwordButton.transform.Find("Name Text").GetComponent<Text>();
        newSwordText.text = swordName;

        Text quantityText = newSwordButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString();

     }
    //private void SaveNewsword(Sprite swordSprite, Sprite typeSprite, string swordName)
    //{
    //    weaponList.name = swordName;
    //    weapons.Add(weaponList.name);
    //    weaponList.description = "";
    //    weapons.Add(weaponList.description);
    //    weaponList.price = "";
    //    weapons.Add(weaponList.price);
    //    weaponList.icon = iconPath + "//" + swordSprite.name;
    //    weapons.Add(weaponList.icon);
    //    weaponList.type = typePath + "//" + typeSprite.name;
    //    weapons.Add(weaponList.type);

    //    string weapon_sword = JsonConvert.SerializeObject(weapons, Formatting.Indented);

    //    using (var streamReader = new StreamReader(jsonStream))
    //    {
    //        jReader = new JsonTextReader(streamReader);

    //        while (jReader.Read())
    //        {
    //            if (jReader.ReadAsString() != "swords")
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
