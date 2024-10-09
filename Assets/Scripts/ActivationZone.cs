using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActivationZone : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _chronoTimeTxt;
    [SerializeField] TextMeshProUGUI _totalScore;
    [SerializeField] TextMeshProUGUI _namePlayer;
    [SerializeField] HighScore _highScoreTotal;
    [SerializeField] GameObject ranaActivated;
    [SerializeField] GameObject saveData;
    [SerializeField] bool activeTime = false;
    [SerializeField] GameObject[] ringDesList;
    int min = 0, sec = 0, dSec = 0, compareValue;
    string _timeFull = "03:00:00";
    float _time = 180f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Crono();
    }

    private void Crono()
    {
        if (activeTime)
        {
            _time -= Time.deltaTime;
        }
        min = Mathf.FloorToInt(_time / 60); //formula matematica para sacar los minutos
        sec = Mathf.FloorToInt(_time % -60); //formula matematica para sacar los segundos (sacar tiempo en modulo de 60)
        dSec = Mathf.FloorToInt((_time % 1) * 100); //sacar las decimas de segundos

        _chronoTimeTxt.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, dSec);
        //se acomoda el texto del texto crono, la posici?n en el texto y como debe aparecer (el orden)

        if (min <= 0 && sec <= 0 && dSec <= 0)
        {
            activeTime = false;
            ranaActivated.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _time = 180;
            _highScoreTotal.HighValue = 0;
            _chronoTimeTxt.text += _timeFull;
            _totalScore.text = "0";
            activeTime = true;
            ranaActivated.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            saveData.GetComponent<SaveHSList>().GetScore(_highScoreTotal.HighValue);
            saveData.GetComponent<SaveHSList>().GetName(_highScoreTotal.stringValue);
            saveData.GetComponent<SaveHSList>().AddToList();
            activeTime = false;
            ranaActivated.SetActive(false);

            ringDesList = GameObject.FindGameObjectsWithTag("Ring");
            for (int i = 0; i < ringDesList.Length; i++)
            {
                ringDesList[i].SetActive(false);
            }
            saveData.GetComponent<SaveHSList>().SortListBig();
            saveData.GetComponent<SaveHSList>().RemoveTheLast();
            saveData.GetComponent<SaveHSList>().ScoreTableUpdate();
            saveData.GetComponent<SaveHSList>().SavedJson();
        }
    }
}
