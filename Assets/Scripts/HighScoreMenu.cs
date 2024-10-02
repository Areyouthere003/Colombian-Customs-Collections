using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField] HighScore highScore;
    int _value = 0;
    // Start is called before the first frame update
    void Start()
    {
        _value = highScore.HighValue;
        gameObject.GetComponent<TextMeshProUGUI>().text = _value.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
