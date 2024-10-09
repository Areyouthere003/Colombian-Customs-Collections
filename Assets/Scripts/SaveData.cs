using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    [SerializeField] TMP_InputField _nameIncoming;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SavedJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadForJson();
        }


    }

    public void SavedJson()
    {
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/inventoryData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("algo en frances que se efectuó");
    }

    public void LoadForJson()
    {
        string filePath = Application.persistentDataPath + "/inventoryData.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);
        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        Debug.Log("data cargada");
    }

    public void SetName()
    {
        inventory._name = _nameIncoming.text;
        inventory._score = 70;
        inventory._time = "000100";
        inventory.AddList();
    }

    public void SortList()
    {
        inventory.SortList();
    }
}

[System.Serializable]
public class Inventory
{
    [SerializeField] GameObject parentGroup;
    [SerializeField] GameObject prefabElementUI;
    public string _name;
    public int _score;
    public string _time;
    public int goldCoin;
    public bool isFull;

    public List<PlayerHighScore> _high = new List<PlayerHighScore>();
    public PlayerHighScore highScore = new PlayerHighScore();
   
    public void AddList()
    {
        highScore.name = _name;
        highScore.score = _score;
        _high.Add(highScore);
        
    }

    public void SortList()
    {
        foreach (PlayerHighScore score in _high)
        {
                Debug.Log(score.name);
                Debug.Log(score.score);
                //Debug.Log(score.time);
            //_high.Sort((p1, p2) => p1.time.CompareTo(p2.time));
            _high.Sort((p1, p2) => p2.score.CompareTo(p1.score));
        }
    }
}

[System.Serializable]
public class Items
{
    public string name;
    public string description;
}

//[System.Serializable]
//public class PlayerHighScore
//{
//    public string name = string.Empty;
//    public int score;
//    public string time = string.Empty;
//}



