using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SaveHSList : MonoBehaviour
{
    [SerializeField] HighScoreData highScoreData = new HighScoreData();
    //[SerializeField] GameObject parentsScoreList;
    public bool valid = false/*, valid2 = false*/;
    string _highScoreData = string.Empty;
    string _hSLFilePath = string.Empty;

    private void Start()
    {
        LoadForJson();
        ScoreTableUpdate();

    }

    private void Update()
    {
        if(valid)
        {
            SortListBig();
            valid = false;
        }

        //if(valid2)
        //{
        //    highScoreData.AddList();
        //    valid2 = false;
        //}
        //if(highScoreData.IsSending)
        //{
        //    highScoreData.AddNameToList();
        //    highScoreData.IsSending = false;
        //}
    }

    public void SavedJson()
    {
        _highScoreData = JsonUtility.ToJson(highScoreData);
        _hSLFilePath = Application.persistentDataPath + "/HighScoreData.json";
        Debug.Log(_hSLFilePath);
        System.IO.File.WriteAllText(_hSLFilePath, _highScoreData);
        Debug.Log("algo en frances que se efectuó");
    }

    public void LoadForJson()
    {
        _hSLFilePath = Application.persistentDataPath + "/HighScoreData.json";
        _highScoreData = System.IO.File.ReadAllText(_hSLFilePath);
        highScoreData = JsonUtility.FromJson<HighScoreData>(_highScoreData);
        Debug.Log("data cargada");
    }

    //public void SendName(TextMeshProUGUI recivedName)
    //{
    //    highScoreData.RecivedName = recivedName.text;
    //    highScoreData.IsSending = true;
    //}

    public void GetName(string name)
    {
        highScoreData.RecivedName = name;
    }

    public void GetScore(int value)
    {
        highScoreData.TotalValue = value;
    }

    public void AddToList()
    {
        highScoreData.AddList();
    }

    public void SortListBig()
    {
        highScoreData.SortList();
    }

    public void RemoveTheLast()
    {
        highScoreData.RemoveFromList();
    }

    public void ScoreTableUpdate()
    {
        highScoreData.ParentGroupTMPUGUI();
    }

    public string GetFirstPlaceName(string sDataName)
    {
        highScoreData.GetFirstPlace();

        sDataName = highScoreData.RecivedName;
        return sDataName;
    }

    public int GetFirstPlaceScore(int sDataScore)
    {
        highScoreData.GetFirstPlace();

        sDataScore = highScoreData.TotalValue;
        return sDataScore;
    }

    public void GOUpdateFromAnotherScript(GameObject gameObject)
    {
        highScoreData.ParentGroup = gameObject;
        ScoreTableUpdate();
    }
}

[System.Serializable]
public class HighScoreData
{
    [SerializeField] GameObject parentGroup;
    [SerializeField] bool isSending = false;

    string _name = string.Empty, _time = string.Empty;
    int _score;

    [SerializeField] List<PlayerHighScore> _high = new List<PlayerHighScore>();
    [SerializeField] TextMeshProUGUI[] childsTMPUGUI;
    PlayerHighScore highScore = new PlayerHighScore();

    public void AddList()
    {
        highScore = new PlayerHighScore();
        highScore.name = _name;
        highScore.score = _score;
        _high.Add(highScore);
    }

    public void SortList()
    {

        for (int i = 0; i < _high.Count; i++)
        {
            _high.Sort((p1, p2) => p2.score.CompareTo(p1.score));
            //Debug.Log(_high[i].score);
        }
    }

    public void RemoveFromList()
    {
        _high.RemoveAt(10);
    }

    public void ParentGroupTMPUGUI()
    {
        childsTMPUGUI = parentGroup.GetComponentsInChildren<TextMeshProUGUI>();
        int incrementValue = 4;
        for (int i =  0; i < _high.Count; i++)
        {
            childsTMPUGUI[incrementValue].text = _high[i].name;
            incrementValue++;
            childsTMPUGUI[incrementValue].text = _high[i].score.ToString();
            incrementValue += 2;
        }
    }

    public void GetFirstPlace()
    {
        _score = _high[0].score;
        _name = _high[0].name;
    }

    //public void AddNameToList()
    //{
    //    foreach(PlayerHighScore name in _high)
    //    {
    //        if(name.name == string.Empty)
    //        {
    //            name.name = _name;
    //            break;
    //        }
    //    }
    //}

    public string RecivedName
    {
        get {return _name;}
        set { _name = value;}
    }

    public bool IsSending
    {
        get { return isSending; }
        set { isSending = value; }
    }

    public int TotalValue
    {
        get { return _score; }
        set { _score = value; }
    }

    public GameObject ParentGroup
    {
        get { return parentGroup; }
        set { parentGroup = value; }
    }

}

[System.Serializable]
public class PlayerHighScore
{
    public string name = string.Empty;
    public int score;
}


