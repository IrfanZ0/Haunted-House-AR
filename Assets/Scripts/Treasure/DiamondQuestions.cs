using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondQuestions : MonoBehaviour
{
    Dictionary<int, string> blueDiamondQuestions;
    Dictionary<int, string> redDiamondQuestions;
    Dictionary<int, string> yellowDiamondQuestions;
    Dictionary<int, string> purpleDiamondQuestions;
    Dictionary<int, string> greenDiamondQuestions;
    Dictionary<int, string> orangeDiamondQuestions;

    [HideInInspector] public bool blueQuestionAsked;
    [HideInInspector] public bool redQuestionAsked;
    [HideInInspector] public bool yellowQuestionAsked;
    [HideInInspector] public bool purpleQuestionAsked;
    [HideInInspector] public bool greenQuestionAsked;
    [HideInInspector] public bool orangeQuestionAsked;
    [HideInInspector] public enum DiamondStates { Blue, Red, Yellow, Purple, Green, Orange, None };

    // Start is called before the first frame update
    void Start()
    {
       
        blueDiamondQuestions = new Dictionary<int, string>();
        blueDiamondQuestions.Add(0, "This famous diamond (A.K.A Hope Diamond) was first discovered in India and believed to put a curse on anyone who possessed it");
        blueDiamondQuestions.Add(1, "These diamonds symbolizes confidence, strength, and loyalty");
        blueDiamondQuestions.Add(2, "These diamonds are perfect for outgoing, colorful, and romantic types");
        blueDiamondQuestions.Add(3, "Kate Hudson and Queen Elizabeth II were known to wear this colored diamond");

        redDiamondQuestions = new Dictionary<int, string>();
        redDiamondQuestions.Add(0, "This colored diamond symbolizes passion, power, and ritual");
        redDiamondQuestions.Add(1, "The most largest and flawless of diamonds is the Moussaieff");
        redDiamondQuestions.Add(2, "Eva Longoria was known to wear this colored ring");

        yellowDiamondQuestions = new Dictionary<int, string>();
        yellowDiamondQuestions.Add(0, "This colored diamond symbolizes optimism, playfulness, and sociability");
        yellowDiamondQuestions.Add(1, "This colored diamond is perfect for adventurous, creative, and fun-loving");
        yellowDiamondQuestions.Add(2, "Kelly Clarkson, Heidi Klum, and Jennifer Lopez were known to wear this colored diamond");

        purpleDiamondQuestions = new Dictionary<int, string>();
        purpleDiamondQuestions.Add(0, "These diamonds symbolizes spirituality, enlightment, and pride");
        purpleDiamondQuestions.Add(1, "These diamonds symbolizes nobility, wealth, and power");
        purpleDiamondQuestions.Add(2, "Vanessa Bryant and Lady Gaga was known to wear this colored diamond");

        greenDiamondQuestions = new Dictionary<int, string>();
        greenDiamondQuestions.Add(0, "These diamonds symbolizes money and long life");
        greenDiamondQuestions.Add(1, "These diamonds are perfect for bankers, investors, and nature lovers");
        greenDiamondQuestions.Add(2, "Heidi Klum was known to wear this colored diamond.");

        orangeDiamondQuestions = new Dictionary<int, string>();
        orangeDiamondQuestions.Add(0, "An opal is considered this type of diamonds thought to heal wounds");
        orangeDiamondQuestions.Add(1, "This diamond is perfect for those that are shy and lack self confidence and would improve such problems.");
        orangeDiamondQuestions.Add(2, "Halle Berry was known to wear this colored diamond");
    }

   public string AskBlueQuestion()
   {
        string bQuestion = null;

        int randomQuestion = Mathf.RoundToInt(UnityEngine.Random.Range(0, blueDiamondQuestions.Count - 1));
        bQuestion = blueDiamondQuestions [ randomQuestion ];
        blueQuestionAsked = true;

        return bQuestion;
        
   }

    public string AskRedQuestion ( )
    {
        string rQuestion = null;

        int randomQuestion = Mathf.RoundToInt(UnityEngine.Random.Range(0, redDiamondQuestions.Count - 1));
        rQuestion = redDiamondQuestions [ randomQuestion ];
        redQuestionAsked = true;

        return rQuestion;

    }

    public string AskYellowQuestion ( )
    {
        string yQuestion = null;

        int randomQuestion = Mathf.RoundToInt(UnityEngine.Random.Range(0, yellowDiamondQuestions.Count - 1));
        yQuestion = yellowDiamondQuestions [ randomQuestion ];
        yellowQuestionAsked = true;

        return yQuestion;

    }

    public string AskPurpleQuestion ( )
    {
        string pQuestion = null;

        int randomQuestion = Mathf.RoundToInt(UnityEngine.Random.Range(0, purpleDiamondQuestions.Count - 1));
        pQuestion = purpleDiamondQuestions [ randomQuestion ];
        purpleQuestionAsked = true;

        return pQuestion;

    }

    public string AskGreenQuestion ( )
    {
        string gQuestion = null;

        int randomQuestion = Mathf.RoundToInt(UnityEngine.Random.Range(0, greenDiamondQuestions.Count - 1));
        gQuestion = greenDiamondQuestions [ randomQuestion ];
        greenQuestionAsked = true;

        return gQuestion;

    }

    public string AskOrangeQuestion ( )
    {
        string oQuestion = null;

        int randomQuestion = Mathf.RoundToInt(UnityEngine.Random.Range(0, orangeDiamondQuestions.Count - 1));
        oQuestion = orangeDiamondQuestions [ randomQuestion ];
        orangeQuestionAsked = true;

        return oQuestion;

    }

    public DiamondStates SetDiamondState()
    {
        DiamondStates dState = DiamondStates.None;
        int randomState = Mathf.RoundToInt(UnityEngine.Random.Range(0, 6));

        switch (randomState)
        {
            case 0:
                {
                    dState = DiamondStates.Blue;
                    break;
                }
            case 1:
                {
                    dState = DiamondStates.Green;
                    break;
                }
            case 2:
                {
                    dState = DiamondStates.Red;
                    break;
                }
            case 3:
                {
                    dState = DiamondStates.Orange;
                    break;
                }
            case 4:
                {
                    dState = DiamondStates.Purple;
                    break;
                }
            case 5:
                {
                    dState = DiamondStates.Yellow;
                    break;
                }
            case 6:
                {
                    dState = DiamondStates.None;
                    break;
                }
        }

        return dState;
    }

   
}
