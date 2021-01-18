using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    CanvasGroup canvasGroup;
    Text weaponButtonText;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup> ( );
        weaponButtonText = GameObject.Find ( "Weapon UI Canvas" ).transform.Find ( "Weapon UI Panel" ).transform.Find ( "Weapon Slection Panel" ).transform.Find ( "Text" ).GetComponent<Text> ( );
    }

   public void ViewInventory()
   {
        canvasGroup.alpha = 1.0f;
        weaponButtonText.text = "Hide Weapons";
   }

    public void HideInventory()
    {
        canvasGroup.alpha = 0.1f;
        weaponButtonText.text = "Show Weapons";
    }

    public void OnValueChanged(Toggle weaponToggle)
    {
        if (weaponToggle.isOn)
        {
            ViewInventory ( );
        }
        else
        {
            HideInventory ( );
        }
    }
}
