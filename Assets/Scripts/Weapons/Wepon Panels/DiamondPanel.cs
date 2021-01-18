using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondPanel : MonoBehaviour
{
    Animator axeAnim;
    GameObject potionsSlotGO;
    private Image potionsIcon;
    Sprite diamondSprite;
    private Image typeImage;
    Sprite typeSprite;
    Text diamondName;
    //private GameObject potionsSlot;
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
    public GameObject diamondButtonGO;
    public Sprite orangeDiamondSprite;
 

    // Start is called before the first frame update
    void Start ( )
    {
        axeAnim = GetComponent<Animator> ( );
        AddNewDiamond ( orangeDiamondSprite , 1 , "Orange Diamond" );

    }

    public void OpenAxePanel ( )
    {
        axeAnim.SetBool ( "isOpen" , true );
    }

    public void CloseAxePanel ( )
    {
        axeAnim.SetBool ( "isOpen" , false );
    }

    public void AddNewDiamond ( Sprite diamondSprite , int quantity , string diamondName )
    {
        GameObject newDiamondButtonGO = Instantiate(diamondButtonGO, transform) as GameObject;
        Button newDiamondButton = newDiamondButtonGO.transform.Find("Button").GetComponent<Button>();
        
        Image newDiamondButtonImage = newDiamondButtonGO.transform.Find("Button").GetComponent<Image> ( );
        newDiamondButtonImage.sprite = diamondSprite;

        Text newDiamondText = newDiamondButtonGO.transform.Find("Name Text").GetComponent<Text>();
        newDiamondText.text = diamondName;

       Text quantityText = newDiamondButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString();

       
    }

    public void PrintMe()
    {
        Debug.Log ( "I have been clicked!!!" );
    }
    //private void SaveNewpotions ( Sprite diamondSprite , Sprite typeSprite , string diamondName )
    //{
    //    weaponList.name = diamondName;
    //    weapons.Add ( weaponList.name );
    //    weaponList.description = "";
    //    weapons.Add ( weaponList.description );
    //    weaponList.price = "";
    //    weapons.Add ( weaponList.price );
    //    weaponList.icon = iconPath + "//" + diamondSprite.name;
    //    weapons.Add ( weaponList.icon );
    //    weaponList.type = typePath + "//" + typeSprite.name;
    //    weapons.Add ( weaponList.type );

    //    string weapon_potions = JsonConvert.SerializeObject(weapons, Formatting.Indented);

    //    using ( var streamReader = new StreamReader ( jsonStream ) )
    //    {
    //        jReader = new JsonTextReader ( streamReader );

    //        while ( jReader.Read ( ) )
    //        {
    //            if ( jReader.ReadAsString ( ) != "potionss" )
    //            {
    //                jReader.Skip ( );
    //            }

    //            else
    //            {
    //                jWriter.Formatting = Formatting.Indented;

    //                jWriter.WriteStartObject ( );
    //                jWriter.WritePropertyName ( "name" );
    //                jWriter.WriteValue ( weapons [ 0 ] );
    //                jWriter.WritePropertyName ( "description" );
    //                jWriter.WriteValue ( weapons [ 1 ] );
    //                jWriter.WritePropertyName ( "price" );
    //                jWriter.WriteValue ( weapons [ 2 ] );
    //                jWriter.WritePropertyName ( "icon" );
    //                jWriter.WriteValue ( weapons [ 3 ] );
    //                jWriter.WritePropertyName ( "type" );
    //                jWriter.WriteValue ( weapons [ 4 ] );
    //                jWriter.WriteEndObject ( );
    //            }
    //        }
    //    }


    //}
}
