using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using System;

public class textManager : MonoBehaviour
{
    public GameController game; 
    public int item = 0; 
    private TextMeshProUGUI text; 
    // Update is called once per frame

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (item ==0) {
          text.text = "Health: " + Math.Round(game.campfireHealth, 1);   
        } else if (item ==1) {
            text.text = "Score: " + Math.Round(GameController.score, 1); 
        } else if (item ==2) {
            text.text = "Money: " + Math.Round(game.money, 2); 
        } else if (item==3) {
            text.text = "Ol' Horace's Shoppe - Score Boost: $50 [K] | Barrier: $5 [J]";
        }
    }
}
