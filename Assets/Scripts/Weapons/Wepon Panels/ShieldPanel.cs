using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShieldPanel : MonoBehaviour
{
    private Animator shieldAnim;
    private GameObject shieldSlotGO;
    private Image shieldIcon;
    private Sprite shieldSprite;
    private Image typeImage;
    private Sprite typeSprite;
    private Text shieldName;
    private GameObject shieldSlot;

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
    public GameObject shieldButtonGO;

    // Start is called before the first frame update
    private void Start ( )
    {
        shieldAnim = GetComponent<Animator> ( );

    }

    public void OpenShieldPanel ( )
    {
        shieldAnim.SetBool ( "isOpen" , true );
    }

    public void CloseShieldPanel ( )
    {
        shieldAnim.SetBool ( "isOpen" , false );
    }

    public void AddNewShieldButton ( Sprite shieldSprite , int quantity , string shieldName )
    {
        GameObject newShieldButtonGO = Instantiate(shieldButtonGO) as GameObject;
        newShieldButtonGO.transform.localScale = new Vector3 ( 0.033f , 0.033f , 0.033f );
        newShieldButtonGO.transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );

        Image newShieldButtonImage = newShieldButtonGO.transform.Find("Weapon Image").GetComponent<Image> ( );
        newShieldButtonImage.sprite = shieldSprite;

        Text newShieldText = newShieldButtonGO.transform.Find("Name Text").GetComponent<Text>();
        newShieldText.text = shieldName;

        Text quantityText = newShieldButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString ( );

        GameObject scrollBarContent = transform.parent.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;
        newShieldButtonGO.transform.parent = scrollBarContent.transform;

    }

    //private void SaveNewshield(Sprite shieldSprite, Sprite typeSprite, string shieldName)
    //{
    //    weaponList.name = shieldName;
    //    weapons.Add(weaponList.name);
    //    weaponList.description = "";
    //    weapons.Add(weaponList.description);
    //    weaponList.price = "";
    //    weapons.Add(weaponList.price);
    //    weaponList.icon = iconPath + "//" + shieldSprite.name;
    //    weapons.Add(weaponList.icon);
    //    weaponList.type = typePath + "//" + typeSprite.name;
    //    weapons.Add(weaponList.type);

    //    string weapon_shield = JsonConvert.SerializeObject(weapons, Formatting.Indented);

    //    using (var streamReader = new StreamReader(jsonStream))
    //    {
    //        jReader = new JsonTextReader(streamReader);

    //        while (jReader.Read())
    //        {
    //            if (jReader.ReadAsString() != "shields")
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