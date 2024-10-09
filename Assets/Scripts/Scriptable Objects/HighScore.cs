using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class HighScore : ScriptableObject
{
    [SerializeField] int _highScore;
    [SerializeField] string _playerName;

    public int HighValue
    {
        get { return _highScore; }
        set { _highScore = value; }
    }

    public string stringValue
    {
        get { return _playerName; }
        set { _playerName = value; }
    }

    public void GetNewName(TextMeshProUGUI newName)
    {
        stringValue = newName.text;
    }
}
