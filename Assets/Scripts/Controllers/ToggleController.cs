using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour {
    private Toggle placesToggle;
    private Toggle weaponsToggle;
    private ToggleGroup toggleGroup;
    IEnumerable toggleSelected;
    GameObject canvas;
    GameObject placesBar;
    GameObject weaponsBar;



	// Use this for initialization
	void Start () {
        placesToggle = gameObject.transform.Find("Places").GetComponent<Toggle>();
        weaponsToggle = gameObject.transform.Find("Weapons").GetComponent<Toggle>();
        toggleGroup = gameObject.GetComponent<ToggleGroup>();
        canvas = GameObject.Find("Canvas");
        placesBar = canvas.transform.Find("Places Bar").gameObject;
        weaponsBar = canvas.transform.Find("Weapon Bar").gameObject;

		
	}
	
	// Update is called once per frame
	void Update () {

        if (toggleGroup.AnyTogglesOn())
        {
            toggleSelected = toggleGroup.ActiveToggles();

            foreach (Toggle tSelected in toggleSelected)
            {
                if (tSelected == placesToggle && tSelected.isOn)
                {
                    placesBar.SetActive(true);
                    weaponsBar.SetActive(false);
                }

                if (tSelected == weaponsToggle && tSelected.isOn)
                {
                    weaponsBar.SetActive(true);
                    placesBar.SetActive(false);
                }


            }
        }
		
	}
}
