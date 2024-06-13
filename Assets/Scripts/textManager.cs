using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using System;

public class textManager : MonoBehaviour
{
    public GameController game; 
    public bool health = false; 
    private TextMeshProUGUI text; 
    // Update is called once per frame

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (health) {
          text.text = "Health: " + Math.Round(game.campfireHealth, 1);   
        } else {
            text.text = "Score: " + Math.Round(game.score, 1); 
        }
    }
}
