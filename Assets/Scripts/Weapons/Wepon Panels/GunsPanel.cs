using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class GunsPanel : MonoBehaviour
{
    Animator gunsAnim;
    GameObject gunSlotGO;
    private Image gunIcon;
    Sprite gunSprite;
    private Image typeImage;
    Sprite typeSprite;
    Text gunName;
    //private GameObject gunSlot;
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
    public GameObject gunButtonGO;
    public Sprite maulerSprite;
   
    


    // Start is called before the first frame update
    void Start()
    {
        gunsAnim = GetComponent<Animator>();
        //jsonPath = Path.Combine(Application.dataPath, "ExternalDocs//Weapon_Inventory.xml");
        //jsonStream = new FileStream(jsonPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        //weaponList = Inventory.CreateFromJSON(jsonPath);
        //iconPath = Path.Combine(Application.dataPath, "//Images");
        //fStream = new FileStream(iconPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        //typePath = Path.Combine(Application.dataPath, "//Resources//Core//QIS");
        //weapons = new List<string>();

        AddNewGun ( maulerSprite , 1 , "Mauler" );
    }

    public void OpenGunsPanel()
    {
        gunsAnim.SetBool("isOpen", true);
    }

    public void CloseGunsPanel()
    {
        gunsAnim.SetBool("isOpen", false);
    }

   
    public void AddNewGun(Sprite gunSprite, int quantity, string gunName)
    {
        GameObject newGunButtonGO = Instantiate(gunButtonGO, transform) as GameObject;
        Button newGunButton = newGunButtonGO.transform.Find("Button").GetComponent<Button>();

        Image newGunButtonImage = newGunButtonGO.transform.Find("Button").GetComponent<Image> ( );
        newGunButtonImage.sprite = gunSprite;

        Text newGunText = newGunButton.transform.Find("Name Text").GetComponent<Text>();
        newGunText.text = gunName;

        Text quantityText = newGunButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString();

       
    }                                      
    //private void SaveNewGun(Sprite gunSprite, Sprite typeSprite, string gunName)
    //{
    //    weaponList.name = gunName;
    //    weapons.Add(weaponList.name);
    //    weaponList.description = "";
    //    weapons.Add(weaponList.description);
    //    weaponList.price = "";
    //    weapons.Add(weaponList.price);
    //    weaponList.icon = iconPath + "//" + gunSprite.name;
    //    weapons.Add(weaponList.icon);
    //    weaponList.type = typePath + "//" + typeSprite.name;
    //    weapons.Add(weaponList.type);

    //    string weapon_gun = JsonConvert.SerializeObject(weapons, Formatting.Indented);

    //    using (var streamReader = new StreamReader(jsonStream))
    //    {
    //        jReader = new JsonTextReader(streamReader);

    //        while (jReader.Read())
    //        {
    //            if (jReader.ReadAsString() != "guns")
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
