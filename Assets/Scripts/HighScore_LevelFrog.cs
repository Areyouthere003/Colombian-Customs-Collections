using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore_LevelFrog : MonoBehaviour
{
    [SerializeField] HighScore _highScore;
    int _value = 0, _maxValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        _maxValue = _highScore.HighValue;
    }

    // Update is called once per frame
    void Update()
    {
        _value = Convert.ToInt32(gameObject.GetComponent<TextMeshProUGUI>().text);

        if(_value > _maxValue)
        {
            _highScore.HighValue = _value;
            _maxValue = _value;
        }
    }
}
