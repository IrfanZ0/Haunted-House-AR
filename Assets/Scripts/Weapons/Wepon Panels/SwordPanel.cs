using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SwordPanel : MonoBehaviour
{
    private Animator swordAnim;
    private GameObject swordSlotGO;
    private Image swordIcon;
    private Sprite swordSprite;
    private Image typeImage;
    private Sprite typeSprite;
    private Text swordName;

    public GameObject swordButtonGO;

    // Start is called before the first frame update
    private void Start ( )
    {
        swordAnim = GetComponent<Animator> ( );

    }

    public void OpenSwordPanel ( )
    {
        swordAnim.SetBool ( "isOpen" , true );
    }

    public void CloseSwordPanel ( )
    {
        swordAnim.SetBool ( "isOpen" , false );
    }

    public void AddNewSwordButton ( Sprite swordSprite , int quantity , string swordName )
    {
        GameObject newSwordButtonGO = Instantiate(swordButtonGO) as GameObject;
        newSwordButtonGO.transform.localScale = new Vector3 ( 0.033f , 0.033f , 0.033f );
        newSwordButtonGO.transform.rotation = Quaternion.Euler ( 0 , -90f , 0 );

        Image newSwordButtonImage = newSwordButtonGO.transform.Find("Weapon Image").GetComponent<Image> ( );
        newSwordButtonImage.sprite = swordSprite;

        Text newSwordText = newSwordButtonGO.transform.Find("Name Text").GetComponent<Text>();
        newSwordText.text = swordName;

        Text quantityText = newSwordButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString ( );

        GameObject scrollBarContent = transform.parent.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;
        newSwordButtonGO.transform.parent = scrollBarContent.transform;

    }

}