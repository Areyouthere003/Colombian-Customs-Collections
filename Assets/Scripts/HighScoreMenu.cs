using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField] HighScore highScore;
    [SerializeField] SaveHSList saveData;
    [SerializeField] TextMeshProUGUI _namePlayerHS;
    int _value = 0;
    string _name = string.Empty;
    // Start is called before the first frame update
    void Start()
    {
        saveData.LoadForJson();
        _name = saveData.GetFirstPlaceName(_name);
        highScore.stringValue = _name;
        _value = saveData.GetFirstPlaceScore(_value);
        highScore.HighValue = _value;
        gameObject.GetComponent<TextMeshProUGUI>().text = _value.ToString();
        _namePlayerHS.text = _name;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
