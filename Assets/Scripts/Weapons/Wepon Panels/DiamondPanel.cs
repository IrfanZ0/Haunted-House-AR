using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondPanel : MonoBehaviour
{
    public GameObject diamondButtonGO;
    public Sprite orangeDiamondSprite;
    private int quantity;

    // Start is called before the first frame update
    private void Start ( )
    {
        quantity = 0;

    }

    public int DiamondCounter ( )
    {
        return quantity += 1;
    }

    public void AddNewDiamond ( Sprite diamondSprite , int quantity , string diamondName )
    {
        gameObject.SetActive ( true );
        GameObject newDiamondButtonGO = Instantiate(diamondButtonGO) as GameObject;
        newDiamondButtonGO.transform.position = Vector3.zero;
        newDiamondButtonGO.transform.localScale = new Vector3 ( 0.033f , 0.033f , 0.033f );
        newDiamondButtonGO.transform.rotation = Quaternion.Euler ( 0 , 0 , 0 );
        newDiamondButtonGO.name = diamondName;

        Image newDiamondButtonImage = newDiamondButtonGO.transform.Find("Weapon Image").GetComponent<Image> ( );
        newDiamondButtonImage.sprite = diamondSprite;

        Text newDiamondText = newDiamondButtonGO.transform.Find("Name Text").GetComponent<Text>();
        newDiamondText.text = diamondName;

        Text quantityText = newDiamondButtonGO.transform.Find ( "Quantity Text" ).GetComponent<Text> ( );
        quantityText.text = quantity.ToString ( );

        GameObject scrollBarContent = transform.parent.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;
        Button newDiamondButton = newDiamondButtonGO.GetComponent<Button>();
        newDiamondButton.transform.parent = scrollBarContent.transform;

    }

    public void UpdateDiamondButton ( GameObject diamondButton , int quantityToAdd )
    {
        switch ( diamondButton.name )
        {
            case "Red Diamond":
                {
                    Text redDiamondQuantityString = diamondButton.transform.Find("Quantity Text").GetComponent<Text>();
                    int redDiamondCurrentQuantity = int.Parse(redDiamondQuantityString.text);
                    int redDiamondUpdatedQuantity = redDiamondCurrentQuantity + quantityToAdd;
                    redDiamondQuantityString.text = redDiamondUpdatedQuantity.ToString ( );
                    break;
                }
            case "Blue Diamond":
                {
                    Text blueDiamondQuantityString = diamondButton.transform.Find("Quantity Text").GetComponent<Text>();
                    int blueDiamondCurrentQuantity = int.Parse(blueDiamondQuantityString.text);
                    int blueDiamondUpdatedQuantity = blueDiamondCurrentQuantity + quantityToAdd;
                    blueDiamondQuantityString.text = blueDiamondUpdatedQuantity.ToString ( );
                    break;
                }
            case "Green Diamond":
                {
                    Text greenDiamondQuantityString = diamondButton.transform.Find("Quantity Text").GetComponent<Text>();
                    int greenDiamondCurrentQuantity = int.Parse(greenDiamondQuantityString.text);
                    int greenDiamondUpdatedQuantity = greenDiamondCurrentQuantity + quantityToAdd;
                    greenDiamondQuantityString.text = greenDiamondUpdatedQuantity.ToString ( );
                    break;
                }
            case "Purple Diamond":
                {
                    Text purpleDiamondQuantityString = diamondButton.transform.Find("Quantity Text").GetComponent<Text>();
                    int purpleDiamondCurrentQuantity = int.Parse(purpleDiamondQuantityString.text);
                    int purpleDiamondUpdatedQuantity = purpleDiamondCurrentQuantity + quantityToAdd;
                    purpleDiamondQuantityString.text = purpleDiamondUpdatedQuantity.ToString ( );
                    break;
                }
            case "Yellow Diamond":
                {
                    Text yellowDiamondQuantityString = diamondButton.transform.Find("Quantity Text").GetComponent<Text>();
                    int yellowDiamondCurrentQuantity = int.Parse(yellowDiamondQuantityString.text);
                    int yellowDiamondUpdatedQuantity = yellowDiamondCurrentQuantity + quantityToAdd;
                    yellowDiamondQuantityString.text = yellowDiamondUpdatedQuantity.ToString ( );
                    break;
                }
            case "Orange Diamond":
                {
                    Text orangeDiamondQuantityString = diamondButton.transform.Find("Quantity Text").GetComponent<Text>();
                    int orangeDiamondCurrentQuantity = int.Parse(orangeDiamondQuantityString.text);
                    int orangeDiamondUpdatedQuantity = orangeDiamondCurrentQuantity + quantityToAdd;
                    orangeDiamondQuantityString.text = orangeDiamondUpdatedQuantity.ToString ( );
                    break;
                }
            case "Silver Diamond":
                {
                    Text silverDiamondQuantityString = diamondButton.transform.Find("Quantity Text").GetComponent<Text>();
                    int silverDiamondCurrentQuantity = int.Parse(silverDiamondQuantityString.text);
                    int silverDiamondUpdatedQuantity = silverDiamondCurrentQuantity + quantityToAdd;
                    silverDiamondQuantityString.text = silverDiamondUpdatedQuantity.ToString ( );
                    break;
                }
        }
    }

}