using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueDiamond : MonoBehaviour
{
    Text diamondText;
    int currentDiamondCount;

    // Start is called before the first frame update
    void Start()
    {
        diamondText = GameObject.Find("Status Canvas").transform.Find("Status Panel").transform.Find("Diamond Text").GetComponent<Text>();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Air Drone") || other.GetComponent<Collider>().CompareTag("Land Drone"))
        {
            currentDiamondCount = int.Parse(diamondText.text);
            currentDiamondCount += 250;
            diamondText.text = currentDiamondCount.ToString();
            gameObject.SetActive(false);

        }
    }
}
