using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField, Tooltip ("add the property for left button pause menu")]
    InputActionProperty actionPause;
    [SerializeField, Tooltip (" add the property for left rotation in Left XR controller")] 
    InputActionProperty actionRotHand;
    [SerializeField, Tooltip("Add the GameObject with UI Menu Pause")]
    GameObject pauseMenuUI;
    [SerializeField] GameObject menuButton;
    [SerializeField] bool validButtonOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        validButtonOn = actionPause.action.IsPressed();
        Quaternion rotValue = actionRotHand.action.ReadValue<Quaternion>();

        if (rotValue.eulerAngles.z > 90f)
        {
            menuButton.SetActive(true);
        }
        else menuButton.SetActive(false);

        if (validButtonOn)
        {
            if(!pauseMenuUI.activeInHierarchy)
            {
                pauseMenuUI.SetActive(true);
            }
        }
    }
}
