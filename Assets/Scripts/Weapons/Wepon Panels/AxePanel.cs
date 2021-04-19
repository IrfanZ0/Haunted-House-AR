using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AxePanel : MonoBehaviour
{
    private Animator axeAnim;
    private GameObject axeSlotGO;
    private Image axeIcon;
    private Sprite axeSprite;
    private Image typeImage;
    private Sprite typeSprite;
    private Text axeName;
    public GameObject axeButtonGO;
    public Sprite regularAxeSprite;
    public Sprite medievalAxeSprite;
    public Sprite fireManAxeSprite;
    public Sprite doubleHammerAxeSprite;
    public Sprite doubleBladeAxeSprite;

    // Start is called before the first frame update
    private void Start ( )
    {
        axeAnim = GetComponent<Animator> ( );
        AddNewAxeButton ( regularAxeSprite , 1 , "Regular Axe" );
        AddNewAxeButton ( medievalAxeSprite , 1 , "Medieval Axe" );
        AddNewAxeButton ( fireManAxeSprite , 1 , "FireMan Axe" );
        AddNewAxeButton ( doubleHammerAxeSprite , 1 , "Double Hammer Axe" );
        AddNewAxeButton ( doubleBladeAxeSprite , 1 , "Double Blade Axe" );

    }

    public void OpenAxePanel ( )
    {
        axeAnim.SetBool ( "isOpen" , true );
    }

    public void CloseAxePanel ( )
    {
        axeAnim.SetBool ( "isOpen" , false );
    }

    public void AddNewAxeButton ( Sprite axeSprite , int quantity , string axeName )
    {
        GameObject newAxeButtonGO = Instantiate(axeButtonGO) as GameObject;
        newAxeButtonGO.transform.localScale = new Vector3 ( 0.033f , 0.033f , 0.033f );
        newAxeButtonGO.transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );

        Image newAxeButtonImage = newAxeButtonGO.transform.Find("Weapon Image").GetComponent<Image> ( );
        newAxeButtonImage.sprite = axeSprite;

        Text newAxeText = newAxeButtonGO.transform.Find("Name Text").GetComponent<Text>();
        newAxeText.text = axeName;

        Text quantityText = newAxeButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString ( );

        GameObject scrollBarContent = transform.parent.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;
        newAxeButtonGO.transform.parent = scrollBarContent.transform;
        newAxeButtonGO.transform.localPosition = Vector3.zero;

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