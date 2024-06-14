using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using System;

public class TextScore : MonoBehaviour
{
    private TextMeshProUGUI text; 
    // Update is called once per frame

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Score: " + Math.Round(GameController.score, 1); 
    }
}
