using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelController : MonoBehaviour {
    GameObject dronePanel;
    GameObject placesPanel;
    GameObject weaponsPanel;
    GameObject mainPanel;
   
    

	// Use this for initialization
	void Start () {
        dronePanel = transform.Find("Panel_Drones").gameObject;
        placesPanel = transform.Find("Panel_Places").gameObject;
        weaponsPanel = transform.Find("Panel_Weapons").gameObject;
        mainPanel = transform.Find("Panel_Main").gameObject;
        
	}
	
	public void DronePanelActivate()
    {
        dronePanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void DronePanelDeActivate()
    {
        dronePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void WeaponsPanelActivate()
    {
        weaponsPanel.SetActive(true);
        mainPanel.SetActive(false);

    }

    public void WeaponsPanelDeActivate()
    {
        weaponsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void PlacesPanelActivate()
    {
        placesPanel.SetActive(true);
        mainPanel.SetActive(false);
      
    }

    public void PlacesPanelDeActivate()
    {
        placesPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    

}
