using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendNamePlayer : MonoBehaviour
{
    [SerializeField] GameObject scoreList;
    [SerializeField] SaveHSList saveHSList;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSecond());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitSecond()
    {
        yield return new WaitForSeconds(1);
        saveHSList.GOUpdateFromAnotherScript(scoreList);
    }
}
