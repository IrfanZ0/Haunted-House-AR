using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class GunsPanel : MonoBehaviour
{
    private Animator gunsAnim;
    private GameObject gunSlotGO;
    private Image gunIcon;
    private Sprite gunSprite;
    private Image typeImage;
    private Sprite typeSprite;
    private Text gunName;

    public GameObject gunButtonGO;
    public Sprite maulerSprite;
    public Sprite hellwailerSprite;
    public Sprite fireSleetSprite;
    public Sprite archtronicSprite;

    // Start is called before the first frame update
    private void Start ( )
    {
        gunsAnim = GetComponent<Animator> ( );

        AddNewGunButton ( maulerSprite , 1 , "mauler" );

    }

    public void OpenGunsPanel ( )
    {
        gunsAnim.SetBool ( "isOpen" , true );
    }

    public void CloseGunsPanel ( )
    {
        gunsAnim.SetBool ( "isOpen" , false );
    }

    public void AddNewGunButton ( Sprite gunSprite , int quantity , string gunName )
    {
        GameObject newGunButtonGO = Instantiate(gunButtonGO) as GameObject;
        newGunButtonGO.transform.localPosition = Vector3.zero;
        newGunButtonGO.transform.localScale = new Vector3 ( .033f , .033f , .033f );
        newGunButtonGO.transform.rotation = Quaternion.identity;

        Image newGunButtonImage = newGunButtonGO.transform.Find("Weapon Image").GetComponent<Image> ( );
        newGunButtonImage.sprite = gunSprite;

        Text newGunText = newGunButtonGO.transform.Find("Name Text").GetComponent<Text>();
        newGunText.text = gunName;

        Text quantityText = newGunButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString ( );

        GameObject scrollBarContent = transform.parent.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;
        newGunButtonGO.transform.parent = scrollBarContent.transform;

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