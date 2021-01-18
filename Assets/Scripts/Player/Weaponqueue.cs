using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weaponqueue : MonoBehaviour
{
    Queue<RectTransform> panels;
    RectTransform swordPanel;
    RectTransform axePanel;
    RectTransform shieldPanel;
    RectTransform potionPanel;
    RectTransform gunsPanel;

    // Start is called before the first frame update
    void Start()
    {
        panels = new Queue<RectTransform>();
        swordPanel = transform.Find("Sword Panel").GetComponent<RectTransform>();
        axePanel = transform.Find("Axw Panel").GetComponent<RectTransform>();
        shieldPanel = transform.Find("Shield Panel").GetComponent<RectTransform>();
        potionPanel = transform.Find("Potions Panel").GetComponent<RectTransform>();
        gunsPanel = transform.Find("Guns Panel").GetComponent<RectTransform>();

        panels.Enqueue(swordPanel);
        panels.Enqueue(axePanel);
        panels.Enqueue(shieldPanel);
        panels.Enqueue(potionPanel);
        panels.Enqueue(gunsPanel);
    }

   public void OpenSwords()
    {

    }
}
