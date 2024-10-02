using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SapoDetectorPoints : MonoBehaviour
{
    [SerializeField] int[] valuePoints = { 9, 10, 12, 15, 20, 30, 70, 80, 90, 500 };
    [SerializeField] int valuepointsArray = 0, totalPoints = 0;
    [SerializeField, Tooltip("here put the text mesh associated to scorepoint")] TextMeshProUGUI totalScore;
    [SerializeField] TextMeshProUGUI momentumScore;
    [SerializeField] Animator animator;
    [SerializeField] bool valid01 = false;
    [SerializeField] WritingDB writingDB;
    [SerializeField] HighScore _highScore;
    int _value = 0, _maxValue = 0;


    private const string gainPoint = ("GainPoint");

    // Start is called before the first frame update
    void Start()
    {
        _maxValue = _highScore.HighValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (valid01)
        {
            totalPoints = Convert.ToInt32(totalScore.text);
            totalPoints += valuePoints[valuepointsArray];
            totalScore.text = Convert.ToString(totalPoints);
            momentumScore.text = "+" + Convert.ToString(valuePoints[valuepointsArray]);
            animator.SetBool(gainPoint, true);
            valid01 = false;
            StartCoroutine(restAnimation());

            _value = totalPoints;

            if (_value > _maxValue)
            {
                _highScore.HighValue = _value;
                _maxValue = _value;
            }

            writingDB.AddData();

            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring"))
        {
            valid01 = true;
            other.enabled = false;
        }
    }

    IEnumerator restAnimation()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool(gainPoint, false);
    }

    public int MaxValue
    {
        get {return _maxValue;}
        set {_maxValue = value;}
    }

}
