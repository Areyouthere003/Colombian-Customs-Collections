using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] arrayMenus;
    [SerializeField] private GameObject parentCanvitas;
    [SerializeField] private Material skyboxNight;
    [SerializeField] private Material skyboxGray;
    int currentIndex = 0;
    public void PlayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitWholeGame()
    {
        RenderSettings.skybox = skyboxNight;
        Application.Quit(); 
    }


    private void Start()
    {
        HideMenus();
        ShowMenu(0);
    }

    void HideMenus() {
        foreach (GameObject menu in arrayMenus)
        {
            menu.SetActive(false);
        }
    }

    void ShowMenu(int i)
    {
            if(i >= 0 && i <= arrayMenus.Length)
            {
                arrayMenus[i].SetActive(true);
                LeanTween.scale(parentCanvitas, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutExpo);
            }
    }
    private void HideMenu(int index, System.Action onComplete = null)
    {
        if (index >= 0 && index < arrayMenus.Length)
        {
            LeanTween.scale(parentCanvitas, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInExpo).setOnComplete(() =>
            {
                arrayMenus[index].SetActive(false);
                onComplete?.Invoke();
            });
        }
    }
    public void OnNextButtonPressed()
    {
        if (currentIndex < arrayMenus.Length - 1)
        {
            HideMenu(currentIndex, () =>
            {
                currentIndex++;
                ShowMenu(currentIndex);
            });
        }

        if (currentIndex == 0)
        {
            RenderSettings.skybox = skyboxNight;
        }
        else 
        {
                RenderSettings.skybox = skyboxGray;
        }

    }
   public void ResetCurrent()
    {
        HideMenu(1);
        ShowMenu(0);
        RenderSettings.skybox = skyboxNight;
        currentIndex = 0;
    }

    //IEnumerator DeactivateLastMenu()
    //{
    //    yield return new WaitForSeconds(5f);
    //    HideMenu(2);
    //}

    public void CloseMenu(int index)
    {
        if (index < arrayMenus.Length - 1)
        {
            HideMenu(index, () => {
                ShowMenu(currentIndex + 1);
            });
        }
    }

    public void ReturnMenu()
    {
        arrayMenus[1].SetActive(false);
        //LeanTween.scale(parentCanvitas, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutExpo);
        LeanTween.scale(gameObject, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutExpo);
    }


    void Update()
    {

    }
}
