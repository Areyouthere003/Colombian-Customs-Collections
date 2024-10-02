using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRanaManager : MonoBehaviour
{
    [SerializeField] private GameObject[] arrayMenus;
    [SerializeField] private GameObject parentCanvitas;
    private void Start()
    {
        ShowMenu(0);
    }
    public void ShowMenu(int i)
    {
        if (i >= 0 && i <= arrayMenus.Length)
        {
            arrayMenus[i].SetActive(true);
            LeanTween.scale(parentCanvitas, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutExpo);
        }
    }
   public void CloseMenu(int number)
    {
        HideMenu(number);
    } 

    public void HideMenu(int index, System.Action onComplete = null)
    {
        if (index >= 0 && index < arrayMenus.Length)
        {
            LeanTween.scale(arrayMenus[index], Vector3.zero, 0.5f).setEase(LeanTweenType.easeInExpo).setOnComplete(() =>
            {
                arrayMenus[index].SetActive(false);
                onComplete?.Invoke();
            });
        }
    }

}
