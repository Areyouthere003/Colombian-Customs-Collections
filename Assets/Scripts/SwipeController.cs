using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour
{
    [SerializeField] int maxPages;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType type;

    int currentPage = 1;
    Vector3 targetPos;
    float dragThreShould;

    private void Awake()
    {
        targetPos = levelPagesRect.position;
        dragThreShould = 390 / 2;
    }

    private void Update()
    {

    }

    //public void OnClick(Transform transform)
    //{
    //    if (Mathf.Abs(transform.position.x - 390) > dragThreShould)
    //    {
    //        if (transform.position.x > -390)
    //        {
    //            Previous();
    //        }
    //        else
    //        {
    //            Next();
    //        }
    //    }
    //    else
    //    {
    //        MovePage();
    //    }
    //}

    public void Next()
    {
        if (currentPage < maxPages)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Previous() 
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }

    }

    void MovePage() 
    {
        levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(type);
    }
}
