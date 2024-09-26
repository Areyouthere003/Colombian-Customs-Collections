using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HighScore : ScriptableObject
{
    [SerializeField] int _highScore;
    [SerializeField] string _stringHS;

    public int HighValue
    {
        get { return _highScore; }
        set { _highScore = value; }
    }

    public string stringValue
    {
        get { return _stringHS; }
        set { _stringHS = value; }
    }
}
