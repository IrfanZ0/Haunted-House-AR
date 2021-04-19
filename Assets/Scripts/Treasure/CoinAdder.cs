using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAdder : MonoBehaviour
{
    private int coins = 0;
    private Text coinsText;

    // Start is called before the first frame update
    private void Start ( )
    {
        coinsText = GameObject.FindGameObjectWithTag ( "Player Life" ).transform.Find ( "Coin Text" ).GetComponent<Text> ( );

    }

    public int AddCoinBag ( )
    {
        int money = int.Parse(coinsText.text);
        int coinBagValue = 100;
        coins = money + coinBagValue;
        return coins;

    }
}