using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using TMPro;

public class CoinsManager : Singleton<CoinsManager>
{
    public int coins;
    public TextMeshProUGUI textCoinsCounter;



    protected void Awake(){
        base.Awake();
        Reset();
    }
    
    private void Reset(){
        
        coins = 0;
        UpdateCoinsUI();
    }

    public void AddCoins(int amount = 1){
        
        coins += amount;
        UpdateCoinsUI();
    }

    private void UpdateCoinsUI()
    {
        
        if (textCoinsCounter != null)
        {
            
            textCoinsCounter.text = "X" + " " +  coins.ToString();
            
            
        }
        else
        {
            Debug.LogWarning("Text Coins Counter não atribuído em CoinsManager.");
        }
    }
    
}
