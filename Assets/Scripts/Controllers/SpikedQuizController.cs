using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikedQuizController : MonoBehaviour
{
    List<Text> altarTextBoxes;
    List<GameObject> altars;
    DiamondQuestions dQuestions;
    public GameObject treasureChestGO;
    GameObject treasureChest;
    public Transform treasureSpot;
    
  
   

    // Start is called before the first frame update
    void Start()
    {
        dQuestions = GameObject.FindGameObjectWithTag ( "MainCamera" ).GetComponent<DiamondQuestions> ( );
        altarTextBoxes = new List<Text>();
        altars = new List<GameObject> ( );

        foreach (var child in gameObject.GetComponentsInChildren<Transform>())
        {
            if (child.CompareTag("Altar"))
            {
                altars.Add ( child.gameObject );
                Text questionBlock = child.transform.Find("Canvas").transform.Find("Panel").transform.Find("Scroll Rect").transform.Find("Text").GetComponent<Text>();
                altarTextBoxes.Add(questionBlock);

            }

        }

             
        
    }

    // Update is called once per frame
    void Update()
    {
       

        switch(dQuestions.SetDiamondState())
        {
            
            case DiamondQuestions.DiamondStates.Blue:
                {
                    altarTextBoxes [ 0 ].text = dQuestions.AskBlueQuestion ( );
                    
                    break;
                }
            case DiamondQuestions.DiamondStates.Red:
                {
                    altarTextBoxes [ 1 ].text = dQuestions.AskRedQuestion ( );
                   
                    break;
                }
            case DiamondQuestions.DiamondStates.Green:
                {
                    altarTextBoxes [ 2 ].text = dQuestions.AskGreenQuestion ( );
                   
                    break;
                }
            case DiamondQuestions.DiamondStates.Orange:
                {
                    altarTextBoxes [ 3 ].text = dQuestions.AskOrangeQuestion ( );
                   
                    break;
                }
            case DiamondQuestions.DiamondStates.Purple:
                {
                    altarTextBoxes [ 0 ].text = dQuestions.AskPurpleQuestion ( );
                   
                    break;
                }
            case DiamondQuestions.DiamondStates.Yellow:
                {
                    altarTextBoxes [ 1 ].text = dQuestions.AskYellowQuestion ( );
                   
                    break;
                }
            default:
                {
                    ShowTreasureChest ( altars );
                    break;
                }
        }
    }

    private void ShowTreasureChest ( List<GameObject> altars )
    {
        foreach ( var altar in altars)
        {
            MeshRenderer altarMeshRenderer = altar.transform.Find("altar").GetComponent<MeshRenderer>();
            if (altarMeshRenderer.gameObject.activeSelf == false)
            {
                treasureChest = Instantiate ( treasureChestGO , treasureSpot.position , treasureSpot.rotation ) as GameObject;
            }
        }
    }
}
