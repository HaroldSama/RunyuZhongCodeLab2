using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetManager : MonoBehaviour
{
    public static BetManager Instance;
    public int yourMoney = 100;
    public int yourBet;
    public Text yourMoneyText;
    public Text yourBetText;
    public List<GameObject> objectsForBet;
    public List<GameObject> objcetsForGame;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bet(int amount)
    {
        if (yourMoney < amount)
        {
            print("YOU DON'T HAVE THAT MUCH!");
            return;
        }
        
        ResetGameState();
        
        yourBet = amount;
        yourBetText.text = "Your Bet: $" + amount;
        yourMoney -= amount;
        yourMoneyText.text = "You Have: $" + yourMoney;

        
    }

    public void ResetGameState(bool toBet = false)
    {
        foreach (var obj in objectsForBet)
        {
            obj.SetActive(toBet);
        }
        
        foreach (var obj in objcetsForGame)
        {
            obj.SetActive(!toBet);
        }

        yourBet = 0;
        yourBetText.text = "Your Bet:";
    }
}
