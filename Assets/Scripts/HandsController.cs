using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandsController : MonoBehaviour
{
    [SerializeField] private InputActionProperty trigger;
    [SerializeField] private InputActionProperty gripAction;
    private Animator animatorController;

    void Start() {
       animatorController = GetComponent<Animator>();
    }
    void Update()
    {
        float triggerValue = trigger.action.ReadValue<float>();
        float gripValue = trigger.action.ReadValue<float>();
        animatorController.SetFloat("Trigger", triggerValue);
        animatorController.SetFloat("Grip", gripValue);
    }
}
