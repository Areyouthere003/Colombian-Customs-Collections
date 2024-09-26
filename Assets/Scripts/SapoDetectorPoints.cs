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

    private const string gainPoint = ("GainPoint");

    // Start is called before the first frame update
    void Start()
    {

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

}
