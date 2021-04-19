using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PotionsPanel : MonoBehaviour
{
    private Animator potionsAnim;
    private GameObject potionsSlotGO;
    private Image potionsIcon;
    private Sprite potionsSprite;
    private Image typeImage;
    private Sprite typeSprite;
    private Text potionsName;
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
    private void Start ( )
    {
        potionsAnim = GetComponent<Animator> ( );

    }

    public void OpenPotionsPanel ( )
    {
        potionsAnim.SetBool ( "isOpen" , true );
    }

    public void ClosePotionsPanel ( )
    {
        potionsAnim.SetBool ( "isOpen" , false );
    }

    public void AddNewPotionsButton ( Sprite potionsSprite , int quantity , string potionsName )
    {
        GameObject newPotionButtonGO = Instantiate(potionButtonGO) as GameObject;
        newPotionButtonGO.transform.localScale = new Vector3 ( 0.033f , 0.033f , 0.033f );
        newPotionButtonGO.transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );

        Image newPotionButtonImage = newPotionButtonGO.transform.Find("Weapon Image").GetComponent<Image> ( );
        newPotionButtonImage.sprite = potionsSprite;

        Text newPotionText = newPotionButtonGO.transform.Find("Name Text").GetComponent<Text>();
        newPotionText.text = potionsName;

        Text quantityText = newPotionButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString ( );

        GameObject scrollBarContent = transform.parent.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;
        newPotionButtonGO.transform.parent = scrollBarContent.transform;
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